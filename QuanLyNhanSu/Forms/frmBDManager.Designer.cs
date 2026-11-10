namespace QuanLyNhanSu.Forms
{
    partial class frmBDManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelSelectors = new Panel();
            lblMonth = new Label();
            cboMonth = new ComboBox();
            lblYear = new Label();
            cboYear = new ComboBox();
            lblThuHai = new Label();
            lblThuBa = new Label();
            lblThuTu = new Label();
            lblThuNam = new Label();
            lblThuSau = new Label();
            lblThuBay = new Label();
            lblChuNhat = new Label();
            tlpCalendar = new TableLayoutPanel();
            panelSelectors.SuspendLayout();
            SuspendLayout();
            // 
            // panelSelectors
            // 
            panelSelectors.Controls.Add(lblMonth);
            panelSelectors.Controls.Add(cboMonth);
            panelSelectors.Controls.Add(lblYear);
            panelSelectors.Controls.Add(cboYear);
            panelSelectors.Dock = DockStyle.Top;
            panelSelectors.Height = 54;
            panelSelectors.Name = "panelSelectors";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(18, 17);
            lblMonth.Text = "Tháng:";
            // 
            // cboMonth
            // 
            cboMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(70, 12);
            cboMonth.Size = new Size(125, 28);
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(230, 17);
            lblYear.Text = "Năm:";
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(275, 12);
            cboYear.Size = new Size(110, 28);
            // 
            // weekday labels
            // 
            Label[] weekdayLabels = { lblThuHai, lblThuBa, lblThuTu, lblThuNam, lblThuSau, lblThuBay, lblChuNhat };
            string[] weekdayNames = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
            for (int index = 0; index < weekdayLabels.Length; index++)
            {
                weekdayLabels[index].Dock = DockStyle.Fill;
                weekdayLabels[index].Text = weekdayNames[index];
                weekdayLabels[index].TextAlign = ContentAlignment.MiddleCenter;
                weekdayLabels[index].Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                weekdayLabels[index].BackColor = Color.FromArgb(235, 239, 244);
            }
            // 
            // tlpCalendar
            // 
            tlpCalendar.ColumnCount = 7;
            tlpCalendar.RowCount = 6;
            tlpCalendar.Dock = DockStyle.Fill;
            tlpCalendar.Padding = new Padding(8, 4, 8, 8);
            tlpCalendar.Name = "tlpCalendar";
            for (int column = 0; column < 7; column++)
            {
                tlpCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            }
            for (int row = 0; row < 6; row++)
            {
                tlpCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6667F));
            }
            tlpCalendar.Controls.Add(lblThuHai, 0, 0);
            tlpCalendar.Controls.Add(lblThuBa, 1, 0);
            tlpCalendar.Controls.Add(lblThuTu, 2, 0);
            tlpCalendar.Controls.Add(lblThuNam, 3, 0);
            tlpCalendar.Controls.Add(lblThuSau, 4, 0);
            tlpCalendar.Controls.Add(lblThuBay, 5, 0);
            tlpCalendar.Controls.Add(lblChuNhat, 6, 0);
            tlpCalendar.RowStyles.Insert(0, new RowStyle(SizeType.Absolute, 32F));
            tlpCalendar.RowCount = 7;
            // 
            // frmBDManager
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 700);
            Controls.Add(tlpCalendar);
            Controls.Add(panelSelectors);
            Name = "frmBDManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh nhật nhân viên";
            panelSelectors.ResumeLayout(false);
            panelSelectors.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelSelectors;
        private Label lblMonth;
        private Label lblYear;
        private ComboBox cboMonth;
        private ComboBox cboYear;
        private Label lblThuHai;
        private Label lblThuBa;
        private Label lblThuTu;
        private Label lblThuNam;
        private Label lblThuSau;
        private Label lblThuBay;
        private Label lblChuNhat;
        private TableLayoutPanel tlpCalendar;
    }
}