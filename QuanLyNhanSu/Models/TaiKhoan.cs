namespace QuanLyNhanSu.Models
{
    /// <summary>Tài khoản dùng để đăng nhập hệ thống.</summary>
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public VaiTro VaiTro { get; set; } = VaiTro.NhanVien;

        /// <summary>Mã nhân viên gắn với tài khoản (có thể rỗng với tài khoản quản trị).</summary>
        public string MaNV { get; set; }
    }
}
