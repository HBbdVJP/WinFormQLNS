using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;

namespace QuanLyNhanSu.Forms
{
    public partial class frmSalary : Form
    {
        private const string DiLam = "Đi làm";
        private const string DiTre = "Đi trễ";

        private readonly List<NhanVien> danhSachNhanVien;
        private readonly List<PhongBan> danhSachPhongBan;
        private readonly List<ChucVu> danhSachChucVu;
        private readonly SessionLogin sessionLogin;
        private readonly List<SalaryRow> bangLuong = new();

        private readonly string chamCongFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Resources",
            "DummyData",
            "ChamCong.txt");

        private sealed class SalaryRow
        {
            public NhanVien NhanVien { get; init; } = new();
            public decimal LuongCoBan { get; init; }
            public decimal PhuCap { get; init; }
            public decimal PhatDiTre { get; init; }
            public int NgayLam { get; init; }
            public int SoLanDiTre { get; init; }
            public decimal ThucLanh { get; init; }
            public int PhepConLai { get; init; }
            public int TangCa { get; init; }
        }

        public frmSalary(
            List<NhanVien> danhSachNhanVien,
            List<PhongBan> danhSachPhongBan,
            List<ChucVu> danhSachChucVu,
            SessionLogin sessionLogin)
        {
            InitializeComponent();

            this.danhSachNhanVien = danhSachNhanVien;
            this.danhSachPhongBan = danhSachPhongBan;
            this.danhSachChucVu = danhSachChucVu;
            this.sessionLogin = sessionLogin;

            btnXem.Click += (_, _) => TinhVaHienThiLuong();
            btnTinhLuong.Click += (_, _) => TinhVaHienThiLuong();
            btnXuatPhieuLuong.Click += btnXuatPhieuLuong_Click;
            btnXuatBangLuong.Click += btnXuatBangLuong_Click;
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            cboThang.Items.Clear();

            for (int thang = 1; thang <= 12; thang++)
            {
                cboThang.Items.Add(thang.ToString("00"));
            }

            cboThang.SelectedIndex = DateTime.Today.Month - 1;
            nudNam.Value = Math.Clamp(
                DateTime.Today.Year,
                (int)nudNam.Minimum,
                (int)nudNam.Maximum);

            cboPhong.Items.Clear();
            cboPhong.Items.Add("Tất cả phòng ban");

            foreach (PhongBan phongBan in danhSachPhongBan)
            {
                cboPhong.Items.Add(phongBan.TenPhongBan);
            }

            cboPhong.SelectedIndex = 0;

            bool coQuyen = sessionLogin.nvDangNhapQuyenHan;

            btnXem.Enabled = coQuyen;
            btnTinhLuong.Enabled = coQuyen;
            btnXuatPhieuLuong.Enabled = coQuyen;
            btnXuatBangLuong.Enabled = coQuyen;

            lblThongTin.Text = coQuyen
                ? "Chưa có dữ liệu"
                : "Tài khoản chỉ được xem";
        }

