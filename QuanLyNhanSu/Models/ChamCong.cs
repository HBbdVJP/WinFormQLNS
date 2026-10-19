using System;

namespace QuanLyNhanSu.Models
{
    /// <summary>Một dòng chấm công của nhân viên trong một ngày.</summary>
    public class ChamCong
    {
        public string MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public LoaiChamCong TrangThai { get; set; }

        /// <summary>Số giờ tăng ca trong ngày.</summary>
        public double GioTangCa { get; set; }

        public string GhiChu { get; set; }
    }
}
