using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// Màn hình nền (Dashboard) hiển thị ngay sau khi đăng nhập:
    /// thống kê nhanh và danh sách sinh nhật nhân viên trong tháng.
    /// </summary>
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            lstSinhNhat.DoubleClick += lstSinhNhat_DoubleClick;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);

            // Đổi màu thẻ thống kê theo màu chủ đạo đang chọn
            lblChaoMung.ForeColor = TuyChinh.MauChinh;
            pnlThe1.BackColor = TuyChinh.MauChinh;
            pnlThe2.BackColor = ChinhMau(24, 160, 140);
            pnlThe3.BackColor = ChinhMau(240, 150, 40);
            pnlThe4.BackColor = ChinhMau(150, 70, 190);

            lblChaoMung.Text = "Xin chào, " + PhienLamViec.TenHienThi + "!";
            lblHomNay.Text = "Hôm nay: " + DateTime.Now.ToString("dddd, dd/MM/yyyy")
                + "   |   Vai trò: " + PhienLamViec.TenVaiTro;

            lblSo1.Text = Store.Data.NhanViens.Count.ToString();
            lblSo3.Text = Store.Data.ChucVus.Count.ToString();

            int soPhong = Store.Data.PhongBans.Count;
            lblSo2.Text = soPhong.ToString();

            int dangLam = 0;
            foreach (NhanVien nv in Store.Data.NhanViens)
            {
                if (nv.TrangThai == TrangThaiLamViec.DangLam)
                {
                    dangLam++;
                }
            }

            lblSo4.Text = dangLam.ToString();

            NapDanhSachSinhNhat();
        }

        private Color ChinhMau(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

        /// <summary>Nạp ListBox danh sách sinh nhật nhân viên trong tháng hiện tại.</summary>
        private void NapDanhSachSinhNhat()
        {
            lstSinhNhat.Items.Clear();

            int thang = DateTime.Today.Month;
            foreach (NhanVien nv in NghiepVu.SinhNhatTrongThang(thang))
            {
                string dong = string.Format("{0:dd/MM}  -  {1}  ({2})  -  {3}",
                    nv.NgaySinh, nv.HoTen, NghiepVu.TenPhong(nv.MaPhong), nv.GioiTinh);
                lstSinhNhat.Items.Add(dong);
            }

            if (lstSinhNhat.Items.Count == 0)
            {
                lstSinhNhat.Items.Add("Tháng " + thang + " không có nhân viên nào có sinh nhật.");
            }
        }

        private void lstSinhNhat_DoubleClick(object sender, EventArgs e)
        {
            int i = lstSinhNhat.SelectedIndex;
            if (i < 0)
            {
                return;
            }

            var ds = NghiepVu.SinhNhatTrongThang(DateTime.Today.Month);
            if (i >= ds.Count)
            {
                return;
            }

            NhanVien nv = ds[i];
            MessageBox.Show(
                "Mã nhân viên: " + nv.MaNV + Environment.NewLine +
                "Họ tên: " + nv.HoTen + Environment.NewLine +
                "Ngày sinh: " + nv.NgaySinh.ToString("dd/MM/yyyy") + Environment.NewLine +
                "Giới tính: " + nv.GioiTinh + Environment.NewLine +
                "Phòng ban: " + NghiepVu.TenPhong(nv.MaPhong) + Environment.NewLine +
                "Chức vụ: " + NghiepVu.TenChucVu(nv.MaChucVu) + Environment.NewLine +
                "Điện thoại: " + nv.DienThoai + Environment.NewLine +
                "Email: " + nv.Email,
                "Thông tin nhân viên có sinh nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