        private void TinhVaHienThiLuong()
        {
            if (!sessionLogin.nvDangNhapQuyenHan)
            {
                MessageBox.Show(
                    "Tài khoản hiện tại không có quyền tính hoặc xuất lương.",
                    "Không đủ quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cboThang.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn tháng.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int thang = cboThang.SelectedIndex + 1;
            int nam = (int)nudNam.Value;

            List<AttendanceRow> chamCong = NapChamCong();

            string? maPhongBan = LayMaPhongBanDangChon();

            bangLuong.Clear();

            IEnumerable<NhanVien> nhanVien = danhSachNhanVien.Where(x =>
                maPhongBan == null || x.MaPhongBan == maPhongBan);

            foreach (NhanVien nv in nhanVien.OrderBy(x => x.TenNhanVien))
            {
                List<AttendanceRow> cuaNhanVien = chamCong.Where(x =>
                    x.MaNhanVien.Equals(
                        nv.MaNhanVien,
                        StringComparison.OrdinalIgnoreCase) &&
                    x.Ngay.Month == thang &&
                    x.Ngay.Year == nam).ToList();

                bangLuong.Add(TinhLuongNhanVien(nv, cuaNhanVien));
            }

            HienThiBangLuong();
        }

        private sealed class AttendanceRow
        {
            public string MaNhanVien { get; init; } = string.Empty;
            public DateTime Ngay { get; init; }
            public string TrangThai { get; init; } = string.Empty;
            public int TangCa { get; init; }
        }

        private List<AttendanceRow> NapChamCong()
        {
            List<AttendanceRow> ketQua = new();

            if (!File.Exists(chamCongFilePath))
            {
                return ketQua;
            }

            // Đọc file chấm công bằng StreamReader
            using (StreamReader reader = new StreamReader(chamCongFilePath))
            {
                string? dong;

                while ((dong = reader.ReadLine()) != null)
                {
                    string[] cot = dong.Split(
                        dong.Contains(';') ? ';' : ',');

                    if (cot.Length < 3 ||
                        cot[0].Trim().Equals(
                            "MaNV",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (!DateTime.TryParseExact(
                            cot[1].Trim(),
                            new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" },
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime ngay))
                    {
                        continue;
                    }

                    string trangThai = cot[2].Trim();
                    int tangCa = 0;

                    // Định dạng mới: MaNV;Ngay;TrangThai;TangCa;GhiChu.
                    // Định dạng cũ: MaNV;Ngay;TrangThai;GhiChu.
                    if (cot.Length > 3 && int.TryParse(cot[3].Trim(), out int soGio))
                    {
                        if (soGio < 0 || soGio > 24)
                        {
                            continue;
                        }

                        tangCa = soGio;
                    }

                    if (!danhSachNhanVien.Any(x =>
                            x.MaNhanVien.Equals(
                                cot[0].Trim(),
                                StringComparison.OrdinalIgnoreCase)) ||
                        (trangThai != DiLam && trangThai != DiTre))
                    {
                        continue;
                    }

                    ketQua.Add(new AttendanceRow
                    {
                        MaNhanVien = cot[0].Trim(),
                        Ngay = ngay.Date,
                        TrangThai = trangThai,
                        TangCa = tangCa
                    });
                }
            }

            return ketQua;
        }

        private SalaryRow TinhLuongNhanVien(
    NhanVien nv,
    List<AttendanceRow> chamCong)
        {
            decimal ngayCongChuan = DocDecimalCauHinh(
                "NgayCongChuan",
                26m);

            decimal tangCaToiDaPerDay = DocDecimalCauHinh(
                "TangCaToiDaPerDay",
                12m);

            decimal mucTruDiTre = DocDecimalCauHinh(
                "MucTruDiTre",
                100000m);

            decimal heSoTangCa = DocDecimalCauHinh(
                "HeSoTangCa",
                1.5m);

            decimal soGioLamChuan = DocDecimalCauHinh(
                "SoGioLamChuan",
                8m);

            decimal luongCoBan = nv.LuongCoBan ?? 0m;

            decimal phuCap = danhSachChucVu
                .FirstOrDefault(x => x.MaChucVu == nv.MaChucVu)?
                .PhuCap ?? 0m;

            int ngayLam = chamCong
                .Select(x => x.Ngay.Date)
                .Distinct()
                .Count();

            int soLanDiTre = chamCong.Count(x =>
                x.TrangThai == DiTre);

            // Tổng số giờ tăng ca
            decimal tangCaToiDaTrongThang =
                Math.Max(0m, tangCaToiDaPerDay * ngayCongChuan);
            int tongGioTangCa = (int)Math.Min(
                int.MaxValue,
                Math.Min(tangCaToiDaTrongThang, chamCong.Sum(x => x.TangCa)));

            // Tiền phạt đi trễ
            decimal phatDiTre = soLanDiTre * mucTruDiTre;

            // Lương theo ngày công
            decimal luongTheoCong = ngayCongChuan == 0
                ? 0m
                : luongCoBan / ngayCongChuan * ngayLam;

            // Lương một giờ
            decimal luongMotGio = ngayCongChuan == 0 || soGioLamChuan == 0
                ? 0m
                : luongCoBan / (ngayCongChuan * soGioLamChuan);

            // Tiền tăng ca
            decimal tienTangCa = luongMotGio
                * heSoTangCa
                * tongGioTangCa;

            // Thực lãnh
            decimal thucLanh = luongTheoCong
                + phuCap
                + tienTangCa
                - phatDiTre;

            return new SalaryRow
            {
                NhanVien = nv,
                LuongCoBan = luongCoBan,
                PhuCap = phuCap,
                PhatDiTre = phatDiTre,
                NgayLam = ngayLam,
                SoLanDiTre = soLanDiTre,
                TangCa = tongGioTangCa,
                PhepConLai = nv.SoNgayNghiPhep ?? 0,
                ThucLanh = thucLanh
            };
        }

        private decimal DocDecimalCauHinh(
            string key,
            decimal giaTriMacDinh)
        {
            string? text = ConfigurationManager.AppSettings[key];

            return decimal.TryParse(
                text,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out decimal value)
                ? value
                : giaTriMacDinh;
        }

        private string? LayMaPhongBanDangChon()
        {
            if (cboPhong.SelectedIndex <= 0 ||
                cboPhong.SelectedItem == null)
            {
                return null;
            }

            return danhSachPhongBan.FirstOrDefault(x =>
                x.TenPhongBan == cboPhong.SelectedItem.ToString())?
                .MaPhongBan;
        }

        private void HienThiBangLuong()
        {
            lvLuong.Items.Clear();

            foreach (SalaryRow row in bangLuong)
            {
                ListViewItem item = new(
                    row.NhanVien.MaNhanVien);

                item.SubItems.Add(
                    row.NhanVien.TenNhanVien ?? "");

                item.SubItems.Add(
                    row.LuongCoBan.ToString("N0"));

                item.SubItems.Add(
                    row.NgayLam.ToString());

                item.SubItems.Add(
                    row.SoLanDiTre.ToString());

                item.SubItems.Add(
                    row.TangCa.ToString());

                item.SubItems.Add(
                    row.PhepConLai.ToString());

                item.SubItems.Add(
                    row.ThucLanh.ToString("N0"));

                item.Tag = row;

                lvLuong.Items.Add(item);
            }

            lblThongTin.Text = $"Có {bangLuong.Count} nhân viên";
        }

        private void btnXuatPhieuLuong_Click(
            object? sender,
            EventArgs e)
        {
            if (lvLuong.SelectedItems.Count == 0 ||
                lvLuong.SelectedItems[0].Tag is not SalaryRow row)
            {
                MessageBox.Show(
                    "Vui lòng chọn một nhân viên trong bảng lương.",
                    "Thiếu lựa chọn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            saveFileDialog1.Filter =
                "Tập tin văn bản (*.txt)|*.txt";

            saveFileDialog1.FileName =
                $"PhieuLuong_{row.NhanVien.MaNhanVien}.txt";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string tenDonVi =
                ConfigurationManager.AppSettings["TenDonVi"] ?? "";

            StringBuilder noiDung = new();

            noiDung.AppendLine(tenDonVi);
            noiDung.AppendLine("PHIẾU LƯƠNG");
            noiDung.AppendLine($"Mã nhân viên: {row.NhanVien.MaNhanVien}");
            noiDung.AppendLine($"Họ tên: {row.NhanVien.TenNhanVien}");
            noiDung.AppendLine($"Lương cơ bản: {row.LuongCoBan:N0} VNĐ");
            noiDung.AppendLine($"Phụ cấp: {row.PhuCap:N0} VNĐ");
            noiDung.AppendLine($"Ngày công thực tế: {row.NgayLam}");
            noiDung.AppendLine($"Số lần đi trễ: {row.SoLanDiTre}");
            noiDung.AppendLine($"Số giờ tăng ca: {row.TangCa}");
            noiDung.AppendLine($"Trừ đi trễ: {row.PhatDiTre:N0} VNĐ");
            noiDung.AppendLine($"Phép năm còn lại: {row.PhepConLai}");
            noiDung.AppendLine($"Thực lĩnh: {row.ThucLanh:N0} VNĐ");

            // Ghi phiếu lương bằng StreamWriter
            using (StreamWriter writer = new StreamWriter(
                saveFileDialog1.FileName,
                false,
                Encoding.UTF8))
            {
                writer.Write(noiDung.ToString());
            }
        }

        private void btnXuatBangLuong_Click(
            object? sender,
            EventArgs e)
        {
            if (bangLuong.Count == 0)
            {
                MessageBox.Show(
                    "Chưa có dữ liệu bảng lương để xuất.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            saveFileDialog1.Filter =
                "Tập tin CSV (*.csv)|*.csv";

            saveFileDialog1.FileName =
                $"BangLuong_{nudNam.Value}_{cboThang.SelectedIndex + 1:00}.csv";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<string> dong = new()
            {
                "MaNV;HoTen;LuongCoBan;NgayCong;DiTre;TangCa;PhuCap;PhepNamConLai;PhatDiTre;ThucLanh"
            };

            dong.AddRange(bangLuong.Select(row => string.Join(";", new[]
            {
                row.NhanVien.MaNhanVien,
                LamSachCsv(row.NhanVien.TenNhanVien),
                row.LuongCoBan.ToString(CultureInfo.InvariantCulture),
                row.NgayLam.ToString(),
                row.SoLanDiTre.ToString(),
                row.TangCa.ToString(),
                row.PhuCap.ToString(CultureInfo.InvariantCulture),
                row.PhepConLai.ToString(),
                row.PhatDiTre.ToString(CultureInfo.InvariantCulture),
                row.ThucLanh.ToString(CultureInfo.InvariantCulture)
            })));

            // Ghi bảng lương bằng StreamWriter
            using (StreamWriter writer = new StreamWriter(
                saveFileDialog1.FileName,
                false,
                Encoding.UTF8))
            {
                foreach (string dongHienTai in dong)
                {
                    writer.WriteLine(dongHienTai);
                }
            }
        }

        private static string LamSachCsv(string? value)
        {
            return (value ?? string.Empty)
                .Replace(";", ",")
                .Replace("\r", " ")
                .Replace("\n", " ");
        }
    }
}