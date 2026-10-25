namespace QuanLyNhanSu.Forms
{
    partial class frmMain
    {
        /// <summary>Biến thiết kế.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Giải phóng tài nguyên đang dùng.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Phương thức bắt buộc của trình thiết kế - không sửa bằng tay nội dung
        /// bên trong, hãy dùng cửa sổ Designer của Visual Studio.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuBangDieuKhien = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuTuyChinh = new ToolStripMenuItem();
            mnuDoiMau = new ToolStripMenuItem();
            mnuDoiFont = new ToolStripMenuItem();
            mnuMacDinh = new ToolStripMenuItem();
            mnuSep1 = new ToolStripSeparator();
            mnuSaoLuu = new ToolStripMenuItem();
            mnuPhucHoi = new ToolStripMenuItem();
            mnuSep2 = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuHoSo = new ToolStripMenuItem();
            mnuPhongBan = new ToolStripMenuItem();
            mnuChucVu = new ToolStripMenuItem();
            mnuNghiepVu = new ToolStripMenuItem();
            mnuChamCong = new ToolStripMenuItem();
            mnuTinhLuong = new ToolStripMenuItem();
            mnuCuaSo = new ToolStripMenuItem();
            mnuMultiMDIChildView = new ToolStripMenuItem();
            mnuXepChong = new ToolStripMenuItem();
            mnuXepNgang = new ToolStripMenuItem();
            mnuXepDoc = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuGioiThieu = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblNguoiDung = new ToolStripStatusLabel();
            lblVaiTro = new ToolStripStatusLabel();
            lblKhoangTrong = new ToolStripStatusLabel();
            lblDongHo = new ToolStripStatusLabel();
            timerDongHo = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuNghiepVu, mnuCuaSo, mnuTroGiup });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = mnuCuaSo;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1371, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuBangDieuKhien, mnuDangXuat, mnuTuyChinh, mnuSep1, mnuSaoLuu, mnuPhucHoi, mnuSep2, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(85, 24);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuBangDieuKhien
            // 
            mnuBangDieuKhien.Name = "mnuBangDieuKhien";
            mnuBangDieuKhien.ShortcutKeys = Keys.Control | Keys.D;
            mnuBangDieuKhien.Size = new Size(251, 26);
            mnuBangDieuKhien.Text = "Bảng điều khiển";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(251, 26);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuTuyChinh
            // 
            mnuTuyChinh.DropDownItems.AddRange(new ToolStripItem[] { mnuDoiMau, mnuDoiFont, mnuMacDinh });
            mnuTuyChinh.Name = "mnuTuyChinh";
            mnuTuyChinh.Size = new Size(251, 26);
            mnuTuyChinh.Text = "Tùy chỉnh giao diện";
            // 
            // mnuDoiMau
            // 
            mnuDoiMau.Name = "mnuDoiMau";
            mnuDoiMau.Size = new Size(223, 26);
            mnuDoiMau.Text = "Đổi màu sắc...";
            // 
            // mnuDoiFont
            // 
            mnuDoiFont.Name = "mnuDoiFont";
            mnuDoiFont.Size = new Size(223, 26);
            mnuDoiFont.Text = "Đổi font chữ...";
            // 
            // mnuMacDinh
            // 
            mnuMacDinh.Name = "mnuMacDinh";
            mnuMacDinh.Size = new Size(223, 26);
            mnuMacDinh.Text = "Khôi phục mặc định";
            // 
            // mnuSep1
            // 
            mnuSep1.Name = "mnuSep1";
            mnuSep1.Size = new Size(248, 6);
            // 
            // mnuSaoLuu
            // 
            mnuSaoLuu.Name = "mnuSaoLuu";
            mnuSaoLuu.Size = new Size(251, 26);
            mnuSaoLuu.Text = "Sao lưu dữ liệu...";
            // 
            // mnuPhucHoi
            // 
            mnuPhucHoi.Name = "mnuPhucHoi";
            mnuPhucHoi.Size = new Size(251, 26);
            mnuPhucHoi.Text = "Phục hồi dữ liệu...";
            // 
            // mnuSep2
            // 
            mnuSep2.Name = "mnuSep2";
            mnuSep2.Size = new Size(248, 6);
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(251, 26);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuHoSo, mnuPhongBan, mnuChucVu });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(73, 24);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuHoSo
            // 
            mnuHoSo.Name = "mnuHoSo";
            mnuHoSo.ShortcutKeys = Keys.Control | Keys.Alt | Keys.H;
            mnuHoSo.Size = new Size(280, 26);
            mnuHoSo.Text = "Hồ sơ nhân viên";
            mnuHoSo.Click += mnuHoSoNhanVien_Click;
            // 
            // mnuPhongBan
            // 
            mnuPhongBan.Name = "mnuPhongBan";
            mnuPhongBan.ShortcutKeys = Keys.Control | Keys.Alt | Keys.P;
            mnuPhongBan.Size = new Size(280, 26);
            mnuPhongBan.Text = "Phòng ban";
            mnuPhongBan.Click += mnuPhongBan_Click;
            // 
            // mnuChucVu
            // 
            mnuChucVu.Name = "mnuChucVu";
            mnuChucVu.ShortcutKeys = Keys.Control | Keys.Alt | Keys.C;
            mnuChucVu.Size = new Size(280, 26);
            mnuChucVu.Text = "Chức vụ";
            mnuChucVu.Click += mnuChucVu_Click;
            // 
            // mnuNghiepVu
            // 
            mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuChamCong, mnuTinhLuong });
            mnuNghiepVu.Name = "mnuNghiepVu";
            mnuNghiepVu.Size = new Size(91, 24);
            mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuChamCong
            // 
            mnuChamCong.Name = "mnuChamCong";
            mnuChamCong.ShortcutKeys = Keys.Alt | Keys.A;
            mnuChamCong.Size = new Size(288, 26);
            mnuChamCong.Text = "Chấm công hằng ngày";
            mnuChamCong.Click += mnuChamCong_Click;
            // 
            // mnuTinhLuong
            // 
            mnuTinhLuong.Name = "mnuTinhLuong";
            mnuTinhLuong.ShortcutKeys = Keys.Alt | Keys.S;
            mnuTinhLuong.Size = new Size(288, 26);
            mnuTinhLuong.Text = "Tính lương tháng";
            mnuTinhLuong.Click += mnuLuong_Click;
            // 
            // mnuCuaSo
            // 
            mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[] { mnuMultiMDIChildView, mnuXepChong, mnuXepNgang, mnuXepDoc });
            mnuCuaSo.Name = "mnuCuaSo";
            mnuCuaSo.Size = new Size(68, 24);
            mnuCuaSo.Text = "Cửa sổ";
            // 
            // mnuMultiMDIChildView
            // 
            mnuMultiMDIChildView.Name = "mnuMultiMDIChildView";
            mnuMultiMDIChildView.ShortcutKeys = Keys.Alt | Keys.M;
            mnuMultiMDIChildView.Size = new Size(272, 26);
            mnuMultiMDIChildView.Text = "Xem đa cửa sổ(Tắt)";
            mnuMultiMDIChildView.Click += mnuMultiMDIChildView_Click;
            // 
            // mnuXepChong
            // 
            mnuXepChong.Name = "mnuXepChong";
            mnuXepChong.Size = new Size(272, 26);
            mnuXepChong.Text = "Xếp chồng";
            mnuXepChong.Click += mnuXepChong_Click;
            // 
            // mnuXepNgang
            // 
            mnuXepNgang.Name = "mnuXepNgang";
            mnuXepNgang.Size = new Size(272, 26);
            mnuXepNgang.Text = "Xếp ngang";
            mnuXepNgang.Click += mnuXepNgang_Click;
            // 
            // mnuXepDoc
            // 
            mnuXepDoc.Name = "mnuXepDoc";
            mnuXepDoc.Size = new Size(272, 26);
            mnuXepDoc.Text = "Xếp dọc";
            mnuXepDoc.Click += mnuXepDoc_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuGioiThieu });
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(78, 24);
            mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuGioiThieu
            // 
            mnuGioiThieu.Name = "mnuGioiThieu";
            mnuGioiThieu.Size = new Size(231, 26);
            mnuGioiThieu.Text = "Giới thiệu phần mềm";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblNguoiDung, lblVaiTro, lblKhoangTrong, lblDongHo });
            statusStrip1.Location = new Point(0, 907);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1371, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(114, 20);
            lblNguoiDung.Text = "Người dùng: ---";
            // 
            // lblVaiTro
            // 
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(77, 20);
            lblVaiTro.Text = "Vai trò: ---";
            // 
            // lblKhoangTrong
            // 
            lblKhoangTrong.Name = "lblKhoangTrong";
            lblKhoangTrong.Size = new Size(1020, 20);
            lblKhoangTrong.Spring = true;
            // 
            // lblDongHo
            // 
            lblDongHo.Name = "lblDongHo";
            lblDongHo.Size = new Size(143, 20);
            lblDongHo.Text = "00/00/0000 00:00:00";
            // 
            // timerDongHo
            // 
            timerDongHo.Enabled = true;
            timerDongHo.Interval = 1000;
            timerDongHo.Tick += timerDongHo_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 933);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuBangDieuKhien;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuTuyChinh;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMau;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiFont;
        private System.Windows.Forms.ToolStripMenuItem mnuMacDinh;
        private System.Windows.Forms.ToolStripSeparator mnuSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuSaoLuu;
        private System.Windows.Forms.ToolStripMenuItem mnuPhucHoi;
        private System.Windows.Forms.ToolStripSeparator mnuSep2;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuHoSo;
        private System.Windows.Forms.ToolStripMenuItem mnuPhongBan;
        private System.Windows.Forms.ToolStripMenuItem mnuChucVu;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem mnuChamCong;
        private System.Windows.Forms.ToolStripMenuItem mnuTinhLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuXepChong;
        private System.Windows.Forms.ToolStripMenuItem mnuXepNgang;
        private System.Windows.Forms.ToolStripMenuItem mnuXepDoc;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel lblVaiTro;
        private System.Windows.Forms.ToolStripStatusLabel lblKhoangTrong;
        private System.Windows.Forms.ToolStripStatusLabel lblDongHo;
        private System.Windows.Forms.Timer timerDongHo;
        private ToolStripMenuItem mnuMultiMDIChildView;
    }
}
