using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;

namespace QuanLyNhanSu.Forms
{
    public partial class frmBirthdayDetail : Form
    {
        public frmBirthdayDetail(DateTime date, IReadOnlyList<NhanVien> employees)
        {
            InitializeComponent();
            Text = $"Sinh nhật ngày {date:dd/MM}";
            LoadBirthdayEmployees(date, employees);
            KeyDown += frmBirthdayDetail_KeyDown;
        }

        private void LoadBirthdayEmployees(
            DateTime date,
            IReadOnlyList<NhanVien> employees)
        {
            lblTitle.Text = $"Sinh nhật ngày {date:dd/MM}";
            flpBirthdayEmployees.Controls.Clear();

            foreach (NhanVien employee in employees)
            {
                GroupBox group = new GroupBox
                {
                    Name = "grpEmployeeBirthday",
                    Text = employee.TenNhanVien ?? "Nhân viên",
                    Width = 455,
                    Height = 72,
                    Padding = new Padding(12, 8, 8, 8),
                    Margin = new Padding(4),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                Label birthdayLabel = new Label
                {
                    Name = "lblSinhNhat",
                    AutoSize = true,
                    Location = new Point(12, 35),
                    Text = $"Ngày sinh: {employee.NgaySinh:dd/MM/yyyy}",
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular)
                };
                group.Controls.Add(birthdayLabel);
                flpBirthdayEmployees.Controls.Add(group);
            }
        }

        private void frmBirthdayDetail_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter or Keys.Space or Keys.Escape)
            {
                Close();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
