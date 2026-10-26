using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;
using System.Linq;

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

            string tenPhongBanLoc = cboLocPhong.SelectedItem.ToString();

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
    }
}
