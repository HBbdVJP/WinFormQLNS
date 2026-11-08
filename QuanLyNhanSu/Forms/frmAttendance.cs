using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;

namespace QuanLyNhanSu.Forms
{
    public partial class frmAttendance : Form
    {
        private const string DiLam = "Đi làm";
        private const string NghiPhep = "Nghỉ phép";
        private const string NghiKhongPhep = "Nghỉ không phép";
        private const string DiTre = "Đi trễ";

        private readonly List<NhanVien> danhSachNhanVien;
        private readonly List<PhongBan> danhSachPhongBan;
        private readonly SessionLogin sessionLogin;
        private readonly List<ChamCong> danhSachChamCong = new();
        private readonly string chamCongFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Resources",
            "DummyData",
            "ChamCong.txt");
        private bool dangNapDanhSach;
        private bool dangCapNhatTrangThai;

        public frmAttendance(
            List<NhanVien> danhSachNhanVien,
            List<PhongBan> danhSachPhongBan,
            SessionLogin sessionLogin)
        {
            InitializeComponent();
            this.danhSachNhanVien = danhSachNhanVien;
            this.danhSachPhongBan = danhSachPhongBan;
            this.sessionLogin = sessionLogin;

            dtpNgay.MaxDate = DateTime.Today;
            dtpNgay.Value = DateTime.Today;
            TaoDanhSachPhongBan();
            NapBangCongTuFile();
            GanSuKien();
            CapNhatQuyenChinhSua();
            HienThiDanhSach();
        }

        private void GanSuKien()
        {
            btnTaiDanhSach.Click += (_, _) => HienThiDanhSach();
            btnNhapCSV.Click += btnNhapCSV_Click;
            btnLuuBangCong.Click += btnLuuBangCong_Click;
            btnChonTatCa.Click += (_, _) => DatTrangThaiTatCa(true);
            btnBoChon.Click += (_, _) => DatTrangThaiTatCa(false);
            dtpNgay.ValueChanged += (_, _) => HienThiDanhSach();
            cboPhong.SelectedIndexChanged += (_, _) => HienThiDanhSach();
            lvChamCong.ItemChecked += lvChamCong_ItemChecked;
            lvChamCong.MouseDown += lvChamCong_MouseDown;
            mnuDiLam.Click += (_, _) => DatTrangThaiDaChon(DiLam);
            mnuNghiPhep.Click += (_, _) => DatTrangThaiDaChon(NghiPhep);
            mnuNghiKhongPhep.Click += (_, _) => DatTrangThaiDaChon(NghiKhongPhep);
            mnuDiTre.Click += (_, _) => DatTrangThaiDaChon(DiTre);
            mnuGhiChu.Click += (_, _) => NhapGhiChuDaChon();
        }

        private void TaoDanhSachPhongBan()
        {
            cboPhong.Items.Clear();
            cboPhong.Items.Add("Tất cả phòng ban");
            foreach (PhongBan phongBan in danhSachPhongBan)
            {
                cboPhong.Items.Add(phongBan.TenPhongBan);
            }

            cboPhong.SelectedIndex = 0;
        }

        private void NapBangCongTuFile()
        {
            danhSachChamCong.Clear();
            if (!File.Exists(chamCongFilePath))
            {
                return;
            }

            foreach (string line in File.ReadLines(chamCongFilePath))
            {
                if (!TryParseCsvLine(line, out ChamCong? chamCong, out _))
                {
                    continue;
                }

                CapNhatHoacThem(chamCong);
            }
        }

        private void NhapGhiChuDaChon()
        {
            if (!sessionLogin.nvDangNhapQuyenHan || lvChamCong.SelectedItems.Count == 0)
            {
                return;
            }

            string ghiChuCu = lvChamCong.SelectedItems[0].SubItems[6].Text;
            using Form dialog = new Form
            {
                Text = "Ghi chú chấm công",
                Width = 560,
                Height = 300,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowInTaskbar = false
            };

            Label label = new Label
            {
                AutoSize = true,
                Left = 15,
                Top = 15,
                Text = "Nội dung ghi chú:"
            };
            TextBox textBox = new TextBox
            {
                Left = 15,
                Top = 45,
                Width = 510,
                Height = 135,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Text = ghiChuCu
            };
            Button buttonOk = new Button
            {
                Text = "Lưu",
                DialogResult = DialogResult.OK,
                Left = 350,
                Top = 200,
                Width = 80
            };
            Button buttonCancel = new Button
            {
                Text = "Hủy",
                DialogResult = DialogResult.Cancel,
                Left = 440,
                Top = 200,
                Width = 80
            };
            dialog.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            dialog.AcceptButton = buttonOk;
            dialog.CancelButton = buttonCancel;

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            string ghiChu = textBox.Text.Trim().Replace(";", ",").Replace("\r", " ").Replace("\n", " ");
            foreach (ListViewItem item in lvChamCong.SelectedItems)
            {
                if (item.Tag is not NhanVien nv)
                {
                    continue;
                }

                string trangThai = ChuanHoaTrangThai(item.SubItems[4].Text) ?? NghiKhongPhep;
                ChamCong chamCong = new ChamCong(nv.MaNhanVien, dtpNgay.Value.Date, trangThai, ghiChu);
                CapNhatHoacThem(chamCong);
                item.SubItems[6].Text = ghiChu;
            }
        }

