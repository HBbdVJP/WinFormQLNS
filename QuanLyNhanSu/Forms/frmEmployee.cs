using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// Màn hình Quản lý hồ sơ nhân viên.
    /// Trái: TreeView sơ đồ tổ chức. Phải: bộ lọc, thông tin chi tiết, danh sách nhân viên.
    /// </summary>
    public partial class frmEmployee : Form
    {
        private enum CheDo { Xem, Them, Sua }

        private readonly ToolTip toolTip = new ToolTip();

        private CheDo cheDo = CheDo.Xem;
        private NhanVien dangChon;
        private string anhTam;

        public frmEmployee()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------
        // Khởi động
        // ------------------------------------------------------------------
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Đang làm", "Đã nghỉ" });

            NapComboBoxPhongBan();
            NapComboBoxChucVu();
            NapCayToChuc();

            cboLocPhong.SelectedIndex = 0;
            HienThiNhanVien(null);
            DatCheDo(CheDo.Xem);

            CotDanhSach.VuaTieuDe(lvNhanVien);
        }

        private void NapComboBoxPhongBan()
        {
            cboPhongBanInfo.Items.Clear();
            foreach (PhongBan p in Store.Data.PhongBans)
            {
                cboPhongBanInfo.Items.Add(p);
            }

            cboLocPhong.Items.Clear();
            cboLocPhong.Items.Add("-- Tất cả phòng ban --");
            foreach (PhongBan p in Store.Data.PhongBans)
            {
                cboLocPhong.Items.Add(p);
            }
        }

        private void NapComboBoxChucVu()
        {
            cboChucVu.Items.Clear();
            foreach (ChucVu c in Store.Data.ChucVus)
            {
                cboChucVu.Items.Add(c);
            }
        }

        /// <summary>Dựng lại TreeView sơ đồ tổ chức: Công ty -> Phòng ban -> Nhân viên.</summary>
        private void NapCayToChuc()
        {
            tvToChuc.BeginUpdate();
            tvToChuc.Nodes.Clear();

            TreeNode goc = new TreeNode("CÔNG TY");
            goc.Tag = null;
            tvToChuc.Nodes.Add(goc);

            foreach (PhongBan p in Store.Data.PhongBans)
            {
                TreeNode nutPhong = new TreeNode(string.Format("{0} ({1})", p.TenPhong, p.MaPhong));
                nutPhong.Tag = p;

                foreach (NhanVien nv in Store.Data.NhanViens)
                {
                    if (nv.MaPhong == p.MaPhong)
                    {
                        TreeNode nutNV = new TreeNode(string.Format("{0} - {1}", nv.MaNV, nv.HoTen));
                        nutNV.Tag = nv;
                        nutPhong.Nodes.Add(nutNV);
                    }
                }

                goc.Nodes.Add(nutPhong);
            }

            goc.Expand();
            tvToChuc.EndUpdate();
            tvToChuc.SelectedNode = goc;
        }

        // ------------------------------------------------------------------
        // Danh sách nhân viên
        // ------------------------------------------------------------------
        private void NapDanhSachNhanVien()
        {
            string maPhong = "";
            PhongBan p = cboLocPhong.SelectedItem as PhongBan;
            if (p != null)
            {
                maPhong = p.MaPhong;
            }

            string tuKhoa = txtTimKiem.Text.Trim();

            lvNhanVien.BeginUpdate();
            lvNhanVien.Items.Clear();

            foreach (NhanVien nv in Store.Data.NhanViens)
            {
                if (!string.IsNullOrEmpty(maPhong) && nv.MaPhong != maPhong)
                {
                    continue;
                }

                if (tuKhoa.Length > 0
                    && nv.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) < 0
                    && nv.MaNV.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                ListViewItem item = new ListViewItem(nv.MaNV);
                item.SubItems.Add(nv.HoTen);
                item.SubItems.Add(nv.GioiTinh);
                item.SubItems.Add(nv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.DienThoai);
                item.SubItems.Add(NghiepVu.TenPhong(nv.MaPhong));
                item.SubItems.Add(NghiepVu.TenChucVu(nv.MaChucVu));
                item.SubItems.Add(nv.LuongCoBan.ToString("#,##0"));
                item.SubItems.Add(NghiepVu.TenTrangThaiLamViec(nv.TrangThai));
                item.Tag = nv;

                lvNhanVien.Items.Add(item);
            }

            lvNhanVien.EndUpdate();
        }

        /// <summary>Hiển thị thông tin nhân viên lên các ô nhập liệu bên phải.</summary>
        private void HienThiNhanVien(NhanVien nv)
        {
            dangChon = nv;

            if (nv == null)
            {
                txtMaNV.Text = "";
                txtHoTen.Text = "";
                cboGioiTinh.SelectedIndex = -1;
                dtpNgaySinh.Value = DateTime.Today;
                txtDienThoai.Text = "";
                txtEmail.Text = "";
                txtDiaChi.Text = "";
                cboPhongBanInfo.SelectedIndex = -1;
                cboChucVu.SelectedIndex = -1;
                dtpNgayVaoLam.Value = DateTime.Today;
                txtLuong.Text = "";
                nudPhepNam.Value = 12;
                cboTrangThai.SelectedIndex = 0;
                picAnh.Image = null;
                anhTam = null;
                XoaLoi();
                return;
            }

            txtMaNV.Text = nv.MaNV;
            txtHoTen.Text = nv.HoTen;
            cboGioiTinh.SelectedItem = nv.GioiTinh;
            if (cboGioiTinh.SelectedIndex < 0)
            {
                cboGioiTinh.Text = nv.GioiTinh;
            }

            dtpNgaySinh.Value = nv.NgaySinh < dtpNgaySinh.MinDate ? dtpNgaySinh.MinDate : nv.NgaySinh;
            txtDienThoai.Text = nv.DienThoai;
            txtEmail.Text = nv.Email;
            txtDiaChi.Text = nv.DiaChi;

            ChonTheoMaPhong(cboPhongBanInfo, nv.MaPhong);
            ChonTheoMaChucVu(cboChucVu, nv.MaChucVu);

            dtpNgayVaoLam.Value = nv.NgayVaoLam < dtpNgayVaoLam.MinDate ? dtpNgayVaoLam.MinDate : nv.NgayVaoLam;
            txtLuong.Text = nv.LuongCoBan.ToString("#,##0");
            nudPhepNam.Value = nv.PhepNam;
            cboTrangThai.SelectedIndex = nv.TrangThai == TrangThaiLamViec.DangLam ? 0 : 1;

            picAnh.Image = HinhAnh.TuBase64(nv.AnhBase64);
            if (picAnh.Image == null)
            {
                picAnh.Image = HinhAnh.TaoAnhDaiDien(nv.HoTen, TuyChinh.MauChinh, 128);
            }

            anhTam = nv.AnhBase64;
            XoaLoi();
        }

        private void ChonTheoMaPhong(ComboBox cbo, string maPhong)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                PhongBan p = cbo.Items[i] as PhongBan;
                if (p != null && p.MaPhong == maPhong)
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }

            cbo.SelectedIndex = -1;
        }

        private void ChonTheoMaChucVu(ComboBox cbo, string maChucVu)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                ChucVu c = cbo.Items[i] as ChucVu;
                if (c != null && c.MaChucVu == maChucVu)
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }

            cbo.SelectedIndex = -1;
        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
            {
                return;
            }

            NhanVien nv = lvNhanVien.SelectedItems[0].Tag as NhanVien;
            if (nv != null && cheDo == CheDo.Xem)
            {
                HienThiNhanVien(nv);
            }
        }

        // ------------------------------------------------------------------
        // Bộ lọc
        // ------------------------------------------------------------------
        private void cboLocPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            NapDanhSachNhanVien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NapDanhSachNhanVien();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NapDanhSachNhanVien();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // ------------------------------------------------------------------
        // TreeView sơ đồ tổ chức
        // ------------------------------------------------------------------
        private void tvToChuc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || cheDo != CheDo.Xem)
            {
                return;
            }

            PhongBan p = e.Node.Tag as PhongBan;
            if (p != null)
            {
                ChonTheoMaPhong(cboLocPhong, p.MaPhong);
                NapDanhSachNhanVien();
                return;
            }

            NhanVien nv = e.Node.Tag as NhanVien;
            if (nv != null)
            {
                ChonTheoMaPhong(cboLocPhong, nv.MaPhong);
                NapDanhSachNhanVien();

                foreach (ListViewItem item in lvNhanVien.Items)
                {
                    NhanVien x = item.Tag as NhanVien;
                    if (x != null && x.MaNV == nv.MaNV)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }
        }

        // ------------------------------------------------------------------
        // Ảnh nhân viên
        // ------------------------------------------------------------------
        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            if (!DuocPhepNhap())
            {
                return;
            }

            if (openFileDialogAnh.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using (Image goc = Image.FromFile(openFileDialogAnh.FileName))
                {
                    using (Image vua = HinhAnh.VuaKhung(goc, new Size(320, 320)))
                    {
                        picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        picAnh.Image = new Bitmap(vua);
                        anhTam = HinhAnh.SangBase64(picAnh.Image);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được tập tin ảnh: " + ex.Message, "Lỗi ảnh",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            if (!DuocPhepNhap())
            {
                return;
            }

            picAnh.Image = null;
            anhTam = null;
        }

        // ------------------------------------------------------------------
        // Nhập liệu
        // ------------------------------------------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThiNhanVien(null);
            DatCheDo(CheDo.Them);
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatCheDo(CheDo.Sua);
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + dangChon.HoTen + "?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            Store.Data.NhanViens.RemoveAll(n => n.MaNV == dangChon.MaNV);
            Store.Save();

            HienThiNhanVien(null);
            NapCayToChuc();
            NapDanhSachNhanVien();
            DatCheDo(CheDo.Xem);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem)
            {
                return;
            }

            if (!KiemTraHopLe())
            {
                return;
            }

            string maNV = txtMaNV.Text.Trim();

            if (cheDo == CheDo.Them)
            {
                NhanVien moi = new NhanVien { MaNV = maNV };
                GanDuLieuTuGiaoDien(moi);
                Store.Data.NhanViens.Add(moi);
            }
            else
            {
                GanDuLieuTuGiaoDien(dangChon);
            }

            Store.Save();
            NapCayToChuc();
            NapDanhSachNhanVien();
            DatCheDo(CheDo.Xem);

            MessageBox.Show("Đã lưu hồ sơ nhân viên.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GanDuLieuTuGiaoDien(NhanVien nv)
        {
            nv.MaNV = txtMaNV.Text.Trim();
            nv.HoTen = txtHoTen.Text.Trim();
            nv.GioiTinh = cboGioiTinh.Text;
            nv.NgaySinh = dtpNgaySinh.Value.Date;
            nv.DienThoai = txtDienThoai.Text.Trim();
            nv.Email = txtEmail.Text.Trim();
            nv.DiaChi = txtDiaChi.Text.Trim();

            PhongBan p = cboPhongBanInfo.SelectedItem as PhongBan;
            nv.MaPhong = p == null ? "" : p.MaPhong;

            ChucVu c = cboChucVu.SelectedItem as ChucVu;
            nv.MaChucVu = c == null ? "" : c.MaChucVu;

            nv.NgayVaoLam = dtpNgayVaoLam.Value.Date;
            nv.LuongCoBan = LaySoTien(txtLuong.Text);
            nv.PhepNam = (int)nudPhepNam.Value;
            nv.TrangThai = cboTrangThai.SelectedIndex == 0 ? TrangThaiLamViec.DangLam : TrangThaiLamViec.DaNghi;
            nv.AnhBase64 = anhTam;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem)
            {
                return;
            }

            DatCheDo(CheDo.Xem);
            HienThiNhanVien(dangChon);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";

            if (cboLocPhong.Items.Count > 0)
            {
                cboLocPhong.SelectedIndex = 0;
            }

            NapComboBoxPhongBan();
            NapComboBoxChucVu();
            NapCayToChuc();
            NapDanhSachNhanVien();
            HienThiNhanVien(null);
            DatCheDo(CheDo.Xem);
        }

        // ------------------------------------------------------------------
        // Kiểm tra dữ liệu nhập (UX): báo lỗi đỏ + Tooltip + đưa Focus về ô sai
        // ------------------------------------------------------------------
        private bool KiemTraHopLe()
        {
            XoaLoi();

            if (txtMaNV.Text.Trim().Length == 0)
            {
                BaoLoi(txtMaNV, "Mã nhân viên không được để trống.");
                return false;
            }

            if (cheDo == CheDo.Them && Store.Data.NhanViens.Exists(n => n.MaNV == txtMaNV.Text.Trim()))
            {
                BaoLoi(txtMaNV, "Mã nhân viên đã tồn tại, vui lòng nhập mã khác.");
                return false;
            }

            if (txtHoTen.Text.Trim().Length == 0)
            {
                BaoLoi(txtHoTen, "Họ và tên không được để trống.");
                return false;
            }

            string sdt = txtDienThoai.Text.Trim();
            if (sdt.Length > 0)
            {
                foreach (char k in sdt)
                {
                    if (!char.IsDigit(k) && k != '+' && k != ' ' && k != '-' && k != '.')
                    {
                        BaoLoi(txtDienThoai, "Số điện thoại chỉ được chứa chữ số.");
                        return false;
                    }
                }

                if (sdt.Length < 9)
                {
                    BaoLoi(txtDienThoai, "Số điện thoại phải có ít nhất 9 ký tự.");
                    return false;
                }
            }

            string email = txtEmail.Text.Trim();
            if (email.Length > 0 && (!email.Contains("@") || !email.Contains(".") || email.StartsWith("@") || email.EndsWith(".")))
            {
                BaoLoi(txtEmail, "Email không đúng định dạng (ví dụ: ten@congty.vn).");
                return false;
            }

            decimal luong;
            if (!ThuLaySoTien(txtLuong.Text, out luong))
            {
                BaoLoi(txtLuong, "Lương cơ bản phải là số, ví dụ 15000000.");
                return false;
            }

            if (luong <= 0)
            {
                BaoLoi(txtLuong, "Lương cơ bản phải lớn hơn 0.");
                return false;
            }

            if (cboPhongBanInfo.SelectedIndex < 0)
            {
                BaoLoi(cboPhongBanInfo, "Vui lòng chọn phòng ban.");
                return false;
            }

            if (cboChucVu.SelectedIndex < 0)
            {
                BaoLoi(cboChucVu, "Vui lòng chọn chức vụ.");
                return false;
            }

            if (dtpNgaySinh.Value.Date >= DateTime.Today)
            {
                BaoLoi(dtpNgaySinh, "Ngày sinh phải nhỏ hơn ngày hiện tại.");
                return false;
            }

            if (dtpNgayVaoLam.Value.Date < dtpNgaySinh.Value.Date)
            {
                BaoLoi(dtpNgayVaoLam, "Ngày vào làm phải sau ngày sinh.");
                return false;
            }

            return true;
        }

        private void BaoLoi(Control c, string thongBao)
        {
            errorProvider1.SetError(c, thongBao);
            c.BackColor = Color.MistyRose;
            c.Focus();

            ToolTip tip = toolTip;
            tip.ShowAlways = true;
            tip.SetToolTip(c, thongBao);
            tip.Show(thongBao, c, 0, c.Height + 2, 4000);
        }

        private void XoaLoi()
        {
            errorProvider1.SetError(txtMaNV, "");
            errorProvider1.SetError(txtHoTen, "");
            errorProvider1.SetError(txtDienThoai, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtLuong, "");
            errorProvider1.SetError(cboPhongBanInfo, "");
            errorProvider1.SetError(cboChucVu, "");
            errorProvider1.SetError(dtpNgaySinh, "");
            errorProvider1.SetError(dtpNgayVaoLam, "");

            foreach (Control c in panelInfo.Controls)
            {
                c.BackColor = c is TextBox || c is ComboBox || c is DateTimePicker || c is NumericUpDown
                    ? Color.White
                    : c.BackColor;
            }

            picAnh.BackColor = Color.WhiteSmoke;
        }

        private static decimal LaySoTien(string chuoi)
        {
            decimal v;
            ThuLaySoTien(chuoi, out v);
            return v;
        }

        private static bool ThuLaySoTien(string chuoi, out decimal ketQua)
        {
            ketQua = 0;
            if (string.IsNullOrWhiteSpace(chuoi))
            {
                return false;
            }

            string s = chuoi.Trim().Replace(".", "").Replace(",", "").Replace(" ", "").Replace("₫", "");
            return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out ketQua);
        }

        // ------------------------------------------------------------------
        // Trạng thái nhập liệu
        // ------------------------------------------------------------------
        private bool DuocPhepNhap()
        {
            return cheDo == CheDo.Them || cheDo == CheDo.Sua;
        }

        private void DatCheDo(CheDo mode)
        {
            cheDo = mode;
            bool nhapLieu = DuocPhepNhap();

            txtHoTen.ReadOnly = !nhapLieu;
            txtDienThoai.ReadOnly = !nhapLieu;
            txtEmail.ReadOnly = !nhapLieu;
            txtDiaChi.ReadOnly = !nhapLieu;
            txtLuong.ReadOnly = !nhapLieu;

            txtMaNV.ReadOnly = mode != CheDo.Them;
            cboGioiTinh.Enabled = nhapLieu;
            cboPhongBanInfo.Enabled = nhapLieu;
            cboChucVu.Enabled = nhapLieu;
            cboTrangThai.Enabled = nhapLieu;
            dtpNgaySinh.Enabled = nhapLieu;
            dtpNgayVaoLam.Enabled = nhapLieu;
            nudPhepNam.Enabled = nhapLieu;
            btnDoiAnh.Enabled = nhapLieu;
            btnXoaAnh.Enabled = nhapLieu;

            btnThem.Enabled = !nhapLieu;
            btnSua.Enabled = !nhapLieu;
            btnXoa.Enabled = !nhapLieu;
            btnLuu.Enabled = nhapLieu;
            btnHuy.Enabled = nhapLieu;

            btnTimKiem.Enabled = !nhapLieu;
            cboLocPhong.Enabled = !nhapLieu;
            txtTimKiem.Enabled = !nhapLieu;
            tvToChuc.Enabled = !nhapLieu;

            NapDanhSachNhanVien();
        }
    }
}
