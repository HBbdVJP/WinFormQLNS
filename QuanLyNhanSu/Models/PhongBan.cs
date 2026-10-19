namespace QuanLyNhanSu.Models
{
    /// <summary>Phòng ban / bộ phận trong công ty.</summary>
    public class PhongBan
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string MoTa { get; set; }

        public override string ToString()
        {
            return TenPhong;
        }
    }
}