        private void HienThiDanhSach()
        {
            if (dtpNgay.Value.Date > DateTime.Today)
            {
                dtpNgay.Value = DateTime.Today;
                return;
            }

            dangNapDanhSach = true;
            try
            {
                lvChamCong.Items.Clear();
                string? maPhongBan = LayMaPhongBanDangChon();
                DateTime ngay = dtpNgay.Value.Date;
                IEnumerable<NhanVien> nhanVien = danhSachNhanVien.Where(x =>
                    maPhongBan == null || x.MaPhongBan == maPhongBan);

                foreach (NhanVien nv in nhanVien.OrderBy(x => x.TenNhanVien))
                {
                    ChamCong? chamCong = danhSachChamCong.FirstOrDefault(x =>
                        x.MaNhanVien == nv.MaNhanVien && x.NgayCong.Date == ngay);
                    string trangThai = chamCong?.TrangThai ?? NghiKhongPhep;
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(nv.MaNhanVien);
                    item.SubItems.Add(nv.TenNhanVien ?? "");
                    item.SubItems.Add(danhSachPhongBan.FirstOrDefault(x => x.MaPhongBan == nv.MaPhongBan)?.TenPhongBan ?? "");
                    item.SubItems.Add(trangThai);
                    item.SubItems.Add("0");
                    item.SubItems.Add(chamCong?.GhiChu ?? "");
                    item.Tag = nv;
                    item.Checked = trangThai == DiLam || trangThai == DiTre;
                    lvChamCong.Items.Add(item);
                }

                lblTong.Text = $"Số nhân viên: {lvChamCong.Items.Count}";
                lblCanhBao.Text = string.Empty;
            }
            finally
            {
                dangNapDanhSach = false;
            }
        }

        private string? LayMaPhongBanDangChon()
        {
            if (cboPhong.SelectedIndex <= 0 || cboPhong.SelectedItem == null)
            {
                return null;
            }

            return danhSachPhongBan.FirstOrDefault(x =>
                x.TenPhongBan == cboPhong.SelectedItem.ToString())?.MaPhongBan;
        }

        private void lvChamCong_ItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            if (dangNapDanhSach || dangCapNhatTrangThai || !sessionLogin.nvDangNhapQuyenHan)
            {
                return;
            }

