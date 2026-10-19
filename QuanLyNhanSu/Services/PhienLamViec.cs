using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Services
{
    /// <summary>Thông tin phiên đăng nhập hiện tại.</summary>
    public static class PhienLamViec
    {
        /// <summary>Tài khoản đang đăng nhập.</summary>
        public static TaiKhoan NguoiDung { get; set; }

        /// <summary>Được bật khi người dùng chọn Đăng xuất (quay về màn hình đăng nhập).</summary>
        public static bool YeuCauDangXuat { get; set; }

        public static bool LaQuanTri
        {
            get { return NguoiDung != null && NguoiDung.VaiTro == VaiTro.QuanTri; }
        }

        public static string TenHienThi
        {
            get { return NguoiDung == null ? "" : NguoiDung.HoTen; }
        }

        public static string TenVaiTro
        {
            get
            {
                if (NguoiDung == null)
                {
                    return "";
                }
                return NguoiDung.VaiTro == VaiTro.QuanTri ? "Quản trị" : "Nhân viên";
            }
        }
    }
}
