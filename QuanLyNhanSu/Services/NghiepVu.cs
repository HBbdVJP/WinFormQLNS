using System;
using System.Collections.Generic;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Services
{
    /// <summary>Kết quả tính lương của một nhân viên trong một tháng.</summary>
    public class DongLuong
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public decimal LuongCoBan { get; set; }
        public int NgayLam { get; set; }
        public int SoLanDiTre { get; set; }
        public double GioTangCa { get; set; }
        public int PhepConLai { get; set; }
        public decimal TongLuong { get; set; }

        // Chi tiết dùng để in phiếu lương
        public decimal LuongTheoNgayCong { get; set; }
        public decimal TienTangCa { get; set; }
        public decimal TienTruDiTre { get; set; }
        public int SoNgayNghiPhep { get; set; }
        public int SoNgayNghiKhongPhep { get; set; }
    }

    /// <summary>Các thuật toán nghiệp vụ dùng chung.</summary>
    public static class NghiepVu
    {
        /// <summary>Tìm nhân viên theo mã.</summary>
        public static NhanVien TimNhanVien(string maNV)
        {
            return Store.Data.NhanViens.Find(n => string.Equals(n.MaNV, maNV, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Tên phòng ban theo mã.</summary>
        public static string TenPhong(string maPhong)
        {
            PhongBan p = Store.Data.PhongBans.Find(x => x.MaPhong == maPhong);
            return p == null ? maPhong : p.TenPhong;
        }

        /// <summary>Tên chức vụ theo mã.</summary>
        public static string TenChucVu(string maChucVu)
        {
            ChucVu c = Store.Data.ChucVus.Find(x => x.MaChucVu == maChucVu);
            return c == null ? maChucVu : c.TenChucVu;
        }

        public static string TenTrangThaiChamCong(LoaiChamCong tt)
        {
            switch (tt)
            {
                case LoaiChamCong.DiLam: return "Đi làm";
                case LoaiChamCong.DiTre: return "Đi trễ";
                case LoaiChamCong.NghiPhep: return "Nghỉ phép";
                default: return "Nghỉ không phép";
            }
        }

        public static string TenTrangThaiLamViec(TrangThaiLamViec tt)
        {
            return tt == TrangThaiLamViec.DangLam ? "Đang làm" : "Đã nghỉ";
        }

        /// <summary>Số ngày nghỉ phép đã dùng trong năm (để tính phép năm còn lại).</summary>
        public static int SoNgayPhepDaDung(string maNV, int nam)
        {
            int dem = 0;
            foreach (ChamCong cc in Store.Data.ChamCongs)
            {
                if (cc.MaNV == maNV && cc.Ngay.Year == nam && cc.TrangThai == LoaiChamCong.NghiPhep)
                {
                    dem++;
                }
            }

            return dem;
        }

        /// <summary>
        /// Tính lương cho toàn bộ nhân viên trong một tháng.
        /// Công thức sử dụng "Ngày công chuẩn", "Mức trừ đi trễ", "Hệ số tăng ca", "Số giờ làm chuẩn"
        /// đọc từ App.config.
        /// </summary>
        public static List<DongLuong> TinhLuongThang(int thang, int nam, string maPhong)
        {
            int ngayCongChuan = CauHinh.NgayCongChuan;
            decimal mucTruDiTre = CauHinh.MucTruDiTre;
            double heSoTangCa = CauHinh.HeSoTangCa;
            double gioLamChuan = CauHinh.SoGioLamChuan <= 0 ? 8 : CauHinh.SoGioLamChuan;

            List<DongLuong> ketQua = new List<DongLuong>();

            foreach (NhanVien nv in Store.Data.NhanViens)
            {
                if (!string.IsNullOrEmpty(maPhong) && nv.MaPhong != maPhong)
                {
                    continue;
                }

                int ngayLam = 0;
                int diTre = 0;
                int nghiPhep = 0;
                int nghiKhongPhep = 0;
                double gioTangCa = 0;

                foreach (ChamCong cc in Store.Data.ChamCongs)
                {
                    if (cc.MaNV != nv.MaNV || cc.Ngay.Month != thang || cc.Ngay.Year != nam)
                    {
                        continue;
                    }

                    switch (cc.TrangThai)
                    {
                        case LoaiChamCong.DiLam:
                            ngayLam++;
                            break;
                        case LoaiChamCong.DiTre:
                            ngayLam++;
                            diTre++;
                            break;
                        case LoaiChamCong.NghiPhep:
                            nghiPhep++;
                            break;
                        case LoaiChamCong.NghiKhongPhep:
                            nghiKhongPhep++;
                            break;
                    }

                    gioTangCa += cc.GioTangCa;
                }

                decimal donGiaNgay = ngayCongChuan <= 0 ? 0 : nv.LuongCoBan / ngayCongChuan;
                decimal luongTheoNgayCong = Math.Round(donGiaNgay * ngayLam, 0);
                decimal tienTangCa = Math.Round(donGiaNgay / (decimal)gioLamChuan * (decimal)heSoTangCa * (decimal)gioTangCa, 0);
                decimal tienTruDiTre = mucTruDiTre * diTre;
                decimal tong = luongTheoNgayCong + tienTangCa - tienTruDiTre;
                if (tong < 0)
                {
                    tong = 0;
                }

                DongLuong dl = new DongLuong
                {
                    MaNV = nv.MaNV,
                    HoTen = nv.HoTen,
                    LuongCoBan = nv.LuongCoBan,
                    NgayLam = ngayLam,
                    SoLanDiTre = diTre,
                    GioTangCa = gioTangCa,
                    PhepConLai = Math.Max(0, nv.PhepNam - SoNgayPhepDaDung(nv.MaNV, nam)),
                    TongLuong = tong,
                    LuongTheoNgayCong = luongTheoNgayCong,
                    TienTangCa = tienTangCa,
                    TienTruDiTre = tienTruDiTre,
                    SoNgayNghiPhep = nghiPhep,
                    SoNgayNghiKhongPhep = nghiKhongPhep
                };

                ketQua.Add(dl);
            }

            return ketQua;
        }

        /// <summary>Danh sách nhân viên có sinh nhật trong tháng.</summary>
        public static List<NhanVien> SinhNhatTrongThang(int thang)
        {
            List<NhanVien> ds = new List<NhanVien>();
            foreach (NhanVien nv in Store.Data.NhanViens)
            {
                if (nv.NgaySinh.Month == thang)
                {
                    ds.Add(nv);
                }
            }

            ds.Sort((a, b) => a.NgaySinh.Day.CompareTo(b.NgaySinh.Day));
            return ds;
        }
    }
}
