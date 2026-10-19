using System;
using System.Configuration;
using System.Globalization;

namespace QuanLyNhanSu.Services
{
    /// <summary>
    /// Đọc các tham số nghiệp vụ từ App.config.
    /// Nếu người dùng sửa App.config, chương trình sẽ dùng giá trị mới khi chạy lại.
    /// </summary>
    public static class CauHinh
    {
        private static string Lay(string key, string macDinh)
        {
            try
            {
                string v = ConfigurationManager.AppSettings[key];
                return string.IsNullOrWhiteSpace(v) ? macDinh : v.Trim();
            }
            catch (Exception)
            {
                return macDinh;
            }
        }

        private static int LayInt(string key, int macDinh)
        {
            int kq;
            return int.TryParse(Lay(key, macDinh.ToString(CultureInfo.InvariantCulture)),
                NumberStyles.Integer, CultureInfo.InvariantCulture, out kq) ? kq : macDinh;
        }

        private static double LayDouble(string key, double macDinh)
        {
            double kq;
            return double.TryParse(Lay(key, macDinh.ToString(CultureInfo.InvariantCulture)),
                NumberStyles.Float, CultureInfo.InvariantCulture, out kq) ? kq : macDinh;
        }

        private static decimal LayDecimal(string key, decimal macDinh)
        {
            decimal kq;
            return decimal.TryParse(Lay(key, macDinh.ToString(CultureInfo.InvariantCulture)),
                NumberStyles.Number, CultureInfo.InvariantCulture, out kq) ? kq : macDinh;
        }

        public static string TenDonVi
        {
            get { return Lay("TenDonVi", "CÔNG TY TNHH GIẢI PHÁP ABC"); }
        }

        /// <summary>Số ngày công chuẩn trong tháng.</summary>
        public static int NgayCongChuan
        {
            get { return LayInt("NgayCongChuan", 26); }
        }

        /// <summary>Số tiền trừ cho mỗi lần đi trễ (VNĐ).</summary>
        public static decimal MucTruDiTre
        {
            get { return LayDecimal("MucTruDiTre", 100000m); }
        }

        /// <summary>Hệ số nhân cho giờ tăng ca.</summary>
        public static double HeSoTangCa
        {
            get { return LayDouble("HeSoTangCa", 1.5); }
        }

        /// <summary>Số giờ làm việc chuẩn trong một ngày.</summary>
        public static double SoGioLamChuan
        {
            get { return LayDouble("SoGioLamChuan", 8); }
        }
    }
}