            DatTrangThai(e.Item, e.Item.Checked ? DiLam : NghiKhongPhep);
        }

        private void lvChamCong_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            ListViewItem? item = lvChamCong.GetItemAt(e.X, e.Y);
            if (item != null && !item.Selected)
            {
                lvChamCong.SelectedItems.Clear();
                item.Selected = true;
            }
        }

        private void DatTrangThaiDaChon(string trangThai)
        {
            if (!sessionLogin.nvDangNhapQuyenHan)
            {
                return;
            }

            foreach (ListViewItem item in lvChamCong.SelectedItems)
            {
                DatTrangThai(item, trangThai);
            }
        }

        private void DatTrangThai(ListViewItem item, string trangThai)
        {
            dangCapNhatTrangThai = true;
            try
            {
                item.SubItems[4].Text = trangThai;
                item.Checked = trangThai == DiLam || trangThai == DiTre;
            }
            finally
            {
                dangCapNhatTrangThai = false;
            }
        }

        private void DatTrangThaiTatCa(bool diLam)
        {
            if (!sessionLogin.nvDangNhapQuyenHan)
            {
                return;
            }

            dangNapDanhSach = true;
            try
            {
                foreach (ListViewItem item in lvChamCong.Items)
                {
                    item.Checked = diLam;
                    item.SubItems[4].Text = diLam ? DiLam : NghiKhongPhep;
                }
            }
            finally
            {
                dangNapDanhSach = false;
            }
        }

        private void CapNhatQuyenChinhSua()
        {
            bool coQuyen = sessionLogin.nvDangNhapQuyenHan;
            btnLuuBangCong.Enabled = coQuyen;
            btnNhapCSV.Enabled = coQuyen;
            btnChonTatCa.Enabled = coQuyen;
            btnBoChon.Enabled = coQuyen;
            mnuDiLam.Enabled = coQuyen;
            mnuNghiPhep.Enabled = coQuyen;
            mnuNghiKhongPhep.Enabled = coQuyen;
            mnuDiTre.Enabled = coQuyen;
        }

        private void btnNhapCSV_Click(object? sender, EventArgs e)
        {
            if (!sessionLogin.nvDangNhapQuyenHan || openFileDialogCSV.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<string> loi = new();
            int soDongHopLe = 0;
            int soDong = 0;
            foreach (string line in File.ReadLines(openFileDialogCSV.FileName))
            {
                soDong++;
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("MaNV", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!TryParseCsvLine(line, out ChamCong? chamCong, out string lyDo))
                {
                    loi.Add($"Dòng {soDong}: {lyDo}");
                    continue;
                }

                CapNhatHoacThem(chamCong);
                soDongHopLe++;
            }

            HienThiDanhSach();
            string thongBao = $"Đã nhập {soDongHopLe} dòng hợp lệ.";
            if (loi.Count > 0)
            {
                thongBao += $"\nBỏ qua {loi.Count} dòng lỗi:\n" + string.Join("\n", loi.Take(20));
                if (loi.Count > 20)
                {
                    thongBao += "\n...";
                }
            }

            MessageBox.Show(thongBao, "Kết quả nhập bảng công", MessageBoxButtons.OK,
                loi.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private bool TryParseCsvLine(string line, out ChamCong? chamCong, out string lyDo)
        {
            chamCong = null;
            lyDo = string.Empty;
            string[] cot = line.Split(line.Contains(';') ? ';' : ',');
            if (cot.Length < 3)
            {
                lyDo = "Thiếu cột, cần MaNV;Ngay;TrangThai.";
                return false;
            }

            string maNhanVien = cot[0].Trim();
            string ngayText = cot[1].Trim();
            string? trangThai = ChuanHoaTrangThai(cot[2].Trim());
            string ghiChu = cot.Length > 3
                ? string.Join(",", cot.Skip(3)).Trim()
                : string.Empty;
            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                lyDo = "Mã nhân viên rỗng.";
                return false;
            }

            if (!danhSachNhanVien.Any(x => x.MaNhanVien.Equals(maNhanVien, StringComparison.OrdinalIgnoreCase)))
            {
                lyDo = $"Không tồn tại mã nhân viên {maNhanVien}.";
                return false;
            }

            if (!DateTime.TryParseExact(ngayText,
                    new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" },
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime ngay))
            {
                lyDo = "Ngày không đúng định dạng dd/MM/yyyy.";
                return false;
            }

            if (ngay.Date > DateTime.Today)
            {
                lyDo = "Không được chấm công ngày tương lai.";
                return false;
            }

            if (trangThai == null)
            {
                lyDo = "Trạng thái không hợp lệ.";
                return false;
            }

            chamCong = new ChamCong(maNhanVien, ngay.Date, trangThai, ghiChu);
            return true;
        }

        private string? ChuanHoaTrangThai(string trangThai)
        {
            return trangThai.Trim().ToLowerInvariant() switch
            {
                "đi làm" or "di lam" => DiLam,
                "nghỉ phép" or "nghi phep" => NghiPhep,
                "nghỉ không phép" or "nghi khong phep" => NghiKhongPhep,
                "đi trễ" or "di tre" => DiTre,
                _ => null
            };
        }

        private void CapNhatHoacThem(ChamCong chamCong)
        {
            ChamCong? banGhi = danhSachChamCong.FirstOrDefault(x =>
                x.MaNhanVien.Equals(chamCong.MaNhanVien, StringComparison.OrdinalIgnoreCase) &&
                x.NgayCong.Date == chamCong.NgayCong.Date);
            if (banGhi == null)
            {
                danhSachChamCong.Add(chamCong);
            }
            else
            {
                banGhi.CapNhatTrangThai(chamCong.TrangThai);
                banGhi.CapNhatGhiChu(chamCong.GhiChu);
            }
        }

        private void btnLuuBangCong_Click(object? sender, EventArgs e)
        {
            if (!sessionLogin.nvDangNhapQuyenHan)
            {
                return;
            }

            if (dtpNgay.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Không được lưu bảng công cho ngày tương lai.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngay = dtpNgay.Value.Date;
            foreach (ListViewItem item in lvChamCong.Items)
            {
                if (item.Tag is not NhanVien nv)
                {
                    continue;
                }

                string trangThai = ChuanHoaTrangThai(item.SubItems[4].Text) ?? NghiKhongPhep;
                string ghiChu = item.SubItems[6].Text.Trim();
                CapNhatHoacThem(new ChamCong(nv.MaNhanVien, ngay, trangThai, ghiChu));
            }

            Directory.CreateDirectory(Path.GetDirectoryName(chamCongFilePath)!);
            List<string> dong = new() { "MaNV;Ngay;TrangThai;GhiChu" };
            dong.AddRange(danhSachChamCong
                .OrderBy(x => x.NgayCong)
                .ThenBy(x => x.MaNhanVien)
                .Select(x => $"{x.MaNhanVien};{x.NgayCong:dd/MM/yyyy};{x.TrangThai};{x.GhiChu}"));
            File.WriteAllLines(chamCongFilePath, dong);
            lblCanhBao.Text = "Đã lưu bảng công.";
            MessageBox.Show("Đã lưu bảng công thành công.", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
