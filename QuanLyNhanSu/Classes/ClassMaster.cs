using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Classes
{
    public class PhongBan
    {
        public string MaPhongBan { get; private set; }
        public string TenPhongBan { get; private set; }
        public PhongBan(string maPhongBan, string tenPhongBan)
        {
            MaPhongBan = maPhongBan;
            TenPhongBan = tenPhongBan;
        }
    }
    public class NhanVien
    {
        public string MaNhanVien { get; private set; }
        public string TenNhanVien { get; private set; }
        public string GioiTinh { get; private set; }
        public DateTime NgaySinh { get; private set; }
        public string MaChucVu { get; private set; }
        public string MaTaiKhoan { get; private set; }
        public int SoNgayNghiPhep { get; private set; }
        public decimal LuongCoBan { get; private set; }
        public Image AnhNhanVien { get; private set; } // dir ../Image/<tenfileanhNV.kieudulieu>
        public string DienThoai { get; private set; }
        public string Email { get; private set; }
        public string DiaChi { get; private set; }

        //contructor simple
        public NhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, DateTime ngaySinh, string maChucVu, string maTaiKhoan, int soNgayNghiPhep, decimal luongCoBan, Image anhNhanVien)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaChucVu = maChucVu;
            MaTaiKhoan = maTaiKhoan;
            SoNgayNghiPhep = soNgayNghiPhep;
            LuongCoBan = luongCoBan;
            AnhNhanVien = anhNhanVien;
            DienThoai = "";
            Email = "";
            DiaChi = "";
        }
        //constructor templateholder
        public NhanVien()
        {
            MaNhanVien = "NaN";
            TenNhanVien = "Placeholder";
            GioiTinh = "NaN";
            NgaySinh = DateTime.MinValue;
            MaChucVu = "NaN";
            MaTaiKhoan = "NaN";
            SoNgayNghiPhep = 0;
            LuongCoBan = 0.0m;
            AnhNhanVien = null;
            DienThoai = "";
            Email = "";
            DiaChi = "";
        }
        //constructor full
        public NhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, DateTime ngaySinh, string maChucVu, string maTaiKhoan, int soNgayNghiPhep, decimal luongCoBan, Image anhNhanVien, string dienThoai, string email, string diaChi)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaChucVu = maChucVu;
            MaTaiKhoan = maTaiKhoan;
            SoNgayNghiPhep = soNgayNghiPhep;
            LuongCoBan = luongCoBan;
            AnhNhanVien = anhNhanVien;
            DienThoai = dienThoai;
            Email = email;
            DiaChi = diaChi;
        }

    }
    public class ChamCong
    {
        public string MaNhanVien { get; private set; }
        public DateTime NgayCong { get; private set; }
        public string TrangThai { get; private set; }
        public ChamCong(string maNhanVien, DateTime ngayCong, string trangThai)
        {
            MaNhanVien = maNhanVien;
            NgayCong = ngayCong;
            TrangThai = trangThai;
        }
    }
    public class ChucVu
    {
        public string MaChucVu { get; private set; }
        public string TenChucVu { get; private set; }
        public decimal PhuCap { get; private set; }
        public ChucVu(string maChucVu, string tenChucVu, decimal phuCap)
        {
            MaChucVu = maChucVu;
            TenChucVu = tenChucVu;
            PhuCap = phuCap;
        }
    }
    public class User
    {
        public string MaTaiKhoan { get; private set; }
        public string TenDangNhap { get; private set; }
        public string MatKhau { get; private set; }
        public User(string maTaiKhoan, string tenDangNhap, string matKhau)
        {
            MaTaiKhoan = maTaiKhoan;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }
    }
    public class PhieuLuong
    {
        public string MaNhanVien { get; private set; }
        public string TenNhanVien { get; private set; }
        public decimal LuongCoBan { get; private set; }
        public decimal PhuCap { get; private set; }
        public decimal PhatDiTre { get; private set; }
        public decimal ThucLanh { get; private set; }
        public PhieuLuong(string maNhanVien, string tenNhanVien, decimal luongCoBan, decimal phuCap, decimal phatDiTre, decimal thucLanh)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            LuongCoBan = luongCoBan;
            PhuCap = phuCap;
            PhatDiTre = phatDiTre;
            ThucLanh = thucLanh;
        }
    }
}