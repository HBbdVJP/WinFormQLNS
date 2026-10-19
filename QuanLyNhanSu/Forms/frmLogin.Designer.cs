namespace QuanLyNhanSu.Forms
{
    partial class frmLogin
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
            pnlRight = new Panel();
            btnClose = new Button();
            btnThoat = new Button();
            btnDangNhap = new Button();
            lblLoi = new Label();
            chkHienMatKhau = new CheckBox();
            chkGhiNho = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblHuongDan = new Label();
            lblTitle = new Label();
            pnlLeft = new Panel();
            lblSlogan = new Label();
            lblTenHeThong2 = new Label();
            lblTenHeThong = new Label();
            picLogo = new PictureBox();
            timerKhoa = new System.Windows.Forms.Timer(components);
            pnlRight.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(btnThoat);
            pnlRight.Controls.Add(btnDangNhap);
            pnlRight.Controls.Add(lblLoi);
            pnlRight.Controls.Add(chkHienMatKhau);
            pnlRight.Controls.Add(chkGhiNho);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(lblHuongDan);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(729, 0);
            pnlRight.Margin = new Padding(6, 7, 6, 7);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1028, 1135);
            pnlRight.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(120, 120, 120);
            btnClose.Location = new Point(936, 15);
            btnClose.Margin = new Padding(6, 7, 6, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(73, 84);
            btnClose.TabIndex = 11;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(120, 130, 145);
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(118, 911);
            btnThoat.Margin = new Padding(6, 7, 6, 7);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(855, 89);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(45, 108, 223);
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(118, 765);
            btnDangNhap.Margin = new Padding(6, 7, 6, 7);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(857, 118);
            btnDangNhap.TabIndex = 7;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblLoi
            // 
            lblLoi.ForeColor = Color.FromArgb(200, 30, 30);
            lblLoi.Location = new Point(111, 686);
            lblLoi.Margin = new Padding(6, 0, 6, 0);
            lblLoi.Name = "lblLoi";
            lblLoi.Size = new Size(870, 59);
            lblLoi.TabIndex = 6;
            lblLoi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.ForeColor = Color.FromArgb(90, 90, 90);
            chkHienMatKhau.Location = new Point(574, 614);
            chkHienMatKhau.Margin = new Padding(6, 7, 6, 7);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(221, 41);
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // chkGhiNho
            // 
            chkGhiNho.AutoSize = true;
            chkGhiNho.ForeColor = Color.FromArgb(90, 90, 90);
            chkGhiNho.Location = new Point(118, 614);
            chkGhiNho.Margin = new Padding(6, 7, 6, 7);
            chkGhiNho.Name = "chkGhiNho";
            chkGhiNho.Size = new Size(278, 41);
            chkGhiNho.TabIndex = 4;
            chkGhiNho.Text = "Ghi nhớ đăng nhập";
            chkGhiNho.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(118, 525);
            txtPassword.Margin = new Padding(6, 7, 6, 7);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(855, 43);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.FromArgb(70, 70, 70);
            lblPassword.Location = new Point(111, 471);
            lblPassword.Margin = new Padding(6, 0, 6, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(134, 37);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(118, 365);
            txtUsername.Margin = new Padding(6, 7, 6, 7);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(855, 43);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.FromArgb(70, 70, 70);
            lblUsername.Location = new Point(111, 311);
            lblUsername.Margin = new Padding(6, 0, 6, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(198, 37);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblHuongDan
            // 
            lblHuongDan.AutoSize = true;
            lblHuongDan.ForeColor = Color.FromArgb(140, 140, 140);
            lblHuongDan.Location = new Point(118, 217);
            lblHuongDan.Margin = new Padding(6, 0, 6, 0);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(505, 37);
            lblHuongDan.TabIndex = 12;
            lblHuongDan.Text = "Vui lòng đăng nhập để sử dụng hệ thống";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 108, 223);
            lblTitle.Location = new Point(107, 111);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(654, 72);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(45, 108, 223);
            pnlLeft.Controls.Add(lblSlogan);
            pnlLeft.Controls.Add(lblTenHeThong2);
            pnlLeft.Controls.Add(lblTenHeThong);
            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(6, 7, 6, 7);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(729, 1135);
            pnlLeft.TabIndex = 1;
            // 
            // lblSlogan
            // 
            lblSlogan.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSlogan.ForeColor = Color.FromArgb(225, 235, 250);
            lblSlogan.Location = new Point(43, 814);
            lblSlogan.Margin = new Padding(6, 0, 6, 0);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(643, 197);
            lblSlogan.TabIndex = 3;
            lblSlogan.Text = "Giải pháp quản trị nhân sự\r\ntiện lợi - nhanh chóng - hiện đại";
            lblSlogan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenHeThong2
            // 
            lblTenHeThong2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTenHeThong2.ForeColor = Color.White;
            lblTenHeThong2.Location = new Point(43, 671);
            lblTenHeThong2.Margin = new Padding(6, 0, 6, 0);
            lblTenHeThong2.Name = "lblTenHeThong2";
            lblTenHeThong2.Size = new Size(643, 109);
            lblTenHeThong2.TabIndex = 2;
            lblTenHeThong2.Text = "NHÂN SỰ";
            lblTenHeThong2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenHeThong
            // 
            lblTenHeThong.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTenHeThong.ForeColor = Color.FromArgb(225, 235, 250);
            lblTenHeThong.Location = new Point(43, 582);
            lblTenHeThong.Margin = new Padding(6, 0, 6, 0);
            lblTenHeThong.Name = "lblTenHeThong";
            lblTenHeThong.Size = new Size(643, 74);
            lblTenHeThong.TabIndex = 1;
            lblTenHeThong.Text = "HỆ THỐNG QUẢN LÝ";
            lblTenHeThong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.ảnh_icon;
            picLogo.Location = new Point(171, 148);
            picLogo.Margin = new Padding(6, 7, 6, 7);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(386, 444);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // timerKhoa
            // 
            timerKhoa.Interval = 1000;
            timerKhoa.Tick += timerKhoa_Tick;
            // 
            // frmLogin
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1757, 1135);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            Load += frmLogin_Load;
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTenHeThong;
        private System.Windows.Forms.Label lblTenHeThong2;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkGhiNho;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Label lblLoi;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerKhoa;
    }
}
