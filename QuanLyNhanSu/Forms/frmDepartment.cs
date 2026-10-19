using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>Màn hình quản lý Phòng ban (thêm / sửa / xóa).</summary>
    public partial class frmDepartment : Form
    {
        private enum CheDo { Xem, Them, Sua }

        private CheDo cheDo = CheDo.Xem;
        private PhongBan dangChon;

        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);
            NapDanhSach();
            DatCheDo(CheDo.Xem);

            CotDanhSach.VuaTieuDe(lvPhongBan);
        }

        private void NapDanhSach()
        {
            lvPhongBan.BeginUpdate();
            lvPhongBan.Items.Clear();

            foreach (PhongBan p in Store.Data.PhongBans)
            {
                int soNV = Store.Data.NhanViens.FindAll(n => n.MaPhong == p.MaPhong).Count;

                ListViewItem item = new ListViewItem(p.MaPhong);
                item.SubItems.Add(p.TenPhong);
                item.SubItems.Add(soNV.ToString());
                item.SubItems.Add(p.MoTa);
                item.Tag = p;

                lvPhongBan.Items.Add(item);
            }

            lvPhongBan.EndUpdate();
        }

        private void HienThi(PhongBan p)
        {
            dangChon = p;

            if (p == null)
            {
                txtMaPhong.Text = "";
                txtTenPhong.Text = "";
                txtMoTa.Text = "";
                return;
            }

            txtMaPhong.Text = p.MaPhong;
            txtTenPhong.Text = p.TenPhong;
            txtMoTa.Text = p.MoTa;
            XoaLoi();
        }

        private void lvPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhongBan.SelectedItems.Count == 0 || cheDo != CheDo.Xem)
            {
                return;
            }

            HienThi(lvPhongBan.SelectedItems[0].Tag as PhongBan);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(null);
            DatCheDo(CheDo.Them);
            txtMaPhong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatCheDo(CheDo.Sua);
            txtTenPhong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dangChon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int soNV = Store.Data.NhanViens.FindAll(n => n.MaPhong == dangChon.MaPhong).Count;
            if (soNV > 0)
            {
                MessageBox.Show(string.Format("Phòng ban này đang có {0} nhân viên, không thể xóa!", soNV),
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng ban \"" + dangChon.TenPhong + "\"?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            Store.Data.PhongBans.RemoveAll(p => p.MaPhong == dangChon.MaPhong);
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

            string ma = txtMaPhong.Text.Trim();
            string ten = txtTenPhong.Text.Trim();

            if (ma.Length == 0)
            {
                BaoLoi(txtMaPhong, "Mã phòng không được để trống.");
                return;
            }

            if (cheDo == CheDo.Them && Store.Data.PhongBans.Exists(p => p.MaPhong == ma))
            {
                BaoLoi(txtMaPhong, "Mã phòng đã tồn tại.");
                return;
            }

            if (ten.Length == 0)
            {
                BaoLoi(txtTenPhong, "Tên phòng ban không được để trống.");
                return;
            }

            if (cheDo == CheDo.Them)
            {
                Store.Data.PhongBans.Add(new PhongBan { MaPhong = ma, TenPhong = ten, MoTa = txtMoTa.Text.Trim() });
            }
            else
            {
                dangChon.TenPhong = ten;
                dangChon.MoTa = txtMoTa.Text.Trim();
            }

            Store.Save();
            NapDanhSach();
            DatCheDo(CheDo.Xem);

            MessageBox.Show("Đã lưu thông tin phòng ban.", "Thông báo",
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
            errorProvider1.SetError(txtMaPhong, "");
            errorProvider1.SetError(txtTenPhong, "");
            txtMaPhong.BackColor = Color.White;
            txtTenPhong.BackColor = Color.White;
            txtMoTa.BackColor = Color.White;
        }

        private void DatCheDo(CheDo mode)
        {
            cheDo = mode;
            bool nhapLieu = mode != CheDo.Xem;

            txtMaPhong.ReadOnly = mode != CheDo.Them;
            txtTenPhong.ReadOnly = !nhapLieu;
            txtMoTa.ReadOnly = !nhapLieu;

            btnThem.Enabled = !nhapLieu;
            btnSua.Enabled = !nhapLieu;
            btnXoa.Enabled = !nhapLieu;
            btnLuu.Enabled = nhapLieu;
            btnHuy.Enabled = nhapLieu;
        }
    }
}
