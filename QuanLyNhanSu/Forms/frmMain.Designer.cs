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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangDieuKhien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTuyChinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMacDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaoLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhucHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChamCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTinhLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepChong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepNgang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVaiTro = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKhoangTrong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDongHo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerDongHo = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanLy,
            this.mnuNghiepVu,
            this.mnuCuaSo,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.mnuCuaSo;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBangDieuKhien,
            this.mnuDangXuat,
            this.mnuTuyChinh,
            this.mnuSep1,
            this.mnuSaoLuu,
            this.mnuPhucHoi,
            this.mnuSep2,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(72, 24);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuBangDieuKhien
            // 
            this.mnuBangDieuKhien.Name = "mnuBangDieuKhien";
            this.mnuBangDieuKhien.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuBangDieuKhien.Size = new System.Drawing.Size(252, 22);
            this.mnuBangDieuKhien.Text = "Bảng điều khiển";
            this.mnuBangDieuKhien.Click += new System.EventHandler(this.mnuBangDieuKhien_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(252, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuTuyChinh
            // 
            this.mnuTuyChinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiMau,
            this.mnuDoiFont,
            this.mnuMacDinh});
            this.mnuTuyChinh.Name = "mnuTuyChinh";
            this.mnuTuyChinh.Size = new System.Drawing.Size(252, 22);
            this.mnuTuyChinh.Text = "Tùy chỉnh giao diện";
            // 
            // mnuDoiMau
            // 
            this.mnuDoiMau.Name = "mnuDoiMau";
            this.mnuDoiMau.Size = new System.Drawing.Size(200, 22);
            this.mnuDoiMau.Text = "Đổi màu sắc...";
            this.mnuDoiMau.Click += new System.EventHandler(this.mnuDoiMau_Click);
            // 
            // mnuDoiFont
            // 
            this.mnuDoiFont.Name = "mnuDoiFont";
            this.mnuDoiFont.Size = new System.Drawing.Size(200, 22);
            this.mnuDoiFont.Text = "Đổi font chữ...";
            this.mnuDoiFont.Click += new System.EventHandler(this.mnuDoiFont_Click);
            // 
            // mnuMacDinh
            // 
            this.mnuMacDinh.Name = "mnuMacDinh";
            this.mnuMacDinh.Size = new System.Drawing.Size(200, 22);
            this.mnuMacDinh.Text = "Khôi phục mặc định";
            this.mnuMacDinh.Click += new System.EventHandler(this.mnuMacDinh_Click);
            // 
            // mnuSep1
            // 
            this.mnuSep1.Name = "mnuSep1";
            this.mnuSep1.Size = new System.Drawing.Size(249, 6);
            // 
            // mnuSaoLuu
            // 
            this.mnuSaoLuu.Name = "mnuSaoLuu";
            this.mnuSaoLuu.Size = new System.Drawing.Size(252, 22);
            this.mnuSaoLuu.Text = "Sao lưu dữ liệu...";
            this.mnuSaoLuu.Click += new System.EventHandler(this.mnuSaoLuu_Click);
            // 
            // mnuPhucHoi
            // 
            this.mnuPhucHoi.Name = "mnuPhucHoi";
            this.mnuPhucHoi.Size = new System.Drawing.Size(252, 22);
            this.mnuPhucHoi.Text = "Phục hồi dữ liệu...";
            this.mnuPhucHoi.Click += new System.EventHandler(this.mnuPhucHoi_Click);
            // 
            // mnuSep2
            // 
            this.mnuSep2.Name = "mnuSep2";
            this.mnuSep2.Size = new System.Drawing.Size(249, 6);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(252, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuQuanLy
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoSo,
            this.mnuPhongBan,
            this.mnuChucVu});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(63, 24);
            this.mnuQuanLy.Text = "Quản lý";
            // 
            // mnuHoSo
            // 
            this.mnuHoSo.Name = "mnuHoSo";
            this.mnuHoSo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuHoSo.Size = new System.Drawing.Size(203, 22);
            this.mnuHoSo.Text = "Hồ sơ nhân viên";
            this.mnuHoSo.Click += new System.EventHandler(this.mnuHoSo_Click);
            // 
            // mnuPhongBan
            // 
            this.mnuPhongBan.Name = "mnuPhongBan";
            this.mnuPhongBan.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.P)));
            this.mnuPhongBan.Size = new System.Drawing.Size(203, 22);
            this.mnuPhongBan.Text = "Phòng ban";
            this.mnuPhongBan.Click += new System.EventHandler(this.mnuPhongBan_Click);
            // 
            // mnuChucVu
            // 
            this.mnuChucVu.Name = "mnuChucVu";
            this.mnuChucVu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.C)));
            this.mnuChucVu.Size = new System.Drawing.Size(203, 22);
            this.mnuChucVu.Text = "Chức vụ";
            this.mnuChucVu.Click += new System.EventHandler(this.mnuChucVu_Click);
            // 
            // mnuNghiepVu
            // 
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChamCong,
            this.mnuTinhLuong});
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Size = new System.Drawing.Size(75, 24);
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuChamCong
            // 
            this.mnuChamCong.Name = "mnuChamCong";
            this.mnuChamCong.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuChamCong.Size = new System.Drawing.Size(228, 22);
            this.mnuChamCong.Text = "Chấm công hằng ngày";
            this.mnuChamCong.Click += new System.EventHandler(this.mnuChamCong_Click);
            // 
            // mnuTinhLuong
            // 
            this.mnuTinhLuong.Name = "mnuTinhLuong";
            this.mnuTinhLuong.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuTinhLuong.Size = new System.Drawing.Size(228, 22);
            this.mnuTinhLuong.Text = "Tính lương tháng";
            this.mnuTinhLuong.Click += new System.EventHandler(this.mnuTinhLuong_Click);
            // 
            // mnuCuaSo
            // 
            this.mnuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXepChong,
            this.mnuXepNgang,
            this.mnuXepDoc});
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Size = new System.Drawing.Size(63, 24);
            this.mnuCuaSo.Text = "Cửa sổ";
            // 
            // mnuXepChong
            // 
            this.mnuXepChong.Name = "mnuXepChong";
            this.mnuXepChong.Size = new System.Drawing.Size(180, 22);
            this.mnuXepChong.Text = "Xếp chồng";
            this.mnuXepChong.Click += new System.EventHandler(this.mnuXepChong_Click);
            // 
            // mnuXepNgang
            // 
            this.mnuXepNgang.Name = "mnuXepNgang";
            this.mnuXepNgang.Size = new System.Drawing.Size(180, 22);
            this.mnuXepNgang.Text = "Xếp ngang";
            this.mnuXepNgang.Click += new System.EventHandler(this.mnuXepNgang_Click);
            // 
            // mnuXepDoc
            // 
            this.mnuXepDoc.Name = "mnuXepDoc";
            this.mnuXepDoc.Size = new System.Drawing.Size(180, 22);
            this.mnuXepDoc.Text = "Xếp dọc";
            this.mnuXepDoc.Click += new System.EventHandler(this.mnuXepDoc_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGioiThieu});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(64, 24);
            this.mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(180, 22);
            this.mnuGioiThieu.Text = "Giới thiệu phần mềm";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung,
            this.lblVaiTro,
            this.lblKhoangTrong,
            this.lblDongHo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(120, 17);
            this.lblNguoiDung.Text = "Người dùng: ---";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(80, 17);
            this.lblVaiTro.Text = "Vai trò: ---";
            // 
            // lblKhoangTrong
            // 
            this.lblKhoangTrong.Name = "lblKhoangTrong";
            this.lblKhoangTrong.Size = new System.Drawing.Size(855, 17);
            this.lblKhoangTrong.Spring = true;
            this.lblKhoangTrong.Text = "";
            // 
            // lblDongHo
            // 
            this.lblDongHo.Name = "lblDongHo";
            this.lblDongHo.Size = new System.Drawing.Size(130, 17);
            this.lblDongHo.Text = "00/00/0000 00:00:00";
            // 
            // timerDongHo
            // 
            this.timerDongHo.Interval = 1000;
            this.timerDongHo.Tick += new System.EventHandler(this.timerDongHo_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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
    }
}
