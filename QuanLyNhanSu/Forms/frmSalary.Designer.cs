namespace QuanLyNhanSu.Forms
{
    partial class frmSalary
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
            colMa = new ColumnHeader();
            colTen = new ColumnHeader();
            colLuongCB = new ColumnHeader();
            colNgayLam = new ColumnHeader();
            colDiTre = new ColumnHeader();
            colTangCa = new ColumnHeader();
            colPhep = new ColumnHeader();
            colTong = new ColumnHeader();
            panelTop = new Panel();
            btnXem = new Button();
            cboPhong = new ComboBox();
            lblPhong = new Label();
            nudNam = new NumericUpDown();
            lblNam = new Label();
            cboThang = new ComboBox();
            lblThang = new Label();
            lvLuong = new ListView();
            panelBottom = new Panel();
            lblThongTin = new Label();
            btnXuatBangLuong = new Button();
            btnXuatPhieuLuong = new Button();
            btnTinhLuong = new Button();
            saveFileDialog1 = new SaveFileDialog();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // colMa
            // 
            colMa.Text = "Mã NV";
            colMa.Width = 95;
            // 
            // colTen
            // 
            colTen.Text = "Tên NV";
            colTen.Width = 210;
            // 
            // colLuongCB
            // 
            colLuongCB.Text = "Lương cơ bản";
            colLuongCB.Width = 140;
            // 
            // colNgayLam
            // 
            colNgayLam.Text = "Ngày làm thực tế";
            colNgayLam.Width = 140;
            // 
            // colDiTre
            // 
            colDiTre.Text = "Số lần đi trễ";
            colDiTre.Width = 115;
            // 
            // colTangCa
            // 
            colTangCa.Text = "Số giờ tăng ca";
            colTangCa.Width = 130;
            // 
            // colPhep
            // 
            colPhep.Text = "Phép năm còn lại";
            colPhep.Width = 130;
            // 
            // colTong
            // 
            colTong.Text = "TỔNG LƯƠNG";
            colTong.Width = 165;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnXem);
            panelTop.Controls.Add(cboPhong);
            panelTop.Controls.Add(lblPhong);
            panelTop.Controls.Add(nudNam);
            panelTop.Controls.Add(lblNam);
            panelTop.Controls.Add(cboThang);
            panelTop.Controls.Add(lblThang);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(898, 58);
            panelTop.TabIndex = 0;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(660, 15);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(150, 30);
            btnXem.TabIndex = 6;
            btnXem.Text = "Xem bảng lương";
            btnXem.UseVisualStyleBackColor = true;
            // 
            // cboPhong
            // 
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(420, 18);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(220, 23);
            cboPhong.TabIndex = 5;
            // 
            // lblPhong
            // 
            lblPhong.AutoSize = true;
            lblPhong.Location = new Point(343, 19);
            lblPhong.Name = "lblPhong";
            lblPhong.Size = new Size(68, 15);
            lblPhong.TabIndex = 4;
            lblPhong.Text = "Phòng ban:";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(240, 18);
            nudNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(90, 23);
            nudNam.TabIndex = 3;
            nudNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblNam
            // 
            lblNam.AutoSize = true;
            lblNam.Location = new Point(191, 19);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(36, 15);
            lblNam.TabIndex = 2;
            lblNam.Text = "Năm:";
            // 
            // cboThang
            // 
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.FormattingEnabled = true;
            cboThang.Location = new Point(72, 18);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(100, 23);
            cboThang.TabIndex = 1;
            // 
            // lblThang
            // 
            lblThang.AutoSize = true;
            lblThang.Location = new Point(15, 22);
            lblThang.Name = "lblThang";
            lblThang.Size = new Size(44, 15);
            lblThang.TabIndex = 0;
            lblThang.Text = "Tháng:";
            // 
            // lvLuong
            // 
            lvLuong.Columns.AddRange(new ColumnHeader[] { colMa, colTen, colLuongCB, colNgayLam, colDiTre, colTangCa, colPhep, colTong });
            lvLuong.Dock = DockStyle.Fill;
            lvLuong.FullRowSelect = true;
            lvLuong.GridLines = true;
            lvLuong.Location = new Point(0, 58);
            lvLuong.MultiSelect = false;
            lvLuong.Name = "lvLuong";
            lvLuong.Size = new Size(898, 314);
            lvLuong.TabIndex = 1;
            lvLuong.UseCompatibleStateImageBehavior = false;
            lvLuong.View = View.Details;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblThongTin);
            panelBottom.Controls.Add(btnXuatBangLuong);
            panelBottom.Controls.Add(btnXuatPhieuLuong);
            panelBottom.Controls.Add(btnTinhLuong);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 372);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(898, 58);
            panelBottom.TabIndex = 2;
            // 
            // lblThongTin
            // 
            lblThongTin.AutoSize = true;
            lblThongTin.Location = new Point(640, 23);
            lblThongTin.Name = "lblThongTin";
            lblThongTin.Size = new Size(90, 15);
            lblThongTin.TabIndex = 3;
            lblThongTin.Text = "Chưa có dữ liệu";
            // 
            // btnXuatBangLuong
            // 
            btnXuatBangLuong.Location = new Point(390, 12);
            btnXuatBangLuong.Name = "btnXuatBangLuong";
            btnXuatBangLuong.Size = new Size(220, 34);
            btnXuatBangLuong.TabIndex = 2;
            btnXuatBangLuong.Text = "Xuất Bảng Lương (CSV)...";
            btnXuatBangLuong.UseVisualStyleBackColor = true;
            // 
            // btnXuatPhieuLuong
            // 
            btnXuatPhieuLuong.Location = new Point(165, 12);
            btnXuatPhieuLuong.Name = "btnXuatPhieuLuong";
            btnXuatPhieuLuong.Size = new Size(215, 34);
            btnXuatPhieuLuong.TabIndex = 1;
            btnXuatPhieuLuong.Text = "Xuất Phiếu Lương (TXT)...";
            btnXuatPhieuLuong.UseVisualStyleBackColor = true;
            // 
            // btnTinhLuong
            // 
            btnTinhLuong.Location = new Point(15, 12);
            btnTinhLuong.Name = "btnTinhLuong";
            btnTinhLuong.Size = new Size(140, 34);
            btnTinhLuong.TabIndex = 0;
            btnTinhLuong.Text = "Tính lương";
            btnTinhLuong.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Title = "Lưu tập tin";
            // 
            // frmSalary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(898, 430);
            Controls.Add(lvLuong);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "frmSalary";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tính lương và phiếu lương";
            WindowState = FormWindowState.Maximized;
            Load += frmSalary_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown nudNam;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ListView lvLuong;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnXuatPhieuLuong;
        private System.Windows.Forms.Button btnXuatBangLuong;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ColumnHeader colMa;
        private ColumnHeader colTen;
        private ColumnHeader colLuongCB;
        private ColumnHeader colNgayLam;
        private ColumnHeader colDiTre;
        private ColumnHeader colTangCa;
        private ColumnHeader colPhep;
        private ColumnHeader colTong;
    }
}
