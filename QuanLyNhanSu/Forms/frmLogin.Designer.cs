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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            pnlLeft = new Panel();
            lblSlogan = new Label();
            lblTenHeThong2 = new Label();
            lblTenHeThong = new Label();
            picLogo = new PictureBox();
            timerKhoa = new System.Windows.Forms.Timer(components);
            lblTitle = new Label();
            lblHuongDan = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkGhiNho = new CheckBox();
            chkHienMatKhau = new CheckBox();
            lblThongBaoLoi = new Label();
            btnDangNhap = new Button();
            btnThoat = new Button();
            btnClose = new Button();
            pnlRight = new Panel();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
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
            pnlLeft.Margin = new Padding(3, 4, 3, 4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(373, 596);
            pnlLeft.TabIndex = 1;
            // 
            // lblSlogan
            // 
            lblSlogan.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSlogan.ForeColor = Color.FromArgb(225, 235, 250);
            lblSlogan.Location = new Point(23, 440);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(343, 106);
            lblSlogan.TabIndex = 3;
            lblSlogan.Text = "Giải pháp quản trị nhân sự\r\ntiện lợi - nhanh chóng - hiện đại";
            lblSlogan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenHeThong2
            // 
            lblTenHeThong2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTenHeThong2.ForeColor = Color.White;
            lblTenHeThong2.Location = new Point(23, 363);
            lblTenHeThong2.Name = "lblTenHeThong2";
            lblTenHeThong2.Size = new Size(343, 59);
            lblTenHeThong2.TabIndex = 2;
            lblTenHeThong2.Text = "NHÂN SỰ";
            lblTenHeThong2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenHeThong
            // 
            lblTenHeThong.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTenHeThong.ForeColor = Color.FromArgb(225, 235, 250);
            lblTenHeThong.Location = new Point(23, 315);
            lblTenHeThong.Name = "lblTenHeThong";
            lblTenHeThong.Size = new Size(343, 40);
            lblTenHeThong.TabIndex = 1;
            lblTenHeThong.Text = "HỆ THỐNG QUẢN LÝ";
            lblTenHeThong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(91, 80);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(206, 240);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // timerKhoa
            // 
            timerKhoa.Interval = 1000;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 108, 223);
            lblTitle.Location = new Point(57, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(364, 41);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // lblHuongDan
            // 
            lblHuongDan.AutoSize = true;
            lblHuongDan.ForeColor = Color.FromArgb(140, 140, 140);
            lblHuongDan.Location = new Point(63, 117);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(280, 20);
            lblHuongDan.TabIndex = 12;
            lblHuongDan.Text = "Vui lòng đăng nhập để sử dụng hệ thống";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.FromArgb(70, 70, 70);
            lblUsername.Location = new Point(59, 168);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(110, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(63, 197);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(457, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.FromArgb(70, 70, 70);
            lblPassword.Location = new Point(59, 255);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(63, 284);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(457, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkGhiNho
            // 
            chkGhiNho.AutoSize = true;
            chkGhiNho.ForeColor = Color.FromArgb(90, 90, 90);
            chkGhiNho.Location = new Point(63, 332);
            chkGhiNho.Margin = new Padding(3, 4, 3, 4);
            chkGhiNho.Name = "chkGhiNho";
            chkGhiNho.Size = new Size(157, 24);
            chkGhiNho.TabIndex = 4;
            chkGhiNho.Text = "Ghi nhớ đăng nhập";
            chkGhiNho.UseVisualStyleBackColor = true;
            chkGhiNho.CheckedChanged += chkGhiNho_CheckedChanged;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.ForeColor = Color.FromArgb(90, 90, 90);
            chkHienMatKhau.Location = new Point(306, 332);
            chkHienMatKhau.Margin = new Padding(3, 4, 3, 4);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(127, 24);
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // lblThongBaoLoi
            // 
            lblThongBaoLoi.ForeColor = Color.FromArgb(200, 30, 30);
            lblThongBaoLoi.Location = new Point(59, 371);
            lblThongBaoLoi.Name = "lblThongBaoLoi";
            lblThongBaoLoi.Size = new Size(464, 32);
            lblThongBaoLoi.TabIndex = 6;
            lblThongBaoLoi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(45, 108, 223);
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(63, 414);
            btnDangNhap.Margin = new Padding(3, 4, 3, 4);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(457, 64);
            btnDangNhap.TabIndex = 7;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(120, 130, 145);
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(63, 492);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(456, 48);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(120, 120, 120);
            btnClose.Location = new Point(499, 8);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(39, 45);
            btnClose.TabIndex = 11;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(btnThoat);
            pnlRight.Controls.Add(btnDangNhap);
            pnlRight.Controls.Add(lblThongBaoLoi);
            pnlRight.Controls.Add(chkHienMatKhau);
            pnlRight.Controls.Add(chkGhiNho);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(lblHuongDan);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(373, 0);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(564, 596);
            pnlRight.TabIndex = 0;
            pnlRight.Paint += pnlRight_Paint;
            // 
            // frmLogin
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(937, 596);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            Load += frmLogin_Load;
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTenHeThong;
        private System.Windows.Forms.Label lblTenHeThong2;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Timer timerKhoa;
        private Label lblTitle;
        private Label lblHuongDan;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkGhiNho;
        private CheckBox chkHienMatKhau;
        private Label lblThongBaoLoi;
        private Button btnDangNhap;
        private Button btnThoat;
        private Button btnClose;
        private Panel pnlRight;
    }
}
