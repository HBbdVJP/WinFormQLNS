using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Data
{
    /// <summary>Toàn bộ dữ liệu của chương trình.</summary>
    public class DuLieu
    {
        public List<PhongBan> PhongBans { get; set; } = new List<PhongBan>();
        public List<ChucVu> ChucVus { get; set; } = new List<ChucVu>();
        public List<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
        public List<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();
        public List<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
    }

    /// <summary>Kho dữ liệu dùng chung: nạp / lưu tập tin JSON trong thư mục AppData.</summary>
    public static class Store
    {
        private static readonly JsonSerializerOptions JsonOpts = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new JsonStringEnumConverter() }
        };

        public static DuLieu Data { get; private set; } = new DuLieu();

        public static string Folder { get; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuanLyNhanSu");

        public static string DataFile { get; } = Path.Combine(Folder, "data.json");

        /// <summary>Nạp dữ liệu từ đĩa, nếu chưa có thì tạo dữ liệu mẫu.</summary>
        public static void Load()
        {
            try
            {
                if (File.Exists(DataFile))
                {
                    string json = File.ReadAllText(DataFile, Encoding.UTF8);
                    DuLieu d = JsonSerializer.Deserialize<DuLieu>(json, JsonOpts);
                    if (d != null)
                    {
                        Data = d;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // Nếu tập tin hỏng thì tạo lại dữ liệu mẫu bên dưới
            }

            Data = TaoDuLieuMau();
            Save();
        }

        /// <summary>Ghi dữ liệu xuống đĩa.</summary>
        public static void Save()
        {
            Directory.CreateDirectory(Folder);
            string json = JsonSerializer.Serialize(Data, JsonOpts);
            File.WriteAllText(DataFile, json, new UTF8Encoding(false));
        }

        /// <summary>Nạp lại dữ liệu từ đĩa (dùng cho chức năng Phục hồi).</summary>
        public static void Reload()
        {
            Data = new DuLieu();
            Load();
        }

        // ------------------------------------------------------------------
        // Dữ liệu mẫu
        // ------------------------------------------------------------------
        private static DuLieu TaoDuLieuMau()
        {
            DuLieu d = new DuLieu();

            d.PhongBans.Add(new PhongBan { MaPhong = "PB01", TenPhong = "Hành chính - Nhân sự", MoTa = "Quản lý hồ sơ, tuyển dụng" });
            d.PhongBans.Add(new PhongBan { MaPhong = "PB02", TenPhong = "Kỹ thuật", MoTa = "Phát triển sản phẩm" });
            d.PhongBans.Add(new PhongBan { MaPhong = "PB03", TenPhong = "Kinh doanh", MoTa = "Bán hàng và chăm sóc khách hàng" });
            d.PhongBans.Add(new PhongBan { MaPhong = "PB04", TenPhong = "Kế toán", MoTa = "Tài chính - kế toán" });

            d.ChucVus.Add(new ChucVu { MaChucVu = "CV01", TenChucVu = "Giám đốc", HeSoLuong = 5.0 });
            d.ChucVus.Add(new ChucVu { MaChucVu = "CV02", TenChucVu = "Trưởng phòng", HeSoLuong = 3.5 });
            d.ChucVus.Add(new ChucVu { MaChucVu = "CV03", TenChucVu = "Nhân viên", HeSoLuong = 2.0 });
            d.ChucVus.Add(new ChucVu { MaChucVu = "CV04", TenChucVu = "Kế toán viên", HeSoLuong = 2.2 });
            d.ChucVus.Add(new ChucVu { MaChucVu = "CV05", TenChucVu = "Thực tập sinh", HeSoLuong = 1.2 });

            int nam = DateTime.Today.Year;
            int thangHienTai = DateTime.Today.Month;

            d.NhanViens.Add(TaoNhanVien("NV01", "Nguyễn Văn An", "Nam", new DateTime(1985, 3, 12), "Hà Nội", "0901111111", "an.nv@abc.vn", "PB01", "CV01", 30000000m, 15));
            d.NhanViens.Add(TaoNhanVien("NV02", "Trần Thị Bình", "Nữ", new DateTime(1990, thangHienTai, 5), "Hải Phòng", "0902222222", "binh.tt@abc.vn", "PB01", "CV02", 18000000m, 14));
            d.NhanViens.Add(TaoNhanVien("NV03", "Lê Minh Cường", "Nam", new DateTime(1995, 7, 21), "Đà Nẵng", "0903333333", "cuong.lm@abc.vn", "PB02", "CV03", 15000000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV04", "Phạm Thu Dung", "Nữ", new DateTime(1997, thangHienTai, 18), "Hà Nội", "0904444444", "dung.pt@abc.vn", "PB02", "CV03", 14000000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV05", "Hoàng Văn Em", "Nam", new DateTime(1993, 11, 2), "Nam Định", "0905555555", "em.hv@abc.vn", "PB02", "CV02", 19000000m, 13));
            d.NhanViens.Add(TaoNhanVien("NV06", "Vũ Thị Giang", "Nữ", new DateTime(1998, 1, 30), "Thái Bình", "0906666666", "giang.vt@abc.vn", "PB03", "CV03", 13000000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV07", "Đỗ Minh Hải", "Nam", new DateTime(1992, 5, 9), "Nghệ An", "0907777777", "hai.dm@abc.vn", "PB03", "CV02", 20000000m, 13));
            d.NhanViens.Add(TaoNhanVien("NV08", "Bùi Thị Hạnh", "Nữ", new DateTime(1996, thangHienTai, 27), "Hà Nam", "0908888888", "hanh.bt@abc.vn", "PB03", "CV03", 12500000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV09", "Ngô Quốc Khánh", "Nam", new DateTime(1991, 9, 14), "TP. HCM", "0909999999", "khanh.nq@abc.vn", "PB04", "CV04", 16000000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV10", "Lý Thị Lan", "Nữ", new DateTime(1999, 2, 8), "Cần Thơ", "0910111111", "lan.lt@abc.vn", "PB04", "CV04", 14500000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV11", "Trịnh Văn Mạnh", "Nam", new DateTime(2001, thangHienTai, 11), "Hà Nội", "0911222222", "manh.tv@abc.vn", "PB02", "CV05", 6000000m, 12));
            d.NhanViens.Add(TaoNhanVien("NV12", "Trương Thị Ngọc", "Nữ", new DateTime(1994, 6, 25), "Quảng Ninh", "0912333333", "ngoc.tt@abc.vn", "PB01", "CV03", 13500000m, 12));

            d.TaiKhoans.Add(new TaiKhoan { TenDangNhap = "admin", MatKhau = "admin123", HoTen = "Quản trị hệ thống", VaiTro = VaiTro.QuanTri, MaNV = "NV01" });
            d.TaiKhoans.Add(new TaiKhoan { TenDangNhap = "nv01", MatKhau = "123456", HoTen = "Lê Minh Cường", VaiTro = VaiTro.NhanVien, MaNV = "NV03" });
            d.TaiKhoans.Add(new TaiKhoan { TenDangNhap = "nv02", MatKhau = "123456", HoTen = "Vũ Thị Giang", VaiTro = VaiTro.NhanVien, MaNV = "NV06" });

            // Sinh dữ liệu chấm công cho các ngày làm việc từ đầu tháng đến hôm nay
            int i = 0;
            foreach (NhanVien nv in d.NhanViens)
            {
                i++;
                for (int ngay = 1; ngay <= DateTime.Today.Day; ngay++)
                {
                    DateTime dNgay = new DateTime(nam, thangHienTai, ngay);
                    if (dNgay.DayOfWeek == DayOfWeek.Saturday || dNgay.DayOfWeek == DayOfWeek.Sunday)
                    {
                        continue;
                    }

                    ChamCong cc = new ChamCong { MaNV = nv.MaNV, Ngay = dNgay, TrangThai = LoaiChamCong.DiLam };
                    int seed = (i * 17 + ngay * 7) % 23;
                    if (seed == 0)
                    {
                        cc.TrangThai = LoaiChamCong.DiTre;
                    }
                    else if (seed == 5)
                    {
                        cc.TrangThai = LoaiChamCong.NghiPhep;
                    }
                    else if (seed == 11)
                    {
                        cc.TrangThai = LoaiChamCong.NghiKhongPhep;
                    }

                    if (cc.TrangThai == LoaiChamCong.DiLam || cc.TrangThai == LoaiChamCong.DiTre)
                    {
                        if ((i + ngay) % 6 == 0)
                        {
                            cc.GioTangCa = 2;
                        }
                        else if ((i + ngay) % 9 == 0)
                        {
                            cc.GioTangCa = 1.5;
                        }
                    }

                    d.ChamCongs.Add(cc);
                }
            }

            return d;
        }

        private static NhanVien TaoNhanVien(string ma, string hoTen, string gioiTinh, DateTime ngaySinh,
            string diaChi, string dienThoai, string email, string maPhong, string maChucVu,
            decimal luong, int phepNam)
        {
            return new NhanVien
            {
                MaNV = ma,
                HoTen = hoTen,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                DiaChi = diaChi,
                DienThoai = dienThoai,
                Email = email,
                MaPhong = maPhong,
                MaChucVu = maChucVu,
                NgayVaoLam = ngaySinh.AddYears(22),
                LuongCoBan = luong,
                PhepNam = phepNam,
                TrangThai = TrangThaiLamViec.DangLam
            };
        }
    }
}
