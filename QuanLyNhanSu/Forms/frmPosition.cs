using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>Màn hình quản lý Chức vụ (thêm / sửa / xóa).</summary>
    public partial class frmPosition : Form
    {
        private enum CheDo { Xem, Them, Sua }

        private CheDo cheDo = CheDo.Xem;
        private ChucVu dangChon;

        public frmPosition()
        {
            InitializeComponent();
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);
            NapDanhSach();
            DatCheDo(CheDo.Xem);

            CotDanhSach.VuaTieuDe(lvChucVu);
        }

        private void NapDanhSach()
        {
            lvChucVu.BeginUpdate();
            lvChucVu.Items.Clear();

            foreach (ChucVu c in Store.Data.ChucVus)
            {
                int soNV = Store.Data.NhanViens.FindAll(n => n.MaChucVu == c.MaChucVu).Count;

                ListViewItem item = new ListViewItem(c.MaChucVu);
                item.SubItems.Add(c.TenChucVu);
                item.SubItems.Add(c.HeSoLuong.ToString("0.00"));
                item.SubItems.Add(soNV.ToString());
                item.Tag = c;

                lvChucVu.Items.Add(item);
            }

            lvChucVu.EndUpdate();
        }

        private void HienThi(ChucVu c)
        {
            dangChon = c;

            if (c == null)
            {
                txtMaChucVu.Text = "";
                txtTenChucVu.Text = "";
                nudHeSoLuong.Value = 1;
                return;
            }

            txtMaChucVu.Text = c.MaChucVu;
            txtTenChucVu.Text = c.TenChucVu;
            nudHeSoLuong.Value = (decimal)c.HeSoLuong;
            XoaLoi();
        }

        private void lvChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvChucVu.SelectedItems.Count == 0 || cheDo != CheDo.Xem)
            {
                return;
            }

            HienThi(lvChucVu.SelectedItems[0].Tag as ChucVu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(null);
            DatCheDo(CheDo.Them);
            txtMaChucVu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatCheDo(CheDo.Sua);
            txtTenChucVu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int soNV = Store.Data.NhanViens.FindAll(n => n.MaChucVu == dangChon.MaChucVu).Count;
            if (soNV > 0)
            {
                MessageBox.Show(string.Format("Chức vụ này đang có {0} nhân viên, không thể xóa!", soNV),
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa chức vụ \"" + dangChon.TenChucVu + "\"?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            Store.Data.ChucVus.RemoveAll(c => c.MaChucVu == dangChon.MaChucVu);
            Store.Save();

            HienThi(null);
            NapDanhSach();
            DatCheDo(CheDo.Xem);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem)
            {
                return;
            }

            XoaLoi();

            string ma = txtMaChucVu.Text.Trim();
            string ten = txtTenChucVu.Text.Trim();

            if (ma.Length == 0)
            {
                BaoLoi(txtMaChucVu, "Mã chức vụ không được để trống.");
                return;
            }

            if (cheDo == CheDo.Them && Store.Data.ChucVus.Exists(c => c.MaChucVu == ma))
            {
                BaoLoi(txtMaChucVu, "Mã chức vụ đã tồn tại.");
                return;
            }

            if (ten.Length == 0)
            {
                BaoLoi(txtTenChucVu, "Tên chức vụ không được để trống.");
                return;
            }

            if (cheDo == CheDo.Them)
            {
                Store.Data.ChucVus.Add(new ChucVu
                {
                    MaChucVu = ma,
                    TenChucVu = ten,
                    HeSoLuong = (double)nudHeSoLuong.Value
                });
            }
            else
            {
                dangChon.TenChucVu = ten;
                dangChon.HeSoLuong = (double)nudHeSoLuong.Value;
            }

            Store.Save();
            NapDanhSach();
            DatCheDo(CheDo.Xem);

            MessageBox.Show("Đã lưu thông tin chức vụ.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatCheDo(CheDo.Xem);
            HienThi(dangChon);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            NapDanhSach();
            HienThi(null);
            DatCheDo(CheDo.Xem);
        }

        private void BaoLoi(Control c, string thongBao)
        {
            errorProvider1.SetError(c, thongBao);
            c.BackColor = Color.MistyRose;
            c.Focus();
        }

        private void XoaLoi()
        {
            errorProvider1.SetError(txtMaChucVu, "");
            errorProvider1.SetError(txtTenChucVu, "");
            txtMaChucVu.BackColor = Color.White;
            txtTenChucVu.BackColor = Color.White;
        }

        private void DatCheDo(CheDo mode)
        {
            cheDo = mode;
            bool nhapLieu = mode != CheDo.Xem;

            txtMaChucVu.ReadOnly = mode != CheDo.Them;
            txtTenChucVu.ReadOnly = !nhapLieu;
            nudHeSoLuong.Enabled = nhapLieu;

            btnThem.Enabled = !nhapLieu;
            btnSua.Enabled = !nhapLieu;
            btnXoa.Enabled = !nhapLieu;
            btnLuu.Enabled = nhapLieu;
            btnHuy.Enabled = nhapLieu;
        }
    }
}
