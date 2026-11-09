using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;
using System.Linq;
using System.IO;
using System.Text;
using System.Globalization;
using System.Drawing;

namespace QuanLyNhanSu.Forms
{
    public partial class frmEmployee : Form
    {
        public frmEmployee(List<NhanVien> danhsachNV, List<ChucVu> danhsachCV, List<PhongBan> danhsachPB, SessionLogin sessionlogin)
        {
            InitializeComponent();
            DanhSachNhanVien = danhsachNV;
            DanhSachChucVu = danhsachCV;
            DanhSachPhongBan = danhsachPB;
            NVDangNhap = sessionlogin;
        }
        private readonly string nhanVienFilePath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "Resources","DummyData","NhanVien.txt"
        );

        public List<NhanVien> DanhSachNhanVien { get; private set; } = new List<NhanVien>();
        public List<ChucVu> DanhSachChucVu { get; private set; } = new List<ChucVu>();
        public List<PhongBan> DanhSachPhongBan { get; private set; } = new List<PhongBan>();
        public SessionLogin NVDangNhap { get; private set; } = new SessionLogin();

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            tvToChuc.Nodes.Clear();

            foreach (PhongBan pb in DanhSachPhongBan)
            {
                TreeNode nodePB = new TreeNode(pb.TenPhongBan);
                nodePB.Tag = pb;

                foreach (NhanVien nv in DanhSachNhanVien)
                {
                    if (nv.MaPhongBan == pb.MaPhongBan)
                    {
                        TreeNode nodeNV = new TreeNode(nv.TenNhanVien);
                        // Lưu trực tiếp đối tượng nhân viên
                        nodeNV.Tag = nv;
                        nodePB.Nodes.Add(nodeNV);
                    }
                }
                tvToChuc.Nodes.Add(nodePB);
            }

            //nạp data lên xem
            cboChucVu.Items.Clear();
            cboLocPhong.Items.Clear();
            cboPhongBanInfo.Items.Clear();
            cboGioiTinh.Items.Clear();

            foreach (ChucVu cv in DanhSachChucVu)
            {
                cboChucVu.Items.Add(cv.TenChucVu);
            }
            cboGioiTinh.Items.Add("Nam"); cboGioiTinh.Items.Add("Nữ");
            foreach (PhongBan pb in DanhSachPhongBan)
            {
                cboPhongBanInfo.Items.Add(pb.TenPhongBan);
                cboLocPhong.Items.Add(pb.TenPhongBan);
            }

