namespace QuanLyNhanSu.Models
{
    /// <summary>Vai trò của tài khoản đăng nhập.</summary>
    public enum VaiTro
    {
        QuanTri,
        NhanVien
    }

    /// <summary>Trạng thái làm việc của nhân viên.</summary>
    public enum TrangThaiLamViec
    {
        DangLam,
        DaNghi
    }

    /// <summary>Kết quả chấm công trong một ngày.</summary>
    public enum LoaiChamCong
    {
        DiLam,
        DiTre,
        NghiPhep,
        NghiKhongPhep
    }
}
