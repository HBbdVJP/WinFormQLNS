using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>Màn hình đăng nhập hệ thống. (Hình thức: cửa sổ pop-up, cho phép kéo di chuyển)</summary>
    public partial class frmLogin : Form
    {
        private const int SoLanSaiToiDa = 3;
        private const int SoGiayKhoa = 30;

        private int soLanSai;
        private int soGiayConLai;
        private bool dangKhoa;

        private bool dangKeo;
        private Point mocKeo;

        public frmLogin()
        {
            InitializeComponent();

            // Cho phép kéo cửa sổ không viền bằng cách giữ chuột trên nửa bên trái
            pnlLeft.MouseDown += BatDauKeo;
            pnlLeft.MouseMove += DangKeo;
            pnlLeft.MouseUp += KetThucKeo;
            foreach (Control c in pnlLeft.Controls)
            {
                c.MouseDown += BatDauKeo;
                c.MouseMove += DangKeo;
                c.MouseUp += KetThucKeo;
            }

            KeyDown += frmLogin_KeyDown;
        }

        // ------------------------------------------------------------------
        // Khởi tạo giao diện
        // ------------------------------------------------------------------
        private void frmLogin_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);

            pnlLeft.BackColor = TuyChinh.MauChinh;
            lblTitle.ForeColor = TuyChinh.MauChinh;
            btnDangNhap.BackColor = TuyChinh.MauChinh;
            picLogo.Image = HinhAnh.TaoLogo(picLogo.Width, picLogo.Height, TuyChinh.MauChinh);

            // Đọc trạng thái "Ghi nhớ đăng nhập" đã lưu trong Registry
            chkGhiNho.Checked = TuyChinh.GhiNhoDangNhap;
            if (TuyChinh.GhiNhoDangNhap && !string.IsNullOrEmpty(TuyChinh.TenDangNhapDaNho))
            {
                txtUsername.Text = TuyChinh.TenDangNhapDaNho;
                txtPassword.Focus();
            }
            else
            {
                txtUsername.Focus();
            }
        }

        // ------------------------------------------------------------------
        // Đăng nhập
        // ------------------------------------------------------------------
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (dangKhoa)
            {
                return;
            }

            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text;

            if (tenDangNhap.Length == 0 || matKhau.Length == 0)
            {
                lblLoi.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
                (tenDangNhap.Length == 0 ? txtUsername : txtPassword).Focus();
                return;
            }

            TaiKhoan tk = Store.Data.TaiKhoans.Find(t =>
                string.Equals(t.TenDangNhap, tenDangNhap, StringComparison.OrdinalIgnoreCase)
                && t.MatKhau == matKhau);

            if (tk == null)
            {
                soLanSai++;
                if (soLanSai >= SoLanSaiToiDa)
                {
                    KhoaNutDangNhap();
                }
                else
                {
                    lblLoi.Text = string.Format("Sai tên đăng nhập hoặc mật khẩu! Còn {0} lần thử.",
                        SoLanSaiToiDa - soLanSai);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }

                return;
            }

            // Lưu trạng thái ghi nhớ vào Registry
            TuyChinh.GhiNhoDangNhap = chkGhiNho.Checked;
            TuyChinh.TenDangNhapDaNho = chkGhiNho.Checked ? tenDangNhap : "";
            TuyChinh.Save();

            PhienLamViec.NguoiDung = tk;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void KhoaNutDangNhap()
        {
            dangKhoa = true;
            soGiayConLai = SoGiayKhoa;
            btnDangNhap.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            lblLoi.Text = string.Format("Bạn đã nhập sai {0} lần! Nút đăng nhập bị khóa trong {1} giây.",
                SoLanSaiToiDa, SoGiayKhoa);
            timerKhoa.Start();
        }

        private void timerKhoa_Tick(object sender, EventArgs e)
        {
            soGiayConLai--;
            if (soGiayConLai > 0)
            {
                lblLoi.Text = string.Format("Vui lòng thử lại sau {0} giây...", soGiayConLai);
                return;
            }

            timerKhoa.Stop();
            dangKhoa = false;
            soLanSai = 0;
            btnDangNhap.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            lblLoi.Text = "";
            txtUsername.Focus();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(
                    "Tài khoản dùng thử:" + Environment.NewLine +
                    " - Quản trị: admin / admin123" + Environment.NewLine +
                    " - Nhân viên: nv01 / 123456",
                    "Hướng dẫn đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ------------------------------------------------------------------
        // Kéo cửa sổ không viền
        // ------------------------------------------------------------------
        private void BatDauKeo(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            dangKeo = true;
            mocKeo = PointToClient(((Control)sender).PointToScreen(e.Location));
        }

        private void DangKeo(object sender, MouseEventArgs e)
        {
            if (!dangKeo)
            {
                return;
            }

            Point p = ((Control)sender).PointToScreen(e.Location);
            Location = new Point(p.X - mocKeo.X, p.Y - mocKeo.Y);
        }

        private void KetThucKeo(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }
    }
}
