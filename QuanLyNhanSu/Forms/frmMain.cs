using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// Màn hình chính (MDI Parent): chứa thanh menu, thanh trạng thái, đồng hồ thời gian thực
    /// và là nơi mở các Form con.
    /// </summary>
    public partial class frmMain : Form
    {
        private bool dangDangXuat;

        public frmMain()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------
        // Khởi động
        // ------------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = CauHinh.TenDonVi + " - Hệ thống quản lý nhân sự";

            lblNguoiDung.Text = "Người dùng: " + PhienLamViec.TenHienThi
                + " (" + (PhienLamViec.NguoiDung == null ? "" : PhienLamViec.NguoiDung.TenDangNhap) + ")";
            lblVaiTro.Text = "Vai trò: " + PhienLamViec.TenVaiTro;

            PhanQuyenTheoVaiTro();

            timerDongHo.Start();
            CapNhatDongHo(null, EventArgs.Empty);

            LamMoiGiaoDien();

            // Màn hình nền: mở ngay bảng điều khiển
            MoFormCon(typeof(frmDashboard));
        }

        private void PhanQuyenTheoVaiTro()
        {
            bool laQuanTri = PhienLamViec.LaQuanTri;

            // Nhân viên không được quản lý phòng ban, chức vụ và không được sao lưu / phục hồi
            mnuPhongBan.Enabled = laQuanTri;
            mnuChucVu.Enabled = laQuanTri;
            mnuSaoLuu.Enabled = laQuanTri;
            mnuPhucHoi.Enabled = laQuanTri;
        }

        // ------------------------------------------------------------------
        // Quản lý Form con (không mở trùng lặp)
        // ------------------------------------------------------------------
        private Form MoFormCon(Type kieuForm)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == kieuForm)
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        f.WindowState = FormWindowState.Normal;
                    }

                    f.Activate();
                    return f;
                }
            }

            Form con = (Form)Activator.CreateInstance(kieuForm);
            con.MdiParent = this;
            con.Show();
            return con;
        }

        private void MoFormConVaDong(Type kieuForm)
        {
            Form f = MoFormCon(kieuForm);
            if (f != null)
            {
                f.BringToFront();
            }
        }

        /// <summary>Áp dụng lại màu sắc / font chữ cho Form này và mọi Form con đang mở.</summary>
        private void LamMoiGiaoDien()
        {
            TuyChinh.ApDung(this);
            foreach (Form f in MdiChildren)
            {
                TuyChinh.ApDung(f);
            }
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo(sender, e);
        }

        private void CapNhatDongHo(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss");
        }

        // ------------------------------------------------------------------
        // Menu: Hệ thống
        // ------------------------------------------------------------------
        private void mnuBangDieuKhien_Click(object sender, EventArgs e)
        {
            MoFormConVaDong(typeof(frmDashboard));
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất khỏi hệ thống?", "Xác nhận đăng xuất",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            dangDangXuat = true;
            PhienLamViec.YeuCauDangXuat = true;
            DongTatCaFormCon();
            Close();
        }

        private void mnuDoiMau_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = TuyChinh.MauChinh;
                cd.FullOpen = true;
                if (cd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                TuyChinh.MauChinh = cd.Color;
                TuyChinh.Save();       // Lưu vào Registry
                LamMoiGiaoDien();
            }
        }

        private void mnuDoiFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = TuyChinh.FontGiaoDien;
                fd.ShowColor = false;
                if (fd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                TuyChinh.TenFont = fd.Font.Name;
                TuyChinh.CoFont = fd.Font.Size;
                TuyChinh.Save();       // Lưu vào Registry
                LamMoiGiaoDien();
            }
        }

        private void mnuMacDinh_Click(object sender, EventArgs e)
        {
            TuyChinh.MauChinh = Color.FromArgb(45, 108, 223);
            TuyChinh.TenFont = "Segoe UI";
            TuyChinh.CoFont = 9F;
            TuyChinh.Save();
            LamMoiGiaoDien();
            MessageBox.Show("Đã khôi phục giao diện mặc định.", "Tùy chỉnh giao diện",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuSaoLuu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Sao lưu dữ liệu hệ thống";
                sfd.Filter = "Tập tin dữ liệu (*.json)|*.json|Tất cả tập tin (*.*)|*.*";
                sfd.FileName = "sao_luu_nhan_su_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";

                if (sfd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    Store.Save();
                    File.Copy(Store.DataFile, sfd.FileName, true);
                    MessageBox.Show("Sao lưu dữ liệu thành công!\n" + sfd.FileName, "Sao lưu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sao lưu thất bại: " + ex.Message, "Sao lưu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuPhucHoi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn tập tin sao lưu để phục hồi";
                ofd.Filter = "Tập tin dữ liệu (*.json)|*.json|Tất cả tập tin (*.*)|*.*";

                if (ofd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                if (MessageBox.Show("Toàn bộ dữ liệu hiện tại sẽ bị thay thế bằng dữ liệu trong tập tin này.\nTiếp tục?",
                        "Xác nhận phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    Directory.CreateDirectory(Store.Folder);
                    File.Copy(ofd.FileName, Store.DataFile, true);
                    Store.Reload();

                    DongTatCaFormCon();
                    MoFormConVaDong(typeof(frmDashboard));

                    MessageBox.Show("Phục hồi dữ liệu thành công!", "Phục hồi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phục hồi thất bại: " + ex.Message, "Phục hồi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DongTatCaFormCon()
        {
            foreach (Form f in MdiChildren)
            {
                f.Close();
            }
        }

        // ------------------------------------------------------------------
        // Menu: Quản lý
        // ------------------------------------------------------------------
        private void mnuHoSo_Click(object sender, EventArgs e)
        {
            MoFormConVaDong(typeof(frmEmployee));
        }

        private void mnuPhongBan_Click(object sender, EventArgs e)
        {
            MoFormConVaDong(typeof(frmDepartment));
        }

        private void mnuChucVu_Click(object sender, EventArgs e)
        {
            MoFormConVaDong(typeof(frmPosition));
        }

        // ------------------------------------------------------------------
        // Menu: Nghiệp vụ
        // ------------------------------------------------------------------
        private void mnuChamCong_Click(object sender, EventArgs e)
        {
            MoFormConVaDong(typeof(frmAttendance));
        }

        private void mnuTinhLuong_Click(object sender, EventArgs e)
        {
            MoFormConVaDong(typeof(frmSalary));
        }

        // ------------------------------------------------------------------
        // Menu: Cửa sổ
        // ------------------------------------------------------------------
        private void mnuXepChong_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuXepNgang_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuXepDoc_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        // ------------------------------------------------------------------
        // Menu: Trợ giúp
        // ------------------------------------------------------------------
        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "HỆ THỐNG QUẢN LÝ NHÂN SỰ" + Environment.NewLine + Environment.NewLine +
                "Đơn vị: " + CauHinh.TenDonVi + Environment.NewLine +
                "Ngày công chuẩn: " + CauHinh.NgayCongChuan + " ngày/tháng" + Environment.NewLine +
                "Mức trừ đi trễ: " + CauHinh.MucTruDiTre.ToString("#,##0") + " VNĐ/lần" + Environment.NewLine +
                "Hệ số tăng ca: " + CauHinh.HeSoTangCa.ToString("0.##") + Environment.NewLine + Environment.NewLine +
                "Dữ liệu lưu tại: " + Store.DataFile,
                "Giới thiệu phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ------------------------------------------------------------------
        // Đóng chương trình
        // ------------------------------------------------------------------
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dangDangXuat)
            {
                return;
            }

            DialogResult kq = MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            PhienLamViec.YeuCauDangXuat = false;
        }
    }
}
