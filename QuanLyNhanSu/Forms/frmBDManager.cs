using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;

namespace QuanLyNhanSu.Forms
{
    public partial class frmBDManager : Form
    {
        private readonly List<NhanVien> danhSachNhanVien;
        private readonly Color[] birthdayColors =
        {
            Color.FromArgb(220, 233, 213), Color.FromArgb(212, 233, 225),
            Color.FromArgb(216, 229, 242), Color.FromArgb(229, 221, 242),
            Color.FromArgb(242, 221, 225), Color.FromArgb(243, 234, 203)
        };

        public frmBDManager(List<NhanVien> danhSachNhanVien)
        {
            InitializeComponent();
            this.danhSachNhanVien = danhSachNhanVien;
            LoadComboBoxMonthYear();
            cboMonth.SelectedItem = DateTime.Today.Month;
            cboYear.SelectedItem = DateTime.Today.Year;
            cboMonth.SelectedIndexChanged += (_, _) => RenderCalendar();
            cboYear.SelectedIndexChanged += (_, _) => RenderCalendar();
            RenderCalendar();
        }

        private void LoadComboBoxMonthYear()
        {
            cboMonth.Items.Clear();
            for (int month = 1; month <= 12; month++) cboMonth.Items.Add(month);
            cboMonth.Format += (_, e) =>
            {
                if (e.ListItem is int month) e.Value = $"Tháng {month}";
            };

            cboYear.Items.Clear();
            int currentYear = DateTime.Today.Year;
            for (int year = currentYear - 5; year <= currentYear + 5; year++)
                cboYear.Items.Add(year);
        }

        private void RenderCalendar()
        {
            if (cboMonth.SelectedItem is not int month || cboYear.SelectedItem is not int year)
                return;

            tlpCalendar.SuspendLayout();
            foreach (Control control in tlpCalendar.Controls.Cast<Control>().Where(x => x is Button).ToList())
            {
                tlpCalendar.Controls.Remove(control);
                control.Dispose();
            }

            DateTime firstDay = new DateTime(year, month, 1);
            int firstColumn = ((int)firstDay.DayOfWeek + 6) % 7;
            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int cell = 0; cell < 42; cell++)
            {
                int day = cell - firstColumn + 1;
                DateTime? date = day >= 1 && day <= daysInMonth
                    ? new DateTime(year, month, day)
                    : null;
                tlpCalendar.Controls.Add(CreateDayButton(date), cell % 7, (cell / 7) + 1);
            }
            tlpCalendar.ResumeLayout(true);
        }

        private Button CreateDayButton(DateTime? date)
        {
            Button button = new Button
            {
                Dock = DockStyle.Fill, Margin = new Padding(2), FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false, Font = new Font("Segoe UI", 10F), Tag = date
            };
            button.FlatAppearance.BorderColor = Color.Gainsboro;
            if (!date.HasValue)
            {
                button.Enabled = false;
                button.BackColor = Color.White;
                return button;
            }

            DateTime birthdayDate = date.Value;
            List<NhanVien> employees = GetBirthdayEmployees(birthdayDate);
            button.Text = birthdayDate.Day.ToString();
            button.BackColor = employees.Count > 0
                ? birthdayColors[(birthdayDate.Day - 1) % birthdayColors.Length]
                : Color.White;
            button.ForeColor = employees.Count > 0
                ? GetContrastingTextColor(button.BackColor) : Color.Black;
            if (employees.Count > 0)
            {
                button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                button.Click += (_, _) => ShowBirthdayDetail(birthdayDate);
            }
            if (birthdayDate.Date == DateTime.Today)
            {
                button.FlatAppearance.BorderColor = Color.RoyalBlue;
                button.FlatAppearance.BorderSize = 2;
            }
            return button;
        }

        private List<NhanVien> GetBirthdayEmployees(DateTime date)
        {
            return danhSachNhanVien.Where(employee => employee.NgaySinh.HasValue &&
                employee.NgaySinh.Value.Day == date.Day &&
                employee.NgaySinh.Value.Month == date.Month).ToList();
        }

        private void ShowBirthdayDetail(DateTime date)
        {
            List<NhanVien> employees = GetBirthdayEmployees(date);
            if (employees.Count == 0) return;
            using frmBirthdayDetail detail = new frmBirthdayDetail(date, employees);
            detail.ShowDialog(this);
        }

        private static Color GetContrastingTextColor(Color background)
        {
            double luminance = (0.299 * background.R) + (0.587 * background.G) + (0.114 * background.B);
            return luminance >= 150 ? Color.Black : Color.White;
        }
    }
}