            //rbac
            if (NVDangNhap.nvDangNhapQuyenHan)
            {
                btnDoiAnh.Enabled = true;
                btnXoaAnh.Enabled = true;
                btnThem.Enabled = true;
                btnUpdateNhanVien.Enabled = true;
                btnXoa.Enabled = true;
                btnSaveImediately.Enabled = true;
            }
            else
            {
                btnDoiAnh.Enabled = false;
                btnXoaAnh.Enabled = false;
                btnThem.Enabled = false;
                btnUpdateNhanVien.Enabled = false;
                btnXoa.Enabled = false;
                btnSaveImediately.Enabled = false;
            }
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = true;
            btnTimKiem.Enabled = true;
        }

        private void tvToChuc_AfterSelection(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is NhanVien nv)
            {
                HienTTLenTxtBox(nv);
            }
            else
            {
                XoaTTKhoiTxtBox();
            }
        }
        private void HienTTLenTxtBox(NhanVien nv)
        {
            txtMaNV.Text = nv.MaNhanVien;
            txtHoTen.Text = nv.TenNhanVien;
            cboGioiTinh.Text = nv.GioiTinh;
            dtpNgaySinh.Value = nv.NgaySinh ?? DateTime.Today;
            txtLuong.Text = nv.LuongCoBan?.ToString("N0") ?? "0";
            nudPhepNam.Value = nv.SoNgayNghiPhep ?? 1;

            PhongBan? pb = DanhSachPhongBan.FirstOrDefault(x => x.MaPhongBan == nv.MaPhongBan);
            cboPhongBanInfo.Text = pb?.TenPhongBan ?? "";
            ChucVu? cv = DanhSachChucVu.FirstOrDefault(x => x.MaChucVu == nv.MaChucVu);
            cboChucVu.Text = cv?.TenChucVu ?? "";
            picAnh.Image = nv.AnhNhanVien;
        }

        private void XoaTTKhoiTxtBox()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();

            cboGioiTinh.SelectedIndex = -1;
            cboPhongBanInfo.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;

            dtpNgaySinh.Value = DateTime.Today;

            nudPhepNam.Value = 0;
            picAnh.Image = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtHoTen.ReadOnly = false;
            cboGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDienThoai.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            cboPhongBanInfo.Enabled = true;
            cboChucVu.Enabled = true;
            txtLuong.ReadOnly = false;

            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboPhongBanInfo.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Today;
            nudPhepNam.Value = 0;
            picAnh.Image = null;

            btnLuu.Enabled = true;
        }

        private void btnUpdateNhanVien_Click(object sender, EventArgs e)
        {
            txtHoTen.ReadOnly = false;
            cboGioiTinh.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDienThoai.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            cboPhongBanInfo.Enabled = true;
            cboChucVu.Enabled = true;
            txtLuong.ReadOnly = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || txtHoTen.Text.Any(c => !char.IsLetter(c) && c != ' '))
            {
                MessageBox.Show("Hãy khai báo Họ tên hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (cboGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn giới tính", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDienThoai.Text) || txtDienThoai.Text.Any(c => c < '0' || c > '9'))
            {
                MessageBox.Show("Hãy nhập số điện thoại hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text.IndexOf('@') == -1 ||
                !txtEmail.Text.Substring(txtEmail.Text.IndexOf('@') + 1).Contains('.'))
            {
                MessageBox.Show("Hãy nhập Email hợp lệ");
                txtEmail.Focus();
                return;
            }
            if (cboPhongBanInfo.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn phòng ban", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhongBanInfo.Focus();
                return;
            }
            if (cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }
            decimal luong = 0;
            if (!decimal.TryParse(txtLuong.Text, out luong))
            {
                MessageBox.Show("Hãy nhập mức lương hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return;
            }
            string name = txtHoTen.Text;
            string gender = cboGioiTinh.SelectedItem?.ToString() ?? "";
            string phonenum = txtDienThoai.Text;
            string email = txtEmail.Text;
            string phongban = cboPhongBanInfo.SelectedItem?.ToString() ?? "";
            string maphongban = "";
            foreach (PhongBan pb in DanhSachPhongBan)
            {
                if (pb.TenPhongBan == phongban)
                {
                    maphongban = pb.MaPhongBan;
                }
            }
            string chucvu = cboChucVu.SelectedItem?.ToString() ?? "";
            string machucvu = "";
            foreach (ChucVu cv in DanhSachChucVu)
            {
                if (cv.TenChucVu == chucvu)
                {
                    machucvu = cv.MaChucVu;
                }
            }
            DateTime ngaysinh = dtpNgaySinh.Value;
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                NhanVien newnv = new NhanVien();
                newnv.UpdateNhanVien(name, gender, ngaysinh, machucvu, maphongban, luong, phonenum, email, txtDiaChi.Text);
                int maxMaNV = DanhSachNhanVien.Select(nv => int.Parse(nv.MaNhanVien.Substring(3))).Max() + 1;
                string newMaNV = "MNV0" + maxMaNV.ToString();
                newnv.initMaNhanVien(newMaNV);
                DanhSachNhanVien.Add(newnv);
            }
            else
            {
                foreach (NhanVien nv in DanhSachNhanVien)
                {
                    if (nv.MaNhanVien == txtMaNV.Text)
                    {
                        nv.UpdateNhanVien(name, gender, ngaysinh, machucvu, maphongban, luong, phonenum, email, txtDiaChi.Text);
                    }
                }
            }
            //lưu xong khóa lại
            if (NVDangNhap.nvDangNhapQuyenHan)
            {
                btnDoiAnh.Enabled = true;
                btnXoaAnh.Enabled = true;
                btnThem.Enabled = true;
                btnUpdateNhanVien.Enabled = true;
                btnXoa.Enabled = true;
                btnSaveImediately.Enabled = true;
            }
            else
            {
                btnDoiAnh.Enabled = false;
                btnXoaAnh.Enabled = false;
                btnThem.Enabled = false;
                btnUpdateNhanVien.Enabled = false;
                btnXoa.Enabled = false;
                btnSaveImediately.Enabled = false;
            }
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = true;
            btnTimKiem.Enabled = true;

            txtHoTen.ReadOnly = true;
            cboGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            cboPhongBanInfo.Enabled = false;
            cboChucVu.Enabled = false;
            txtLuong.ReadOnly = true;
        }

        private void cboLocPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocPhong.SelectedItem == null)
                return;

            string tenPhongBanLoc = cboLocPhong.SelectedItem?.ToString() ?? "";

            string? maPhongBanLoc = DanhSachPhongBan
                .FirstOrDefault(pb => pb.TenPhongBan == tenPhongBanLoc)?.MaPhongBan;

            lvNhanVien.Items.Clear();

            foreach (NhanVien nv in DanhSachNhanVien)
            {
                if (nv.MaPhongBan == maPhongBanLoc)
                {
                    ListViewItem item = new ListViewItem(nv.MaNhanVien);
                    item.SubItems.Add(nv.TenNhanVien ?? "");
                    item.SubItems.Add(nv.GioiTinh ?? "");
                    item.SubItems.Add(nv.NgaySinh?.ToString("dd-MM-yyyy") ?? "");
                    item.SubItems.Add(nv.DienThoai ?? "");
                    item.SubItems.Add(nv.MaPhongBan ?? "");
                    item.SubItems.Add(nv.MaChucVu ?? "");
                    item.SubItems.Add(nv.LuongCoBan?.ToString("N0") ?? "");

                    lvNhanVien.Items.Add(item);
                }
            }
        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
                return;

            // Lấy mã nhân viên từ cột đầu tiên của item được chọn
            string maNV = lvNhanVien.SelectedItems[0].SubItems[0].Text;

            // Tìm nhân viên trong danh sách
            NhanVien? nv = DanhSachNhanVien
                .FirstOrDefault(nv => nv.MaNhanVien == maNV);

            if (nv == null)
                return;

            // Đổ dữ liệu vào các controller
            txtMaNV.Text = nv.MaNhanVien;
            txtHoTen.Text = nv.TenNhanVien ?? "";
            cboGioiTinh.Text = nv.GioiTinh ?? "";
            dtpNgaySinh.Value = nv.NgaySinh ?? DateTime.Today;
            txtDienThoai.Text = nv.DienThoai ?? "";
            txtEmail.Text = nv.Email ?? "";
            txtDiaChi.Text = nv.DiaChi ?? "";
            cboPhongBanInfo.SelectedValue = nv.MaPhongBan ?? "";
            cboChucVu.SelectedValue = nv.MaChucVu ?? "";
            txtLuong.Text = nv.LuongCoBan?.ToString("0.##") ?? "";

            // Hiển thị ảnh nhân viên
            picAnh.Image = nv.AnhNhanVien ?? null;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboPhongBanInfo.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Today;
            nudPhepNam.Value = 0;
            picAnh.Image = null;

            btnLuu.Enabled = true;

            //hủy xong khóa lại
            if (NVDangNhap.nvDangNhapQuyenHan)
            {
                btnDoiAnh.Enabled = true;
                btnXoaAnh.Enabled = true;
                btnThem.Enabled = true;
                btnUpdateNhanVien.Enabled = true;
                btnXoa.Enabled = true;
                btnSaveImediately.Enabled = true;
            }
            else
            {
                btnDoiAnh.Enabled = false;
                btnXoaAnh.Enabled = false;
                btnThem.Enabled = false;
                btnUpdateNhanVien.Enabled = false;
                btnXoa.Enabled = false;
                btnSaveImediately.Enabled = false;
            }
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = true;
            btnTimKiem.Enabled = true;

            txtHoTen.ReadOnly = true;
            cboGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            cboPhongBanInfo.Enabled = false;
            cboChucVu.Enabled = false;
            txtLuong.ReadOnly = true;
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            foreach (NhanVien nv in DanhSachNhanVien)
            {
                if (nv.MaNhanVien == txtMaNV.Text)
                {
                    nv.RemoveAnhNV();
                    picAnh.Image = null;
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Làm mới TreeView tổ chức
            tvToChuc.BeginUpdate();
            tvToChuc.Nodes.Clear();

            foreach (PhongBan pb in DanhSachPhongBan)
            {
                TreeNode nodePB = new TreeNode(pb.TenPhongBan ?? "");
                nodePB.Tag = pb;

                foreach (NhanVien nv in DanhSachNhanVien)
                {
                    if (nv.MaPhongBan == pb.MaPhongBan)
                    {
                        TreeNode nodeNV = new TreeNode(nv.TenNhanVien ?? "");
                        nodeNV.Tag = nv;
                        nodePB.Nodes.Add(nodeNV);
                    }
                }

                tvToChuc.Nodes.Add(nodePB);
            }

            tvToChuc.EndUpdate();

            // 2. Làm mới ComboBox chức vụ
            cboChucVu.Items.Clear();

            foreach (ChucVu cv in DanhSachChucVu)
            {
                cboChucVu.Items.Add(cv.TenChucVu);
            }

            // 3. Làm mới ComboBox phòng ban và bộ lọc phòng ban
            cboPhongBanInfo.Items.Clear();
            cboLocPhong.Items.Clear();

            foreach (PhongBan pb in DanhSachPhongBan)
            {
                cboPhongBanInfo.Items.Add(pb.TenPhongBan);
                cboLocPhong.Items.Add(pb.TenPhongBan);
            }

            // 4. Làm mới ComboBox giới tính
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            // 5. Làm mới ListView nhân viên
            lvNhanVien.BeginUpdate();
            lvNhanVien.Items.Clear();

            foreach (NhanVien nv in DanhSachNhanVien)
            {
                ListViewItem item = new ListViewItem(nv.MaNhanVien);
                item.SubItems.Add(nv.TenNhanVien ?? "");
                item.SubItems.Add(nv.GioiTinh ?? "");
                item.SubItems.Add(nv.NgaySinh?.ToString("dd-MM-yyyy") ?? "");
                item.SubItems.Add(nv.DienThoai ?? "");
                item.SubItems.Add(nv.MaPhongBan ?? "");
                item.SubItems.Add(nv.MaChucVu ?? "");
                item.SubItems.Add(nv.LuongCoBan?.ToString("N0") ?? "");

                lvNhanVien.Items.Add(item);
            }

            lvNhanVien.EndUpdate();

            // 6. Xóa thông tin đang hiển thị trên các control
            XoaTTKhoiTxtBox();

            // 7. Đặt lại bộ lọc phòng ban
            cboLocPhong.SelectedIndex = -1;

            // 8. Khóa các control nhập liệu
            txtHoTen.ReadOnly = true;
            cboGioiTinh.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            cboPhongBanInfo.Enabled = false;
            cboChucVu.Enabled = false;
            txtLuong.ReadOnly = true;

            // 9. Khôi phục trạng thái nút theo quyền
            btnDoiAnh.Enabled = NVDangNhap.nvDangNhapQuyenHan;
            btnXoaAnh.Enabled = NVDangNhap.nvDangNhapQuyenHan;
            btnThem.Enabled = NVDangNhap.nvDangNhapQuyenHan;
            btnUpdateNhanVien.Enabled = NVDangNhap.nvDangNhapQuyenHan;
            btnXoa.Enabled = NVDangNhap.nvDangNhapQuyenHan;
            btnSaveImediately.Enabled = NVDangNhap.nvDangNhapQuyenHan;

            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnLamMoi.Enabled = true;
            btnTimKiem.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int countsuccess = 0;
            foreach (NhanVien nv in DanhSachNhanVien)
            {
                if (nv.TenNhanVien == txtTimKiem.Text)
                {
                    HienTTLenTxtBox(nv);
                    countsuccess++;
                }
            }
            if (countsuccess == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveImediately_Click(object sender, EventArgs e)
        {
            LuuDanhSachNhanVien();
        }
        private void LuuDanhSachNhanVien()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(
                    nhanVienFilePath, false, Encoding.UTF8))
                {
                    foreach (NhanVien nv in DanhSachNhanVien)
                    {
                        sw.WriteLine($"MaNhanVien: {nv.MaNhanVien}");
                        sw.WriteLine($"TenNhanVien: {nv.TenNhanVien}");
                        sw.WriteLine($"GioiTinh: {nv.GioiTinh}");
                        sw.WriteLine($"NgaySinh: {nv.NgaySinh:dd/MM/yyyy}");
                        sw.WriteLine($"MaChucVu: {nv.MaChucVu}");
                        sw.WriteLine($"MaPhongBan: {nv.MaPhongBan}");
                        sw.WriteLine($"MaTaiKhoan: {nv.MaTaiKhoan}");
                        sw.WriteLine($"SoNgayNghiPhep: {nv.SoNgayNghiPhep}");
                        sw.WriteLine(
                            $"LuongCoBan: {nv.LuongCoBan?.ToString(CultureInfo.InvariantCulture) ?? "0"}");

                        // Lưu đường dẫn ảnh, không ghi trực tiếp dữ liệu ảnh vào file TXT.
                        // Cần điều chỉnh theo cách lớp NhanVien quản lý ảnh hiện tại.
                        sw.WriteLine($"AnhNhanVien: {nv.DuongDanAnh}");

                        sw.WriteLine($"DienThoai: {nv.DienThoai}");
                        sw.WriteLine($"Email: {nv.Email}");
                        sw.WriteLine($"DiaChi: {nv.DiaChi}");
                        sw.WriteLine("---");
                    }
                }

                MessageBox.Show(
                    "Đã lưu danh sách nhân viên thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi lưu danh sách nhân viên: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            // Tìm nhân viên đang được chọn
            NhanVien? nv = DanhSachNhanVien.FirstOrDefault(
                x => x.MaNhanVien == txtMaNV.Text
            );

            if (nv == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi đổi ảnh.");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh nhân viên";
                ofd.Filter =
                    "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                ofd.Multiselect = false;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                // Cho phép người dùng duyệt từ thư mục mặc định
                // đến các ổ đĩa và thư mục khác trên thiết bị.
                ofd.InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyPictures
                );

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    // Đường dẫn thư mục Resources/Image có sẵn trong ứng dụng
                    string imageFolder = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Resources",
                        "Image"
                    );

                    // Lấy phần mở rộng của ảnh đã chọn
                    string extension = Path.GetExtension(ofd.FileName);

                    // Đặt tên ảnh theo mã nhân viên
                    string fileName = nv.MaNhanVien + extension;

                    string destinationPath = Path.Combine(
                        imageFolder,
                        fileName
                    );

                    // Sao chép ảnh vào thư mục có sẵn, ghi đè nếu trùng tên
                    File.Copy(ofd.FileName, destinationPath, true);

                    // Lưu đường dẫn tương đối
                    string relativePath = Path.Combine(
                        "Resources",
                        "Image",
                        fileName
                    );

                    // Cập nhật ảnh nhân viên
                    nv.UpdateAnhNV(relativePath);

                    // Hiển thị ảnh mới
                    picAnh.Image = nv.AnhNhanVien;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể đổi ảnh nhân viên.\nChi tiết: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file dữ liệu nhân viên";
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                int soNhanVienDaNap = 0;
                int soBanGhiBiBoQua = 0;

                // biến tạm cho 1 entry
                string maNhanVien = "";
                string tenNhanVien = "";
                string gioiTinh = "";
                DateTime ngaySinh = DateTime.MinValue;
                string maChucVu = "";
                string maPhongBan = "";
                string maTaiKhoanNV = "";
                int soNgayNghiPhep = 0;
                decimal luongCoBan = 0;
                string duongDanAnh = "";
                string dienThoai = "";
                string email = "";
                string diaChi = "";

                int requiredIndicator = 0;  // đếm 10 trường bắt buộc (constructor simple)
                int contactIndicator = 0;   // đếm 3 trường liên hệ (constructor full)
                bool recordHopLe = true;    // false nếu parse số/ngày lỗi

                const int SO_TRUONG_BAT_BUOC = 10;
                const int SO_TRUONG_LIEN_HE = 3;

                string LayGiaTri(string line, string prefix) => line.Substring(prefix.Length).Trim();

                void ResetBanGhi()
                {
                    maNhanVien = "";
                    tenNhanVien = "";
                    gioiTinh = "";
                    ngaySinh = DateTime.MinValue;
                    maChucVu = "";
                    maPhongBan = "";
                    maTaiKhoanNV = "";
                    soNgayNghiPhep = 0;
                    luongCoBan = 0;
                    duongDanAnh = "";
                    dienThoai = "";
                    email = "";
                    diaChi = "";
                    requiredIndicator = 0;
                    contactIndicator = 0;
                    recordHopLe = true;
                }

                void XuLyBanGhi()
                {
                    try
                    {
                        // entry rỗng (vd: hai dòng --- liền nhau) -> bỏ qua, không tính là lỗi
                        if (requiredIndicator == 0 && contactIndicator == 0 && recordHopLe)
                            return;

                        // sai định dạng, thiếu hoặc dư trường bắt buộc, hoặc có trường rỗng
                        if (!recordHopLe
                            || requiredIndicator != SO_TRUONG_BAT_BUOC
                            || string.IsNullOrWhiteSpace(maNhanVien)
                            || string.IsNullOrWhiteSpace(tenNhanVien)
                            || string.IsNullOrWhiteSpace(gioiTinh)
                            || string.IsNullOrWhiteSpace(maChucVu)
                            || string.IsNullOrWhiteSpace(maPhongBan)
                            || string.IsNullOrWhiteSpace(maTaiKhoanNV)
                            || string.IsNullOrWhiteSpace(duongDanAnh))
                        {
                            soBanGhiBiBoQua++;
                            return;
                        }

                        // trùng mã nhân viên
                        if (DanhSachNhanVien.Any(nv => nv.MaNhanVien == maNhanVien))
                        {
                            soBanGhiBiBoQua++;
                            return;
                        }

                        // file ảnh không tồn tại
                        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanAnh)))
                        {
                            soBanGhiBiBoQua++;
                            return;
                        }

                        NhanVien nv;
                        if (contactIndicator == SO_TRUONG_LIEN_HE)
                        {
                            // đủ 13 trường -> constructor full
                            nv = new NhanVien(maNhanVien, tenNhanVien, gioiTinh, ngaySinh, maChucVu,
                                maPhongBan, maTaiKhoanNV, soNgayNghiPhep, luongCoBan, duongDanAnh,
                                dienThoai, email, diaChi);
                        }
                        else
                        {
                            // thiếu trường liên hệ -> fallback constructor simple
                            nv = new NhanVien(maNhanVien, tenNhanVien, gioiTinh, ngaySinh, maChucVu,
                                maPhongBan, maTaiKhoanNV, soNgayNghiPhep, luongCoBan, duongDanAnh);
                        }

                        DanhSachNhanVien.Add(nv);
                        soNhanVienDaNap++;
                    }
                    catch
                    {
                        // constructor lỗi (vd: Image.FromFile) -> bỏ qua entry
                        soBanGhiBiBoQua++;
                    }
                    finally
                    {
                        ResetBanGhi(); // luôn reset dù add hay skip
                    }
                }

                try
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        string? line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Trim() == "---")
                            {
                                XuLyBanGhi();
                            }
                            else if (line.StartsWith("MaNhanVien: "))
                            {
                                requiredIndicator++;
                                maNhanVien = LayGiaTri(line, "MaNhanVien: ");
                            }
                            else if (line.StartsWith("TenNhanVien: "))
                            {
                                requiredIndicator++;
                                tenNhanVien = LayGiaTri(line, "TenNhanVien: ");
                            }
                            else if (line.StartsWith("GioiTinh: "))
                            {
                                requiredIndicator++;
                                gioiTinh = LayGiaTri(line, "GioiTinh: ");
                            }
                            else if (line.StartsWith("NgaySinh: "))
                            {
                                requiredIndicator++;
                                if (!DateTime.TryParse(LayGiaTri(line, "NgaySinh: "), out ngaySinh))
                                    recordHopLe = false;
                            }
                            else if (line.StartsWith("MaChucVu: "))
                            {
                                requiredIndicator++;
                                maChucVu = LayGiaTri(line, "MaChucVu: ");
                            }
                            else if (line.StartsWith("MaPhongBan: "))
                            {
                                requiredIndicator++;
                                maPhongBan = LayGiaTri(line, "MaPhongBan: ");
                            }
                            else if (line.StartsWith("MaTaiKhoan: "))
                            {
                                requiredIndicator++;
                                maTaiKhoanNV = LayGiaTri(line, "MaTaiKhoan: ");
                            }
                            else if (line.StartsWith("SoNgayNghiPhep: "))
                            {
                                requiredIndicator++;
                                if (!int.TryParse(LayGiaTri(line, "SoNgayNghiPhep: "), out soNgayNghiPhep))
                                    recordHopLe = false;
                            }
                            else if (line.StartsWith("LuongCoBan: "))
                            {
                                requiredIndicator++;
                                if (!decimal.TryParse(LayGiaTri(line, "LuongCoBan: "), out luongCoBan))
                                    recordHopLe = false;
                            }
                            else if (line.StartsWith("AnhNhanVien: "))
                            {
                                requiredIndicator++;
                                duongDanAnh = LayGiaTri(line, "AnhNhanVien: ");
                            }
                            else if (line.StartsWith("DienThoai: "))
                            {
                                contactIndicator++;
                                dienThoai = LayGiaTri(line, "DienThoai: ");
                            }
                            else if (line.StartsWith("Email: "))
                            {
                                contactIndicator++;
                                email = LayGiaTri(line, "Email: ");
                            }
                            else if (line.StartsWith("DiaChi: "))
                            {
                                contactIndicator++;
                                diaChi = LayGiaTri(line, "DiaChi: ");
                            }
                        }

                        // entry cuối không có --- ở cuối file
                        if (requiredIndicator > 0 || contactIndicator > 0 || !recordHopLe)
                            XuLyBanGhi();
                    }

                    // dgvNhanVien.DataSource = null;
                    // dgvNhanVien.DataSource = DanhSachNhanVien;

                    MessageBox.Show(
                        $"Nạp file hoàn tất.\n" +
                        $"Số nhân viên đã nạp: {soNhanVienDaNap}\n" +
                        $"Số bản ghi bị bỏ qua: {soBanGhiBiBoQua}",
                        "Kết quả nạp dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể đọc file dữ liệu.\nChi tiết: {ex.Message}",
                        "Lỗi đọc file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất danh sách nhân viên";
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.DefaultExt = "txt";
                sfd.AddExtension = true;
                sfd.FileName = "NhanVien.txt";
                sfd.OverwritePrompt = true;

                // Thư mục mở đầu tiên, người dùng vẫn có thể chọn nơi khác.
                sfd.InitialDirectory = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments
                );

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter sw = new StreamWriter(
                        sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        foreach (NhanVien nv in DanhSachNhanVien)
                        {
                            sw.WriteLine($"MaNhanVien: {nv.MaNhanVien}");
                            sw.WriteLine($"TenNhanVien: {nv.TenNhanVien}");
                            sw.WriteLine($"GioiTinh: {nv.GioiTinh}");
                            sw.WriteLine($"NgaySinh: {nv.NgaySinh:dd/MM/yyyy}");
                            sw.WriteLine($"MaChucVu: {nv.MaChucVu}");
                            sw.WriteLine($"MaPhongBan: {nv.MaPhongBan}");
                            sw.WriteLine($"MaTaiKhoan: {nv.MaTaiKhoan}");
                            sw.WriteLine($"SoNgayNghiPhep: {nv.SoNgayNghiPhep}");
                            sw.WriteLine($"LuongCoBan: {nv.LuongCoBan}");
                            sw.WriteLine($"AnhNhanVien: {nv.DuongDanAnh}");

                            sw.WriteLine($"DienThoai: {nv.DienThoai}");
                            sw.WriteLine($"Email: {nv.Email}");
                            sw.WriteLine($"DiaChi: {nv.DiaChi}");

                            sw.WriteLine("---");
                        }
                    }

                    MessageBox.Show(
                        $"Đã xuất {DanhSachNhanVien.Count} nhân viên thành công.",
                        "Xuất dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể xuất dữ liệu.\nChi tiết: {ex.Message}",
                        "Lỗi xuất file",
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
                e.Cancel = true;   // huỷ việc đóng
                this.Hide();       // chỉ ẩn đi
            }
        }
    }
}
