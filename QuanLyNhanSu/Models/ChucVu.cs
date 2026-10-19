namespace QuanLyNhanSu.Models
{
    /// <summary>Chức vụ kèm hệ số lương.</summary>
    public class ChucVu
    {
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public double HeSoLuong { get; set; }

        public override string ToString()
        {
            return TenChucVu;
        }
    }
}
