namespace QuanLyNhanSu.Forms
{
    partial class frmBirthdayDetail
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
            lblTitle = new Label();
            flpBirthdayEmployees = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(18, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Sinh nhật";
            // 
            // flpBirthdayEmployees
            // 
            flpBirthdayEmployees.AutoSize = true;
            flpBirthdayEmployees.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpBirthdayEmployees.FlowDirection = FlowDirection.TopDown;
            flpBirthdayEmployees.Location = new Point(14, 52);
            flpBirthdayEmployees.Margin = new Padding(0);
            flpBirthdayEmployees.Name = "flpBirthdayEmployees";
            flpBirthdayEmployees.Padding = new Padding(0, 0, 0, 8);
            flpBirthdayEmployees.Size = new Size(480, 0);
            flpBirthdayEmployees.WrapContents = false;
            // 
            // frmBirthdayDetail
            // 
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(510, 75);
            Controls.Add(flpBirthdayEmployees);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBirthdayDetail";
            Padding = new Padding(8);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết sinh nhật";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private FlowLayoutPanel flpBirthdayEmployees;
    }
}
