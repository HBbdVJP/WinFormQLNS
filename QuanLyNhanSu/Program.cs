using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;
using QuanLyNhanSu.Forms;

namespace QuanLyNhanSu
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            // Đặt định dạng Việt Nam (ngày dd/MM/yyyy, dấu phân cách hàng nghìn...)
            CultureInfo vi = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = vi;
            Thread.CurrentThread.CurrentUICulture = vi;

            Application.Run(new frmLogin());
        }
    }
}
