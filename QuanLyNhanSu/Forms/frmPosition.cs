using QuanLyNhanSu.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public partial class frmPosition : Form
    {
        private bool _dangThem = false;
        private bool _dangSua = false;
        private string? _maChucVuDangSua = null;

        public List<ChucVu> DSChucVu { get; private set; } = new List<ChucVu>();
        public List<NhanVien> DSNhanVien { get; private set; } = new List<NhanVien>();
        public SessionLogin NVDangNhap { get; private set; } = new SessionLogin();

        public frmPosition(List<ChucVu> DSCV, List<NhanVien> DSNV, SessionLogin sessionlogin)
        {
            InitializeComponent();

            DSChucVu = DSCV;
            DSNhanVien = DSNV;
            NVDangNhap = sessionlogin;
        }

        private bool CoQuyenHan()
        {
            return NVDangNhap.nvDangNhapQuyenHan;
        }

        private string DuongDanFileMacDinh()
        {
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Resources",
                "DummyData",
                "ChucVu.txt");
        }

        private void CapNhatTrangThaiNut()
        {
            bool coQuyen = NVDangNhap.nvDangNhapQuyenHan;
            bool dangThaoTac = _dangThem || _dangSua;

            btnThem.Enabled = coQuyen && !dangThaoTac;
            btnSua.Enabled = coQuyen && !dangThaoTac;
            btnXoa.Enabled = coQuyen && !dangThaoTac;

            btnLuu.Enabled = coQuyen && dangThaoTac;
            btnHuy.Enabled = dangThaoTac;

            btnSaveImmediately.Enabled = coQuyen;
            btnImport.Enabled = coQuyen && !dangThaoTac;

            btnLamMoi.Enabled = true;
            btnExport.Enabled = true;

            txtMaChucVu.ReadOnly = !_dangThem;
            txtTenChucVu.ReadOnly = !dangThaoTac;
            txtPhuCapThang.ReadOnly = !dangThaoTac;
        }

        private void HienThiDanhSachChucVu()
        {
            lvChucVu.Items.Clear();

            foreach (ChucVu cv in DSChucVu)
            {
                int soNhanVien = DSNhanVien.Count(
                    nv => nv.MaChucVu == cv.MaChucVu);

                ListViewItem item = new ListViewItem(cv.MaChucVu);
                item.SubItems.Add(cv.TenChucVu);
                item.SubItems.Add(cv.PhuCap.ToString("N0"));
                item.SubItems.Add(soNhanVien.ToString());

                lvChucVu.Items.Add(item);
            }
        }

        private void LamTrongThongTin()
        {
            txtMaChucVu.Clear();
            txtTenChucVu.Clear();
            txtPhuCapThang.Clear();

            lvChucVu.SelectedItems.Clear();
        }

        private void KetThucThaoTac()
        {
            _dangThem = false;
            _dangSua = false;
            _maChucVuDangSua = null;

            LamTrongThongTin();
            CapNhatTrangThaiNut();
        }

        private bool KiemTraDuLieu(
            out string maChucVu,
            out string tenChucVu,
            out decimal phuCap)
        {
            maChucVu = txtMaChucVu.Text.Trim();
            tenChucVu = txtTenChucVu.Text.Trim();
            phuCap = 0;

            if (string.IsNullOrWhiteSpace(maChucVu))
            {
                MessageBox.Show(
                    "Mã chức vụ không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaChucVu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenChucVu))
            {
                MessageBox.Show(
                    "Tên chức vụ không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenChucVu.Focus();
                return false;
            }

            if (!decimal.TryParse(
                    txtPhuCapThang.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out phuCap)
                && !decimal.TryParse(
                    txtPhuCapThang.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out phuCap))
            {
                MessageBox.Show(
                    "Phụ cấp tháng phải là số hợp lệ.",
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhuCapThang.Focus();
                return false;
            }

            if (phuCap < 0)
            {
                MessageBox.Show(
                    "Phụ cấp tháng không được âm.",
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhuCapThang.Focus();
                return false;
            }

            return true;
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            HienThiDanhSachChucVu();
            LamTrongThongTin();
            CapNhatTrangThaiNut();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này.", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dangThem = true;
            _dangSua = false;
            _maChucVuDangSua = null;

            LamTrongThongTin();
            CapNhatTrangThaiNut();

            txtMaChucVu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvChucVu.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn chức vụ cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maChucVu = lvChucVu.SelectedItems[0].Text;

            ChucVu? cv = DSChucVu.FirstOrDefault(
                x => x.MaChucVu == maChucVu);

            if (cv == null)
                return;

            _dangSua = true;
            _dangThem = false;
            _maChucVuDangSua = cv.MaChucVu;

            txtMaChucVu.Text = cv.MaChucVu;
            txtTenChucVu.Text = cv.TenChucVu;
            txtPhuCapThang.Text = cv.PhuCap.ToString(
                CultureInfo.CurrentCulture);

            CapNhatTrangThaiNut();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dangThem || _dangSua)
            {
                MessageBox.Show(
                    "Vui lòng lưu hoặc hủy thao tác hiện tại trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvChucVu.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn chức vụ cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maChucVu = lvChucVu.SelectedItems[0].Text;

            bool coNhanVien = DSNhanVien.Any(
                nv => nv.MaChucVu == maChucVu);

            if (coNhanVien)
            {
                MessageBox.Show(
                    "Không thể xóa chức vụ đang có nhân viên trực thuộc.",
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa chức vụ {maChucVu} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            ChucVu? cv = DSChucVu.FirstOrDefault(
                x => x.MaChucVu == maChucVu);

            if (cv != null)
                DSChucVu.Remove(cv);

            HienThiDanhSachChucVu();
            LamTrongThongTin();
            CapNhatTrangThaiNut();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này.");
                return;
            }

            if (!_dangThem && !_dangSua)
                return;

            if (!KiemTraDuLieu(
                    out string maChucVu,
                    out string tenChucVu,
                    out decimal phuCap))
            {
                return;
            }

            if (_dangThem)
            {
                bool trungMa = DSChucVu.Any(
                    cv => string.Equals(
                        cv.MaChucVu,
                        maChucVu,
                        StringComparison.OrdinalIgnoreCase));

                if (trungMa)
                {
                    MessageBox.Show(
                        "Mã chức vụ đã tồn tại.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Chức vụ mới mặc định không có quyền CRUD hệ thống
                DSChucVu.Add(new ChucVu(
                    maChucVu,
                    tenChucVu,
                    phuCap,
                    false));
            }
            else if (_dangSua)
            {
                ChucVu? cvCu = DSChucVu.FirstOrDefault(
                    cv => cv.MaChucVu == _maChucVuDangSua);

                if (cvCu == null)
                {
                    MessageBox.Show("Không tìm thấy chức vụ cần sửa.");
                    return;
                }

                int viTri = DSChucVu.IndexOf(cvCu);

                // Giữ nguyên mã và quyền CRUD cũ
                DSChucVu[viTri] = new ChucVu(
                    cvCu.MaChucVu,
                    tenChucVu,
                    phuCap,
                    cvCu.QuyenCRUD);
            }

            HienThiDanhSachChucVu();
            KetThucThaoTac();
        }

        private void btnSaveImmediately_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này.");
                return;
            }

            // Chỉ ghi dữ liệu đã có trong DSChucVu
            // Không đọc dữ liệu chưa lưu từ textbox
            try
            {
                string duongDan = DuongDanFileMacDinh();
                string? thuMuc = Path.GetDirectoryName(duongDan);

                if (!string.IsNullOrEmpty(thuMuc))
                    Directory.CreateDirectory(thuMuc);

                GhiDanhSachChucVu(duongDan);

                MessageBox.Show(
                    $"Đã lưu danh sách chức vụ vào:\n{duongDan}",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể lưu file.\nChi tiết: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GhiDanhSachChucVu(string duongDan)
        {
            using (StreamWriter sw = new StreamWriter(
                duongDan,
                false,
                new UTF8Encoding(true)))
            {
                foreach (ChucVu cv in DSChucVu)
                {
                    sw.WriteLine($"MaChucVu: {cv.MaChucVu}");
                    sw.WriteLine($"TenChucVu: {cv.TenChucVu}");
                    sw.WriteLine($"PhuCap: {cv.PhuCap.ToString(CultureInfo.InvariantCulture)}");
                    sw.WriteLine($"QuyenCRUD: {cv.QuyenCRUD}");
                    sw.WriteLine("---");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KetThucThaoTac();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Bỏ trạng thái thêm/sửa chưa lưu
            // và tải lại dữ liệu hiện có trong danh sách
            KetThucThaoTac();
            HienThiDanhSachChucVu();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Xuất DSChucVu hiện tại, không lấy nội dung textbox
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất danh sách chức vụ";
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.FileName = "ChucVu.txt";
                dialog.OverwritePrompt = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    GhiDanhSachChucVu(dialog.FileName);

                    MessageBox.Show(
                        "Xuất danh sách chức vụ thành công.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể xuất file.\nChi tiết: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này.");
                return;
            }

            if (_dangThem || _dangSua)
            {
                MessageBox.Show(
                    "Vui lòng lưu hoặc hủy thao tác hiện tại trước khi nhập file.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn file danh sách chức vụ";
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string[] lines = File.ReadAllLines(dialog.FileName);

                    string? maChucVu = null;
                    string? tenChucVu = null;
                    string? chuoiPhuCap = null;
                    string? chuoiQuyenCRUD = null;

                    int soLuongThem = 0;
                    int soLuongBoQua = 0;

                    HashSet<string> maDaCo = new HashSet<string>(
                        DSChucVu.Select(cv => cv.MaChucVu),
                        StringComparer.OrdinalIgnoreCase);

                    void XuLyBanGhi()
                    {
                        if (string.IsNullOrWhiteSpace(maChucVu)
                            || string.IsNullOrWhiteSpace(tenChucVu)
                            || string.IsNullOrWhiteSpace(chuoiPhuCap)
                            || !decimal.TryParse(
                                chuoiPhuCap,
                                NumberStyles.Number,
                                CultureInfo.InvariantCulture,
                                out decimal phuCap)
                            || phuCap < 0)
                        {
                            soLuongBoQua++;
                        }
                        else if (maDaCo.Contains(maChucVu))
                        {
                            soLuongBoQua++;
                        }
                        else
                        {
                            bool quyenCRUD = false;

                            if (!string.IsNullOrWhiteSpace(chuoiQuyenCRUD))
                            {
                                if (!bool.TryParse(
                                    chuoiQuyenCRUD,
                                    out quyenCRUD))
                                {
                                    // Bỏ qua bản ghi có quyền CRUD sai định dạng
                                    soLuongBoQua++;

                                    maChucVu = null;
                                    tenChucVu = null;
                                    chuoiPhuCap = null;
                                    chuoiQuyenCRUD = null;
                                    return;
                                }
                            }

                            DSChucVu.Add(new ChucVu(
                                maChucVu,
                                tenChucVu,
                                phuCap,
                                quyenCRUD));

                            maDaCo.Add(maChucVu);
                            soLuongThem++;
                        }

                        maChucVu = null;
                        tenChucVu = null;
                        chuoiPhuCap = null;
                        chuoiQuyenCRUD = null;
                    }

                    foreach (string line in lines)
                    {
                        string dong = line.Trim();

                        if (dong == "---")
                        {
                            if (maChucVu != null
                                || tenChucVu != null
                                || chuoiPhuCap != null
                                || chuoiQuyenCRUD != null)
                            {
                                XuLyBanGhi();
                            }

                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(dong))
                            continue;

                        string[] parts = dong.Split(new char[] { ':' }, 2);

                        if (parts.Length != 2)
                            continue;

                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        if (key.Equals(
                            "MaChucVu",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            maChucVu = value;
                        }
                        else if (key.Equals(
                            "TenChucVu",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            tenChucVu = value;
                        }
                        else if (key.Equals(
                            "PhuCap",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            chuoiPhuCap = value;
                        }
                        else if (key.Equals(
                            "QuyenCRUD",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            chuoiQuyenCRUD = value;
                        }
                    }

                    // Xử lý bản ghi cuối nếu file không có --- ở cuối
                    if (maChucVu != null
                        || tenChucVu != null
                        || chuoiPhuCap != null
                        || chuoiQuyenCRUD != null)
                    {
                        XuLyBanGhi();
                    }

                    HienThiDanhSachChucVu();
                    LamTrongThongTin();

                    MessageBox.Show(
                        $"Nhập file hoàn tất!\n" +
                        $"Số chức vụ được thêm: {soLuongThem}\n" +
                        $"Số bản ghi bị bỏ qua: {soLuongBoQua}",
                        "Kết quả nhập file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể nhập dữ liệu từ file.\nChi tiết: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void lvChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangThem || _dangSua)
                return;

            if (lvChucVu.SelectedItems.Count == 0)
            {
                LamTrongThongTin();
                return;
            }

            string maChucVu = lvChucVu.SelectedItems[0].Text;

            ChucVu? cv = DSChucVu.FirstOrDefault(
                x => x.MaChucVu == maChucVu);

            if (cv == null)
                return;

            txtMaChucVu.Text = cv.MaChucVu;
            txtTenChucVu.Text = cv.TenChucVu;
            txtPhuCapThang.Text = cv.PhuCap.ToString(
                CultureInfo.CurrentCulture);
        }
        private void frmEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;   
                this.Hide();       
            }
        }
    }
}