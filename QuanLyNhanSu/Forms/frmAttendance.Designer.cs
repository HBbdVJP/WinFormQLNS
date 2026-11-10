namespace QuanLyNhanSu.Forms
{
    partial class frmAttendance
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
            colChon = new ColumnHeader();
            colMa = new ColumnHeader();
            colTen = new ColumnHeader();
            colPhong = new ColumnHeader();
            colTrangThai = new ColumnHeader();
            colTangCa = new ColumnHeader();
            colGhiChu = new ColumnHeader();
            panelTop = new Panel();
            btnNextDay = new Button();
            btnPrevDay = new Button();
            lblCanhBao = new Label();
            btnTaiDanhSach = new Button();
            btnNhapCSV = new Button();
            cboPhong = new ComboBox();
            lblPhong = new Label();
            dtpNgay = new DateTimePicker();
            lblNgay = new Label();
            lvChamCong = new ListView();
            cmsTrangThai = new ContextMenuStrip(components);
            mnuDiLam = new ToolStripMenuItem();
            mnuNghiPhep = new ToolStripMenuItem();
            mnuNghiKhongPhep = new ToolStripMenuItem();
            mnuDiTre = new ToolStripMenuItem();
            sepTrangThai = new ToolStripSeparator();
            mnuTangCa = new ToolStripMenuItem();
            mnuGhiChu = new ToolStripMenuItem();
            panelBottom = new Panel();
            btnSaveToFile = new Button();
            btnLuuBangCong = new Button();
            lblTong = new Label();
            btnBoChon = new Button();
            btnChonTatCa = new Button();
            openFileDialogCSV = new OpenFileDialog();
            panelTop.SuspendLayout();
            cmsTrangThai.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // colChon
            // 
            colChon.Text = "Đi làm";
            colChon.Width = 75;
            // 
            // colMa
            // 
            colMa.Text = "Mã NV";
            colMa.Width = 95;
            // 
            // colTen
            // 
            colTen.Text = "Họ và tên";
            colTen.Width = 220;
            // 
            // colPhong
            // 
            colPhong.Text = "Phòng ban";
            colPhong.Width = 175;
            // 
            // colTrangThai
            // 
            colTrangThai.Text = "Trạng thái";
            colTrangThai.Width = 140;
            // 
            // colTangCa
            // 
            colTangCa.Text = "Giờ tăng ca";
            colTangCa.Width = 125;
            // 
            // colGhiChu
            // 
            colGhiChu.Text = "Ghi chú";
            colGhiChu.Width = 280;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnNextDay);
            panelTop.Controls.Add(btnPrevDay);
            panelTop.Controls.Add(lblCanhBao);
            panelTop.Controls.Add(btnTaiDanhSach);
            panelTop.Controls.Add(btnNhapCSV);
            panelTop.Controls.Add(cboPhong);
            panelTop.Controls.Add(lblPhong);
            panelTop.Controls.Add(dtpNgay);
            panelTop.Controls.Add(lblNgay);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1026, 77);
            panelTop.TabIndex = 0;
            // 
            // btnNextDay
            // 
            btnNextDay.Enabled = false;
            btnNextDay.Location = new Point(230, 41);
            btnNextDay.Name = "btnNextDay";
            btnNextDay.Size = new Size(83, 29);
            btnNextDay.TabIndex = 8;
            btnNextDay.Text = ">";
            btnNextDay.UseVisualStyleBackColor = true;
            btnNextDay.Click += btnNextDay_Click;
            // 
            // btnPrevDay
            // 
            btnPrevDay.Location = new Point(142, 41);
            btnPrevDay.Name = "btnPrevDay";
            btnPrevDay.Size = new Size(82, 29);
            btnPrevDay.TabIndex = 7;
            btnPrevDay.Text = "<";
            btnPrevDay.UseVisualStyleBackColor = true;
            btnPrevDay.Click += btnPrevDay_Click;
            // 
            // lblCanhBao
            // 
            lblCanhBao.AutoSize = true;
            lblCanhBao.ForeColor = Color.FromArgb(200, 30, 30);
            lblCanhBao.Location = new Point(1051, 29);
            lblCanhBao.Name = "lblCanhBao";
            lblCanhBao.Size = new Size(0, 20);
            lblCanhBao.TabIndex = 6;
            // 
            // btnTaiDanhSach
            // 
            btnTaiDanhSach.Location = new Point(854, 20);
            btnTaiDanhSach.Margin = new Padding(3, 4, 3, 4);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(160, 40);
            btnTaiDanhSach.TabIndex = 5;
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.UseVisualStyleBackColor = true;
            // 
            // btnNhapCSV
            // 
            btnNhapCSV.Location = new Point(688, 20);
            btnNhapCSV.Margin = new Padding(3, 4, 3, 4);
            btnNhapCSV.Name = "btnNhapCSV";
            btnNhapCSV.Size = new Size(160, 40);
            btnNhapCSV.TabIndex = 4;
            btnNhapCSV.Text = "Nhập từ CSV...";
            btnNhapCSV.UseVisualStyleBackColor = true;
            // 
            // cboPhong
            // 
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(432, 11);
            cboPhong.Margin = new Padding(3, 4, 3, 4);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(239, 28);
            cboPhong.TabIndex = 3;
            // 
            // lblPhong
            // 
            lblPhong.AutoSize = true;
            lblPhong.Location = new Point(343, 14);
            lblPhong.Name = "lblPhong";
            lblPhong.Size = new Size(83, 20);
            lblPhong.TabIndex = 2;
            lblPhong.Text = "Phòng ban:";
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(142, 9);
            dtpNgay.Margin = new Padding(3, 4, 3, 4);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(171, 27);
            dtpNgay.TabIndex = 1;
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            // 
            // lblNgay
            // 
            lblNgay.AutoSize = true;
            lblNgay.Location = new Point(12, 14);
            lblNgay.Name = "lblNgay";
            lblNgay.Size = new Size(124, 20);
            lblNgay.TabIndex = 0;
            lblNgay.Text = "Ngày chấm công:";
            // 
            // lvChamCong
            // 
            lvChamCong.CheckBoxes = true;
            lvChamCong.Columns.AddRange(new ColumnHeader[] { colChon, colMa, colTen, colPhong, colTrangThai, colTangCa, colGhiChu });
            lvChamCong.ContextMenuStrip = cmsTrangThai;
            lvChamCong.Dock = DockStyle.Fill;
            lvChamCong.FullRowSelect = true;
            lvChamCong.GridLines = true;
            lvChamCong.Location = new Point(0, 77);
            lvChamCong.Margin = new Padding(3, 4, 3, 4);
            lvChamCong.Name = "lvChamCong";
            lvChamCong.Size = new Size(1026, 418);
            lvChamCong.TabIndex = 1;
            lvChamCong.UseCompatibleStateImageBehavior = false;
            lvChamCong.View = View.Details;
            // 
            // cmsTrangThai
            // 
            cmsTrangThai.ImageScalingSize = new Size(36, 36);
            cmsTrangThai.Items.AddRange(new ToolStripItem[] { mnuDiLam, mnuNghiPhep, mnuNghiKhongPhep, mnuDiTre, sepTrangThai, mnuTangCa, mnuGhiChu });
            cmsTrangThai.Name = "cmsTrangThai";
            cmsTrangThai.Size = new Size(257, 154);
            // 
            // mnuDiLam
            // 
            mnuDiLam.Name = "mnuDiLam";
            mnuDiLam.Size = new Size(256, 24);
            mnuDiLam.Text = "Đánh dấu Đi làm";
            // 
            // mnuNghiPhep
            // 
            mnuNghiPhep.Name = "mnuNghiPhep";
            mnuNghiPhep.Size = new Size(256, 24);
            mnuNghiPhep.Text = "Đổi sang Nghỉ phép";
            // 
            // mnuNghiKhongPhep
            // 
            mnuNghiKhongPhep.Name = "mnuNghiKhongPhep";
            mnuNghiKhongPhep.Size = new Size(256, 24);
            mnuNghiKhongPhep.Text = "Đổi sang Nghỉ không phép";
            // 
            // mnuDiTre
            // 
            mnuDiTre.Name = "mnuDiTre";
            mnuDiTre.Size = new Size(256, 24);
            mnuDiTre.Text = "Đổi sang Đi trễ";
            // 
            // sepTrangThai
            // 
            sepTrangThai.Name = "sepTrangThai";
            sepTrangThai.Size = new Size(253, 6);
            // 
            // mnuTangCa
            // 
            mnuTangCa.Name = "mnuTangCa";
            mnuTangCa.Size = new Size(256, 24);
            mnuTangCa.Text = "Đánh dấu Tăng ca...";
            mnuTangCa.Click += mnuTangCa_Click;
            // 
            // mnuGhiChu
            // 
            mnuGhiChu.Name = "mnuGhiChu";
            mnuGhiChu.Size = new Size(256, 24);
            mnuGhiChu.Text = "Nhập/sửa ghi chú...";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnSaveToFile);
            panelBottom.Controls.Add(btnLuuBangCong);
            panelBottom.Controls.Add(lblTong);
            panelBottom.Controls.Add(btnBoChon);
            panelBottom.Controls.Add(btnChonTatCa);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 495);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1026, 75);
            panelBottom.TabIndex = 2;
            // 
            // btnSaveToFile
            // 
            btnSaveToFile.Location = new Point(825, 15);
            btnSaveToFile.Name = "btnSaveToFile";
            btnSaveToFile.Size = new Size(189, 45);
            btnSaveToFile.TabIndex = 4;
            btnSaveToFile.Text = "Lưu thành File";
            btnSaveToFile.UseVisualStyleBackColor = true;
            btnSaveToFile.Click += btnSaveToFile_Click;
            // 
            // btnLuuBangCong
            // 
            btnLuuBangCong.Location = new Point(683, 15);
            btnLuuBangCong.Margin = new Padding(3, 4, 3, 4);
            btnLuuBangCong.Name = "btnLuuBangCong";
            btnLuuBangCong.Size = new Size(136, 45);
            btnLuuBangCong.TabIndex = 3;
            btnLuuBangCong.Text = "Lưu bảng công";
            btnLuuBangCong.UseVisualStyleBackColor = true;
            btnLuuBangCong.Click += btnLuuBangCong_Click_1;
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Location = new Point(343, 28);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(108, 20);
            lblTong.TabIndex = 2;
            lblTong.Text = "Số nhân viên: 0";
            // 
            // btnBoChon
            // 
            btnBoChon.Location = new Point(174, 15);
            btnBoChon.Margin = new Padding(3, 4, 3, 4);
            btnBoChon.Name = "btnBoChon";
            btnBoChon.Size = new Size(149, 45);
            btnBoChon.TabIndex = 1;
            btnBoChon.Text = "Bỏ chọn tất cả";
            btnBoChon.UseVisualStyleBackColor = true;
            // 
            // btnChonTatCa
            // 
            btnChonTatCa.Location = new Point(16, 15);
            btnChonTatCa.Margin = new Padding(3, 4, 3, 4);
            btnChonTatCa.Name = "btnChonTatCa";
            btnChonTatCa.Size = new Size(149, 45);
            btnChonTatCa.TabIndex = 0;
            btnChonTatCa.Text = "Chọn tất cả";
            btnChonTatCa.UseVisualStyleBackColor = true;
            // 
            // openFileDialogCSV
            // 
            openFileDialogCSV.Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin văn bản (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*";
            openFileDialogCSV.Title = "Nhập bảng chấm công từ tập tin CSV";
            // 
            // frmAttendance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1026, 570);
            Controls.Add(lvChamCong);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAttendance";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chấm công hằng ngày";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            cmsTrangThai.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Button btnNhapCSV;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.ListView lvChamCong;
        private System.Windows.Forms.ContextMenuStrip cmsTrangThai;
        private System.Windows.Forms.ToolStripMenuItem mnuDiLam;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiPhep;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiKhongPhep;
        private System.Windows.Forms.ToolStripMenuItem mnuDiTre;
        private System.Windows.Forms.ToolStripSeparator sepTrangThai;
        private System.Windows.Forms.ToolStripMenuItem mnuTangCa;
        private System.Windows.Forms.ToolStripMenuItem mnuGhiChu;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnChonTatCa;
        private System.Windows.Forms.Button btnBoChon;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnLuuBangCong;
        private System.Windows.Forms.OpenFileDialog openFileDialogCSV;
        private ColumnHeader colChon;
        private ColumnHeader colMa;
        private ColumnHeader colTen;
        private ColumnHeader colPhong;
        private ColumnHeader colTrangThai;
        private ColumnHeader colTangCa;
        private ColumnHeader colGhiChu;
        private Button btnNextDay;
        private Button btnPrevDay;
        private Button btnSaveToFile;
    }
}
