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
            System.Windows.Forms.ColumnHeader colMa;
            System.Windows.Forms.ColumnHeader colTen;
            System.Windows.Forms.ColumnHeader colHeSo;
            System.Windows.Forms.ColumnHeader colSoNV;
            this.components = new System.ComponentModel.Container();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.nudHeSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblHeSoLuong = new System.Windows.Forms.Label();
            this.txtTenChucVu = new System.Windows.Forms.TextBox();
            this.lblTenChucVu = new System.Windows.Forms.Label();
            this.txtMaChucVu = new System.Windows.Forms.TextBox();
            this.lblMaChucVu = new System.Windows.Forms.Label();
            this.lvChucVu = new System.Windows.Forms.ListView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeSoLuong)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.nudHeSoLuong);
            this.grpThongTin.Controls.Add(this.lblHeSoLuong);
            this.grpThongTin.Controls.Add(this.txtTenChucVu);
            this.grpThongTin.Controls.Add(this.lblTenChucVu);
            this.grpThongTin.Controls.Add(this.txtMaChucVu);
            this.grpThongTin.Controls.Add(this.lblMaChucVu);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(0, 0);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(900, 130);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin chức vụ";
            // 
            // nudHeSoLuong
            // 
            this.nudHeSoLuong.DecimalPlaces = 2;
            this.nudHeSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudHeSoLuong.Location = new System.Drawing.Point(120, 80);
            this.nudHeSoLuong.Maximum = new decimal(new int[] { 20, 0, 0, 0});
            this.nudHeSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0});
            this.nudHeSoLuong.Name = "nudHeSoLuong";
            this.nudHeSoLuong.Size = new System.Drawing.Size(120, 23);
            this.nudHeSoLuong.TabIndex = 5;
            this.nudHeSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0});
            // 
            // lblHeSoLuong
            // 
            this.lblHeSoLuong.AutoSize = true;
            this.lblHeSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeSoLuong.Location = new System.Drawing.Point(20, 84);
            this.lblHeSoLuong.Name = "lblHeSoLuong";
            this.lblHeSoLuong.Size = new System.Drawing.Size(77, 15);
            this.lblHeSoLuong.TabIndex = 4;
            this.lblHeSoLuong.Text = "Hệ số lương:";
            // 
            // txtTenChucVu
            // 
            this.txtTenChucVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenChucVu.Location = new System.Drawing.Point(420, 36);
            this.txtTenChucVu.Name = "txtTenChucVu";
            this.txtTenChucVu.Size = new System.Drawing.Size(300, 23);
            this.txtTenChucVu.TabIndex = 3;
            // 
            // lblTenChucVu
            // 
            this.lblTenChucVu.AutoSize = true;
            this.lblTenChucVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenChucVu.Location = new System.Drawing.Point(320, 40);
            this.lblTenChucVu.Name = "lblTenChucVu";
            this.lblTenChucVu.Size = new System.Drawing.Size(66, 15);
            this.lblTenChucVu.TabIndex = 2;
            this.lblTenChucVu.Text = "Tên chức vụ:";
            // 
            // txtMaChucVu
            // 
            this.txtMaChucVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaChucVu.Location = new System.Drawing.Point(120, 36);
            this.txtMaChucVu.Name = "txtMaChucVu";
            this.txtMaChucVu.Size = new System.Drawing.Size(170, 23);
            this.txtMaChucVu.TabIndex = 1;
            // 
            // lblMaChucVu
            // 
            this.lblMaChucVu.AutoSize = true;
            this.lblMaChucVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaChucVu.Location = new System.Drawing.Point(20, 40);
            this.lblMaChucVu.Name = "lblMaChucVu";
            this.lblMaChucVu.Size = new System.Drawing.Size(64, 15);
            this.lblMaChucVu.TabIndex = 0;
            this.lblMaChucVu.Text = "Mã chức vụ:";
            // 
            // lvChucVu
            // 
            colMa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colHeSo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colSoNV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colMa.Text = "Mã chức vụ";
            colMa.Width = 125;
            colTen.Text = "Tên chức vụ";
            colTen.Width = 290;
            colHeSo.Text = "Hệ số lương";
            colHeSo.Width = 140;
            colSoNV.Text = "Số nhân viên";
            colSoNV.Width = 140;
            this.lvChucVu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colMa,
            colTen,
            colHeSo,
            colSoNV});
            this.lvChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChucVu.FullRowSelect = true;
            this.lvChucVu.GridLines = true;
            this.lvChucVu.HideSelection = false;
            this.lvChucVu.Location = new System.Drawing.Point(0, 130);
            this.lvChucVu.MultiSelect = false;
            this.lvChucVu.Name = "lvChucVu";
            this.lvChucVu.Size = new System.Drawing.Size(900, 296);
            this.lvChucVu.TabIndex = 1;
            this.lvChucVu.UseCompatibleStateImageBehavior = false;
            this.lvChucVu.View = System.Windows.Forms.View.Details;
            this.lvChucVu.SelectedIndexChanged += new System.EventHandler(this.lvChucVu_SelectedIndexChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnLamMoi);
            this.panelBottom.Controls.Add(this.btnHuy);
            this.panelBottom.Controls.Add(this.btnLuu);
            this.panelBottom.Controls.Add(this.btnXoa);
            this.panelBottom.Controls.Add(this.btnSua);
            this.panelBottom.Controls.Add(this.btnThem);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 426);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 54);
            this.panelBottom.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(562, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(452, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 34);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(342, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 34);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(232, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(122, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 34);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.lvChucVu);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.grpThongTin);
            this.Name = "frmPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý chức vụ";
            this.Load += new System.EventHandler(this.frmPosition_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeSoLuong)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaChucVu;
        private System.Windows.Forms.TextBox txtMaChucVu;
        private System.Windows.Forms.Label lblTenChucVu;
        private System.Windows.Forms.TextBox txtTenChucVu;
        private System.Windows.Forms.Label lblHeSoLuong;
        private System.Windows.Forms.NumericUpDown nudHeSoLuong;
        private System.Windows.Forms.ListView lvChucVu;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
