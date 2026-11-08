using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

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
        public string? TenNhanVien { get; private set; }
        public string? GioiTinh { get; private set; }
        public DateTime? NgaySinh { get; private set; }
        public string? MaChucVu { get; private set; }
        public string? MaPhongBan { get; private set; }
        public string? MaTaiKhoan { get; private set; }
        public int? SoNgayNghiPhep { get; private set; }
        public decimal? LuongCoBan { get; private set; }
        public Image? AnhNhanVien { get; private set; } // dir ../Image/<tenfileanhNV.kieudulieu>
        public string? DuongDanAnh { get; private set;} //để thực hiện lưu data thành file txt
        public string? DienThoai { get; private set; }
        public string? Email { get; private set; }
        public string? DiaChi { get; private set; }

        //contructor simple
        public NhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, DateTime ngaySinh, string maChucVu, string maPhongBan, string maTaiKhoan, int soNgayNghiPhep, decimal luongCoBan, string duongdananh)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaChucVu = maChucVu;
            MaPhongBan = maPhongBan;
            MaTaiKhoan = maTaiKhoan;
            SoNgayNghiPhep = soNgayNghiPhep;
            LuongCoBan = luongCoBan;
            AnhNhanVien = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongdananh));
            DuongDanAnh = duongdananh;
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
            MaPhongBan = "NaN";
            MaTaiKhoan = "NaN";
            SoNgayNghiPhep = 0;
            LuongCoBan = 0.0m;
            AnhNhanVien = null;
            DuongDanAnh = "";
            DienThoai = "";
            Email = "";
            DiaChi = "";
        }
        //constructor full
        public NhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, DateTime ngaySinh, string maChucVu, string maPhongBan, string maTaiKhoan, int soNgayNghiPhep, decimal luongCoBan, string duongdananh, string dienThoai, string email, string diaChi)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaChucVu = maChucVu;
            MaPhongBan = maPhongBan;
            MaTaiKhoan = maTaiKhoan;
            SoNgayNghiPhep = soNgayNghiPhep;
            LuongCoBan = luongCoBan;
            AnhNhanVien = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongdananh)); DuongDanAnh = duongdananh;
            DienThoai = dienThoai;
            Email = email;
            DiaChi = diaChi;
        }
        public void UpdateNhanVien(string tenNhanVien, string gioiTinh, DateTime ngaySinh, string maChucVu, string maPhongBan, decimal luongCoBan, string dienThoai, string email, string diaChi)
        {
            TenNhanVien = tenNhanVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaChucVu = maChucVu;
            MaPhongBan = maPhongBan;
            LuongCoBan = luongCoBan;
            DienThoai = dienThoai;
            Email = email;
            DiaChi = diaChi;
        }
        public void UpdateTaiKhoanNV(string maTaiKhoan)
        {
            MaTaiKhoan = maTaiKhoan;
        }
        public void UpdateAnhNV(string duongdananh)
        {
            AnhNhanVien = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongdananh));
            DuongDanAnh = duongdananh;
        }
        public void RemoveAnhNV()
        {
            AnhNhanVien = null;
            DuongDanAnh = null;
        }
        public void initMaNhanVien(string manv)
        {
            MaNhanVien = manv;
        }

    }
    public class ChamCong
    {
        public string MaNhanVien { get; private set; }
        public DateTime NgayCong { get; private set; }
        public string TrangThai { get; private set; }
        public string GhiChu { get; private set; }
        public ChamCong(string maNhanVien, DateTime ngayCong, string trangThai, string ghiChu = "")
        {
            MaNhanVien = maNhanVien;
            NgayCong = ngayCong;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }

        public void CapNhatTrangThai(string trangThai)
        {
            TrangThai = trangThai;
        }

        public void CapNhatGhiChu(string ghiChu)
        {
            GhiChu = ghiChu;
        }
    }
    public class ChucVu
    {
        public string MaChucVu { get; private set; }
        public string TenChucVu { get; private set; }
        public decimal PhuCap { get; private set; }
        public bool QuyenCRUD { get; private set; }
        public ChucVu(string maChucVu, string tenChucVu, decimal phuCap, bool quyenHanHeThong)
        {
            MaChucVu = maChucVu;
            TenChucVu = tenChucVu;
            PhuCap = phuCap;
            QuyenCRUD = quyenHanHeThong;
        }
        public ChucVu()
        {
            MaChucVu = "NaN";
            TenChucVu = "NaN";
            PhuCap = 0;
            QuyenCRUD = false;
        }
        public ChucVu(string maChucVu, string tenChucVu, decimal phuCap)
        {
            MaChucVu = maChucVu;
            TenChucVu = tenChucVu;
            PhuCap = phuCap;
            QuyenCRUD = false;
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
    public class SessionLogin
    {
        public string dummyloginkey = "wjbicber";
        public string MaTaiKhoan { get; private set; }
        public string TenNhanVien { get; private set; }
        public string TenChucVu {  get; private set; }
        public bool nvDangNhapQuyenHan { get; private set; }
        public SessionLogin(string maTaiKhoan) //trong login form truyền mã
        {
            MaTaiKhoan = maTaiKhoan;
        }
        public SessionLogin()
        {

        }
        public void RBACAuth(List<NhanVien> dsnv, List<ChucVu> dscv) //chạy đầu load main
        {
            foreach(NhanVien nv in dsnv)
            {
                if(nv.MaTaiKhoan == MaTaiKhoan)
                {
                    TenNhanVien = nv.TenNhanVien;
                    foreach(ChucVu cv in dscv)
                    {
                        if (cv.MaChucVu == nv.MaChucVu)
                        {
                            nvDangNhapQuyenHan = cv.QuyenCRUD;
                            TenChucVu = cv.TenChucVu;
                        }
                    }
                }
            }
        }
    }
}