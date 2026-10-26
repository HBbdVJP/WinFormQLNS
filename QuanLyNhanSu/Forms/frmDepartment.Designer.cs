namespace QuanLyNhanSu.Forms
{
    partial class frmDepartment
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


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            colMa = new ColumnHeader();
            colTen = new ColumnHeader();
            colSoNV = new ColumnHeader();
            grpThongTin = new GroupBox();
            btnUpdateDepartment = new Button();
            txtTenPhong = new TextBox();
            lblTenPhong = new Label();
            txtMaPhong = new TextBox();
            lblMaPhong = new Label();
            lvPhongBan = new ListView();
            panelBottom = new Panel();
            btnExport = new Button();
            btnImportFromFile = new Button();
            btnSaveImmediately = new Button();
            btnLamMoi = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            errorProvider1 = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // colMa
            // 
            colMa.Text = "Mã phòng";
            colMa.Width = 115;
            // 
            // colTen
            // 
            colTen.Text = "Tên phòng ban";
            colTen.Width = 280;
            // 
            // colSoNV
            // 
            colSoNV.Text = "Số nhân viên";
            colSoNV.Width = 130;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(btnUpdateDepartment);
            grpThongTin.Controls.Add(txtTenPhong);
            grpThongTin.Controls.Add(lblTenPhong);
            grpThongTin.Controls.Add(txtMaPhong);
            grpThongTin.Controls.Add(lblMaPhong);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpThongTin.Location = new Point(0, 0);
            grpThongTin.Margin = new Padding(3, 4, 3, 4);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Padding = new Padding(3, 4, 3, 4);
            grpThongTin.Size = new Size(1086, 173);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin phòng ban";
            // 
            // btnUpdateDepartment
            // 
            btnUpdateDepartment.Font = new Font("Segoe UI", 9.75F);
            btnUpdateDepartment.Location = new Point(480, 113);
            btnUpdateDepartment.Name = "btnUpdateDepartment";
            btnUpdateDepartment.Size = new Size(156, 41);
            btnUpdateDepartment.TabIndex = 4;
            btnUpdateDepartment.Text = "Chỉnh sửa";
            btnUpdateDepartment.UseVisualStyleBackColor = true;
            btnUpdateDepartment.Click += btnUpdateDepartment_Click;
            // 
            // txtTenPhong
            // 
            txtTenPhong.Font = new Font("Segoe UI", 9F);
            txtTenPhong.Location = new Point(480, 48);
            txtTenPhong.Margin = new Padding(3, 4, 3, 4);
            txtTenPhong.Name = "txtTenPhong";
            txtTenPhong.Size = new Size(342, 27);
            txtTenPhong.TabIndex = 3;
            // 
            // lblTenPhong
            // 
            lblTenPhong.AutoSize = true;
            lblTenPhong.Font = new Font("Segoe UI", 9F);
            lblTenPhong.Location = new Point(366, 53);
            lblTenPhong.Name = "lblTenPhong";
            lblTenPhong.Size = new Size(82, 20);
            lblTenPhong.TabIndex = 2;
            lblTenPhong.Text = "Tên phòng:";
            // 
            // txtMaPhong
            // 
            txtMaPhong.Font = new Font("Segoe UI", 9F);
            txtMaPhong.Location = new Point(137, 48);
            txtMaPhong.Margin = new Padding(3, 4, 3, 4);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.Size = new Size(194, 27);
            txtMaPhong.TabIndex = 1;
            // 
            // lblMaPhong
            // 
            lblMaPhong.AutoSize = true;
            lblMaPhong.Font = new Font("Segoe UI", 9F);
            lblMaPhong.Location = new Point(23, 53);
            lblMaPhong.Name = "lblMaPhong";
            lblMaPhong.Size = new Size(80, 20);
            lblMaPhong.TabIndex = 0;
            lblMaPhong.Text = "Mã phòng:";
            // 
            // lvPhongBan
            // 
            lvPhongBan.Columns.AddRange(new ColumnHeader[] { colMa, colTen, colSoNV });
            lvPhongBan.Dock = DockStyle.Fill;
            lvPhongBan.FullRowSelect = true;
            lvPhongBan.GridLines = true;
            lvPhongBan.Location = new Point(0, 173);
            lvPhongBan.Margin = new Padding(3, 4, 3, 4);
            lvPhongBan.MultiSelect = false;
            lvPhongBan.Name = "lvPhongBan";
            lvPhongBan.Size = new Size(1086, 440);
            lvPhongBan.TabIndex = 1;
            lvPhongBan.UseCompatibleStateImageBehavior = false;
            lvPhongBan.View = View.Details;
            lvPhongBan.SelectedIndexChanged += lvPhongBan_SelectedIndexChanged;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnExport);
            panelBottom.Controls.Add(btnImportFromFile);
            panelBottom.Controls.Add(btnSaveImmediately);
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Controls.Add(btnHuy);
            panelBottom.Controls.Add(btnLuu);
            panelBottom.Controls.Add(btnXoa);
            panelBottom.Controls.Add(btnThem);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 613);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1086, 72);
            panelBottom.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(878, 14);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(126, 45);
            btnExport.TabIndex = 8;
            btnExport.Text = "Xuất thành File";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnImportFromFile
            // 
            btnImportFromFile.Location = new Point(746, 14);
            btnImportFromFile.Margin = new Padding(3, 4, 3, 4);
            btnImportFromFile.Name = "btnImportFromFile";
            btnImportFromFile.Size = new Size(126, 45);
            btnImportFromFile.TabIndex = 7;
            btnImportFromFile.Text = "Nhập từ File";
            btnImportFromFile.UseVisualStyleBackColor = true;
            btnImportFromFile.Click += btnImportFromFile_Click;
            // 
            // btnSaveImmediately
            // 
            btnSaveImmediately.Location = new Point(374, 14);
            btnSaveImmediately.Margin = new Padding(3, 4, 3, 4);
            btnSaveImmediately.Name = "btnSaveImmediately";
            btnSaveImmediately.Size = new Size(114, 45);
            btnSaveImmediately.TabIndex = 6;
            btnSaveImmediately.Text = "Lưu vào File";
            btnSaveImmediately.UseVisualStyleBackColor = true;
            btnSaveImmediately.Click += btnSaveImmediately_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(614, 14);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(126, 45);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(494, 14);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(114, 45);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(254, 14);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(114, 45);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(134, 14);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
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
            btnThem.Click += btnThem_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // frmDepartment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1086, 685);
            Controls.Add(lvPhongBan);
            Controls.Add(panelBottom);
            Controls.Add(grpThongTin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDepartment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng ban";
            FormClosing += frmEmployee_FormClosing;
            Load += frmDepartment_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.ListView lvPhongBan;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ColumnHeader colMa;
        private ColumnHeader colTen;
        private ColumnHeader colSoNV;
        private Button btnSaveImmediately;
        private Button btnUpdateDepartment;
        private Button btnExport;
        private Button btnImportFromFile;
    }
}
