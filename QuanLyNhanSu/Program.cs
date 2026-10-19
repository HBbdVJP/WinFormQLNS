using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Hiển thị ngày tháng theo kiểu Việt Nam
            CultureInfo vi = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = vi;
            Thread.CurrentThread.CurrentUICulture = vi;
            Application.CurrentCulture = vi;

            // Nạp dữ liệu và tùy chỉnh giao diện đã lưu trong Registry
            Store.Load();
            TuyChinh.Load();

            // Vòng lặp: Đăng nhập -> Màn hình chính -> (Đăng xuất) -> Đăng nhập lại
            while (true)
            {
                using (frmLogin login = new frmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                PhienLamViec.YeuCauDangXuat = false;
                using (frmMain main = new frmMain())
                {
                    Application.Run(main);
                }

                if (!PhienLamViec.YeuCauDangXuat)
                {
                    break;
                }
            }
        }
    }
}
