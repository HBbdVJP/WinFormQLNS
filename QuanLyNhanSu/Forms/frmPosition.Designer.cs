namespace QuanLyNhanSu.Forms
{
    partial class frmPosition
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
            colMa = new ColumnHeader();
            colTen = new ColumnHeader();
            colPhuCap = new ColumnHeader();
            colSoNV = new ColumnHeader();
            grpThongTin = new GroupBox();
            lblPhuCap = new Label();
            txtTenChucVu = new TextBox();
            lblTenChucVu = new Label();
            txtMaChucVu = new TextBox();
            lblMaChucVu = new Label();
            lvChucVu = new ListView();
            panelBottom = new Panel();
            btnLamMoi = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            errorProvider1 = new ErrorProvider(components);
            txtPhuCapThang = new TextBox();
            grpThongTin.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // colMa
            // 
            colMa.Text = "Mã chức vụ";
            colMa.Width = 125;
            // 
            // colTen
            // 
            colTen.Text = "Tên chức vụ";
            colTen.Width = 290;
            // 
            // colPhuCap
            // 
            colPhuCap.Text = "Phụ Cấp Tháng";
            colPhuCap.Width = 200;
            // 
            // colSoNV
            // 
            colSoNV.Text = "Số nhân viên";
            colSoNV.Width = 140;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(txtPhuCapThang);
            grpThongTin.Controls.Add(lblPhuCap);
            grpThongTin.Controls.Add(txtTenChucVu);
            grpThongTin.Controls.Add(lblTenChucVu);
            grpThongTin.Controls.Add(txtMaChucVu);
            grpThongTin.Controls.Add(lblMaChucVu);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Margin = new Padding(3, 4, 3, 4);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Padding = new Padding(3, 4, 3, 4);
            grpThongTin.Size = new Size(1029, 173);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin chức vụ";
            // 
            // lblPhuCap
            // 
            lblPhuCap.AutoSize = true;
            lblPhuCap.Font = new Font("Segoe UI", 9F);
            lblPhuCap.Location = new Point(23, 112);
            lblPhuCap.Name = "lblPhuCap";
            lblPhuCap.Size = new Size(103, 20);
            lblPhuCap.TabIndex = 4;
            lblPhuCap.Text = "Phụ cấp tháng";
            // 
            // txtTenChucVu
            // 
            txtTenChucVu.Font = new Font("Segoe UI", 9F);
            txtTenChucVu.Location = new Point(480, 48);
            txtTenChucVu.Margin = new Padding(3, 4, 3, 4);
            txtTenChucVu.Name = "txtTenChucVu";
            txtTenChucVu.Size = new Size(342, 27);
            txtTenChucVu.TabIndex = 3;
            // 
            // lblTenChucVu
            // 
            lblTenChucVu.AutoSize = true;
            lblTenChucVu.Font = new Font("Segoe UI", 9F);
            lblTenChucVu.Location = new Point(366, 53);
            lblTenChucVu.Name = "lblTenChucVu";
            lblTenChucVu.Size = new Size(89, 20);
            lblTenChucVu.TabIndex = 2;
            lblTenChucVu.Text = "Tên chức vụ:";
            // 
            // txtMaChucVu
            // 
            txtMaChucVu.Font = new Font("Segoe UI", 9F);
            txtMaChucVu.Location = new Point(137, 48);
            txtMaChucVu.Margin = new Padding(3, 4, 3, 4);
            txtMaChucVu.Name = "txtMaChucVu";
            txtMaChucVu.Size = new Size(194, 27);
            txtMaChucVu.TabIndex = 1;
            // 
            // lblMaChucVu
            // 
            lblMaChucVu.AutoSize = true;
            lblMaChucVu.Font = new Font("Segoe UI", 9F);
            lblMaChucVu.Location = new Point(23, 53);
            lblMaChucVu.Name = "lblMaChucVu";
            lblMaChucVu.Size = new Size(87, 20);
            lblMaChucVu.TabIndex = 0;
            lblMaChucVu.Text = "Mã chức vụ:";
            // 
            // lvChucVu
            // 
            lvChucVu.Columns.AddRange(new ColumnHeader[] { colMa, colTen, colPhuCap, colSoNV });
            lvChucVu.Dock = DockStyle.Fill;
            lvChucVu.FullRowSelect = true;
            lvChucVu.GridLines = true;
            lvChucVu.Location = new Point(0, 173);
            lvChucVu.Margin = new Padding(3, 4, 3, 4);
            lvChucVu.MultiSelect = false;
            lvChucVu.Name = "lvChucVu";
            lvChucVu.Size = new Size(1029, 395);
            lvChucVu.TabIndex = 1;
            lvChucVu.UseCompatibleStateImageBehavior = false;
            lvChucVu.View = View.Details;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Controls.Add(btnHuy);
            panelBottom.Controls.Add(btnLuu);
            panelBottom.Controls.Add(btnXoa);
            panelBottom.Controls.Add(btnSua);
            panelBottom.Controls.Add(btnThem);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 568);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1029, 72);
            panelBottom.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(642, 13);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(126, 45);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(517, 13);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(114, 45);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(391, 13);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(114, 45);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(265, 13);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(139, 13);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(114, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(14, 13);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // txtPhuCapThang
            // 
            txtPhuCapThang.Location = new Point(137, 108);
            txtPhuCapThang.Name = "txtPhuCapThang";
            txtPhuCapThang.Size = new Size(194, 29);
            txtPhuCapThang.TabIndex = 5;
            // 
            // frmPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1029, 640);
            Controls.Add(lvChucVu);
            Controls.Add(panelBottom);
            Controls.Add(grpThongTin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPosition";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý chức vụ";
            Load += frmPosition_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaChucVu;
        private System.Windows.Forms.TextBox txtMaChucVu;
        private System.Windows.Forms.Label lblTenChucVu;
        private System.Windows.Forms.TextBox txtTenChucVu;
        private System.Windows.Forms.Label lblPhuCap;
        private System.Windows.Forms.ListView lvChucVu;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ColumnHeader colMa;
        private ColumnHeader colTen;
        private ColumnHeader colPhuCap;
        private ColumnHeader colSoNV;
        private TextBox txtPhuCapThang;
    }
}
