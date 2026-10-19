using System;

namespace QuanLyNhanSu.Models
{
    /// <summary>Hồ sơ nhân viên.</summary>
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string MaPhong { get; set; }
        public string MaChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public decimal LuongCoBan { get; set; }

        /// <summary>Số ngày phép được hưởng trong năm.</summary>
        public int PhepNam { get; set; } = 12;

        public TrangThaiLamViec TrangThai { get; set; } = TrangThaiLamViec.DangLam;

        /// <summary>Ảnh nhân viên lưu dưới dạng chuỗi Base64 (để sao lưu dữ liệu là đủ).</summary>
        public string AnhBase64 { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", MaNV, HoTen);
        }
    }
}
