using QuanLyNhanSu.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public partial class frmDepartment : Form
    {
        private bool _dangThem = false;
        private bool _dangSua = false;

        private string? _maPhongBanDangSua;
        private string? _tenPhongBanCu;

        public List<PhongBan> DSPhongBan { get; private set; } = new List<PhongBan>();
        public List<NhanVien> DSNhanVien { get; private set; } = new List<NhanVien>();
        public SessionLogin NVDangNhap { get; private set; } = new SessionLogin();

        public frmDepartment(List<PhongBan> DSPB, List<NhanVien> DSNV, SessionLogin sessionlogin)
        {
            InitializeComponent();

            DSPhongBan = DSPB;
            DSNhanVien = DSNV;
            NVDangNhap = sessionlogin;
        }

        // Kiểm tra quyền CRUD.
        private bool CoQuyenHan()
        {
            return NVDangNhap.nvDangNhapQuyenHan;
        }

        // Đường dẫn file dữ liệu phòng ban mặc định.
        private string DuongDanFilePhongBan
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Resources",
                    "DummyData",
                    "PhongBan.txt"
                );
            }
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            CapNhatTrangThaiNut();
            HienThiDanhSachPhongBan();
            LamTrongThongTin();
        }
        // Bật/tắt nút theo quyền và trạng thái thao tác.
        private void CapNhatTrangThaiNut()
        {
            bool coQuyen = CoQuyenHan();
            bool dangThaoTac = _dangThem || _dangSua;

            btnUpdateDepartment.Enabled = coQuyen && !_dangThem && !_dangSua;
            btnThem.Enabled = coQuyen && !dangThaoTac;
            btnXoa.Enabled = coQuyen && !_dangThem;
            btnLuu.Enabled = coQuyen && dangThaoTac;
            btnHuy.Enabled = coQuyen && dangThaoTac;

            btnSaveImmediately.Enabled = true;
            btnImportFromFile.Enabled = coQuyen && !dangThaoTac;

            btnLamMoi.Enabled = true;
            btnExport.Enabled = true;

            txtMaPhong.ReadOnly = !_dangThem;
            txtTenPhong.ReadOnly = !dangThaoTac;
        }

        // Hiển thị danh sách phòng ban lên ListView.
        private void HienThiDanhSachPhongBan(string? maPhongBanCanChon = null)
        {
            lvPhongBan.BeginUpdate();
            lvPhongBan.Items.Clear();

            foreach (PhongBan pb in DSPhongBan)
            {
                int soNhanVien = DSNhanVien.Count(
                    nv => nv.MaPhongBan == pb.MaPhongBan
                );

                ListViewItem item = new ListViewItem(pb.MaPhongBan);
                item.SubItems.Add(pb.TenPhongBan);
                item.SubItems.Add(soNhanVien.ToString());

                lvPhongBan.Items.Add(item);

                if (pb.MaPhongBan == maPhongBanCanChon)
                {
                    item.Selected = true;
                    item.Focused = true;
                }
            }

            lvPhongBan.EndUpdate();
        }

        private void LamTrongThongTin()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
        }

        // Chọn phòng ban trên ListView.
        private void lvPhongBan_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_dangThem || _dangSua)
                return;

            if (lvPhongBan.SelectedItems.Count == 0)
            {
                LamTrongThongTin();
                return;
            }

            ListViewItem item = lvPhongBan.SelectedItems[0];

            txtMaPhong.Text = item.SubItems[0].Text;
            txtTenPhong.Text = item.SubItems[1].Text;
        }

        // Bắt đầu sửa phòng ban.
        private void btnUpdateDepartment_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
                return;

            if (lvPhongBan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListViewItem item = lvPhongBan.SelectedItems[0];

            _maPhongBanDangSua = item.SubItems[0].Text;

            PhongBan? pb = DSPhongBan.FirstOrDefault(
                x => x.MaPhongBan == _maPhongBanDangSua
            );

            if (pb == null)
                return;

            _tenPhongBanCu = pb.TenPhongBan;

            _dangSua = true;
            _dangThem = false;

            txtMaPhong.Text = pb.MaPhongBan;
            txtTenPhong.Text = pb.TenPhongBan;

            CapNhatTrangThaiNut();
            txtTenPhong.Focus();
        }

        // Bắt đầu thêm phòng ban.
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
                return;

            _dangThem = true;
            _dangSua = false;

            _maPhongBanDangSua = null;
            _tenPhongBanCu = null;

            lvPhongBan.SelectedItems.Clear();
            LamTrongThongTin();

            CapNhatTrangThaiNut();
            txtMaPhong.Focus();
        }

        // Lưu thao tác thêm hoặc sửa.
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
                return;

            if (!_dangThem && !_dangSua)
                return;

            string maPhongBan = txtMaPhong.Text.Trim();
            string tenPhongBan = txtTenPhong.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPhongBan))
            {
                MessageBox.Show("Mã phòng ban không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenPhongBan))
            {
                MessageBox.Show("Tên phòng ban không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }

            if (_dangThem)
            {
                bool daTonTai = DSPhongBan.Any(
                    pb => string.Equals(
                        pb.MaPhongBan,
                        maPhongBan,
                        StringComparison.OrdinalIgnoreCase
                    )
                );

                if (daTonTai)
                {
                    MessageBox.Show("Mã phòng ban đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPhong.Focus();
                    return;
                }

                DSPhongBan.Add(new PhongBan(maPhongBan, tenPhongBan));
            }
            else if (_dangSua)
            {
                PhongBan? pb = DSPhongBan.FirstOrDefault(
                    x => x.MaPhongBan == _maPhongBanDangSua
                );

                if (pb == null)
                {
                    MessageBox.Show("Không tìm thấy phòng ban cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    HuyThaoTac();
                    return;
                }

                // Giữ nguyên mã phòng ban, chỉ cập nhật tên.
                // Tạo đối tượng mới vì các property có private set.
                int index = DSPhongBan.IndexOf(pb);

                DSPhongBan[index] = new PhongBan(
                    pb.MaPhongBan,
                    tenPhongBan
                );
            }

            string? maPhongBanVuaLuu = _dangThem
                ? maPhongBan
                : _maPhongBanDangSua;

            _dangThem = false;
            _dangSua = false;
            _maPhongBanDangSua = null;
            _tenPhongBanCu = null;

            HienThiDanhSachPhongBan(maPhongBanVuaLuu);
            CapNhatTrangThaiNut();

            MessageBox.Show("Lưu thông tin phòng ban thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa phòng ban đang chọn hoặc đang sửa.
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
                return;

            // Không cho xóa khi đang thêm mới.
            if (_dangThem)
            {
                MessageBox.Show("Không thể xóa phòng ban khi đang thêm mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? maCanXoa = _dangSua
                ? _maPhongBanDangSua
                : lvPhongBan.SelectedItems.Count > 0
                    ? lvPhongBan.SelectedItems[0].SubItems[0].Text
                    : null;

            if (string.IsNullOrWhiteSpace(maCanXoa))
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhongBan? pb = DSPhongBan.FirstOrDefault(
                x => x.MaPhongBan == maCanXoa
            );

            if (pb == null)
            {
                MessageBox.Show("Không tìm thấy phòng ban cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không xóa phòng ban đang có nhân viên.
            bool coNhanVien = DSNhanVien.Any(
                nv => nv.MaPhongBan == maCanXoa
            );

            if (coNhanVien)
            {
                MessageBox.Show(
                    "Không thể xóa phòng ban này vì vẫn còn nhân viên thuộc phòng ban.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng ban '{pb.TenPhongBan}' ({pb.MaPhongBan}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            DSPhongBan.Remove(pb);

            _dangThem = false;
            _dangSua = false;
            _maPhongBanDangSua = null;
            _tenPhongBanCu = null;

            HienThiDanhSachPhongBan();
            LamTrongThongTin();
            CapNhatTrangThaiNut();

            MessageBox.Show("Đã xóa phòng ban thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hủy thêm hoặc sửa.
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
                return;

            if (!_dangThem && !_dangSua)
                return;

            HuyThaoTac();
        }

        private void HuyThaoTac()
        {
            string? maCanChon = _dangSua ? _maPhongBanDangSua : null;

            _dangThem = false;
            _dangSua = false;
            _maPhongBanDangSua = null;
            _tenPhongBanCu = null;

            HienThiDanhSachPhongBan(maCanChon);

            if (lvPhongBan.SelectedItems.Count > 0)
            {
                ListViewItem item = lvPhongBan.SelectedItems[0];
                txtMaPhong.Text = item.SubItems[0].Text;
                txtTenPhong.Text = item.SubItems[1].Text;
            }
            else
            {
                LamTrongThongTin();
            }

            CapNhatTrangThaiNut();
        }

        // Làm mới giao diện từ danh sách hiện tại.
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiDanhSachPhongBan();
            LamTrongThongTin();
        }

        // Lưu danh sách hiện tại vào Resources/DummyData/PhongBan.txt.
        private void btnSaveImmediately_Click(object sender, EventArgs e)
        {
            if (!CoQuyenHan())
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(
                    DuongDanFilePhongBan,
                    false,
                    Encoding.UTF8))
                {
                    foreach (PhongBan pb in DSPhongBan)
                    {
                        sw.WriteLine($"MaPhongBan: {pb.MaPhongBan}");
                        sw.WriteLine($"TenPhongBan: {pb.TenPhongBan}");
                        sw.WriteLine("---");
                    }
                }

                MessageBox.Show(
                    "Đã lưu danh sách phòng ban vào file thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể lưu file.\nChi tiết: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Import phòng ban từ file TXT được chọn.
        private void btnImportFromFile_Click(object sender, EventArgs e)
        {
            // Không cho import khi đang thêm hoặc sửa phòng ban
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
                dialog.Title = "Chọn file danh sách phòng ban";
                dialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string[] lines = File.ReadAllLines(dialog.FileName);

                    string? maPhongBan = null;
                    string? tenPhongBan = null;

                    int soLuongThem = 0;
                    int soLuongBoQua = 0;

                    // Kiểm tra mã phòng ban đã tồn tại
                    HashSet<string> maPhongBanDaCo = new HashSet<string>(
                        DSPhongBan.Select(pb => pb.MaPhongBan),
                        StringComparer.OrdinalIgnoreCase);

                    // Hàm xử lý từng bản ghi
                    void XuLyBanGhi()
                    {
                        if (string.IsNullOrWhiteSpace(maPhongBan) ||
                            string.IsNullOrWhiteSpace(tenPhongBan))
                        {
                            soLuongBoQua++;
                        }
                        else if (maPhongBanDaCo.Contains(maPhongBan))
                        {
                            // Bỏ qua mã phòng ban bị trùng
                            soLuongBoQua++;
                        }
                        else
                        {
                            DSPhongBan.Add(new PhongBan(
                                maPhongBan,
                                tenPhongBan));

                            maPhongBanDaCo.Add(maPhongBan);
                            soLuongThem++;
                        }

                        maPhongBan = null;
                        tenPhongBan = null;
                    }

                    foreach (string line in lines)
                    {
                        string dong = line.Trim();

                        // Gặp dấu phân cách thì xử lý bản ghi hiện tại
                        if (dong == "---")
                        {
                            if (maPhongBan != null || tenPhongBan != null)
                                XuLyBanGhi();

                            continue;
                        }

                        if (string.IsNullOrWhiteSpace(dong))
                            continue;

                        // Tách tại dấu ':' đầu tiên
                        string[] parts = dong.Split(new char[] { ':' }, 2);

                        if (parts.Length != 2)
                            continue;

                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        if (key.Equals("MaPhongBan", StringComparison.OrdinalIgnoreCase))
                            maPhongBan = value;
                        else if (key.Equals("TenPhongBan", StringComparison.OrdinalIgnoreCase))
                            tenPhongBan = value;
                    }

                    // Xử lý bản ghi cuối nếu file không có dấu --- ở cuối
                    if (maPhongBan != null || tenPhongBan != null)
                        XuLyBanGhi();

                    HienThiDanhSachPhongBan();
                    LamTrongThongTin();

                    MessageBox.Show(
                        $"Nhập file hoàn tất!\n" +
                        $"Số phòng ban được thêm: {soLuongThem}\n" +
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

        // Export danh sách phòng ban ra vị trí người dùng chọn.
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách phòng ban";
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.DefaultExt = "txt";
                sfd.AddExtension = true;
                sfd.FileName = "PhongBan.txt";
                sfd.OverwritePrompt = true;
                sfd.InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments
                );

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter sw = new StreamWriter(
                        sfd.FileName,
                        false,
                        Encoding.UTF8))
                    {
                        foreach (PhongBan pb in DSPhongBan)
                        {
                            sw.WriteLine($"MaPhongBan: {pb.MaPhongBan}");
                            sw.WriteLine($"TenPhongBan: {pb.TenPhongBan}");
                            sw.WriteLine("---");
                        }
                    }

                    MessageBox.Show(
                        $"Đã xuất {DSPhongBan.Count} phòng ban thành công.",
                        "Export",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể xuất file.\nChi tiết: {ex.Message}",
                        "Lỗi Export",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
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