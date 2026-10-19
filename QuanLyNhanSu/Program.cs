using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using QuanLyNhanSu.Forms;

namespace QuanLyNhanSu
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi đầu của chương trình.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            // Đặt định dạng Việt Nam (ngày dd/MM/yyyy, dấu phân cách hàng nghìn...)
            CultureInfo vi = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = vi;
            Thread.CurrentThread.CurrentUICulture = vi;

            // ==================================================================
            //  CHẠY NHANH MỘT MÀN HÌNH ĐỂ LẬP TRÌNH / KIỂM TRA GIAO DIỆN
            //  - Trong Visual Studio: bấm chuột phải tên project QuanLyNhanSu >
            //    Properties > Debug > General > Open debug launch profiles UI >
            //    Command line arguments: gõ tên form, ví dụ:  frmEmployee
            //  - Hoặc ở dòng lệnh:  dotnet run -- frmEmployee
            //  Không truyền gì thì chương trình mở màn hình chính frmMain.
            // ==================================================================
            string chonForm = (args.Length > 0 ? args[0] : string.Empty).Trim().ToLowerInvariant();
            switch (chonForm)
            {
                case "frmlogin": Application.Run(new frmLogin()); return;
                case "frmmain": Application.Run(new frmMain()); return;
                case "frmdashboard": Application.Run(new frmDashboard()); return;
                case "frmemployee": Application.Run(new frmEmployee()); return;
                case "frmattendance": Application.Run(new frmAttendance()); return;
                case "frmsalary": Application.Run(new frmSalary()); return;
                case "frmdepartment": Application.Run(new frmDepartment()); return;
                case "frmposition": Application.Run(new frmPosition()); return;
            }

            // Mặc định: mở màn hình chính.
            // Khi thành viên phụ trách ĐĂNG NHẬP làm xong frmLogin, thay 2 dòng dưới bằng:
            //     using (frmLogin f = new frmLogin())
            //     {
            //         if (f.ShowDialog() != DialogResult.OK) return;
            //     }
            //     Application.Run(new frmMain());
            Application.Run(new frmMain());
        }
    }
}
