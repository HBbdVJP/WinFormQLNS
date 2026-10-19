using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// QUẢN LÝ PHÒNG BAN (frmDepartment) – màn hình con của frmMain.
    ///
    /// Giao diện đã có sẵn trong frmDepartment.Designer.cs:
    ///   grpThongTin (txtMaPhong, txtTenPhong, txtMoTa),
    ///   lvPhongBan (danh sách phòng ban),
    ///   panelBottom (Thêm / Sửa / Xóa / Lưu / Hủy / Làm mới).
    /// </summary>
    public partial class frmDepartment : Form
    {
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            // TODO: Nạp danh sách phòng ban lên lvPhongBan
            //       (Mã phòng | Tên phòng | Mô tả | Số nhân viên).
            //       Đặt trạng thái ban đầu: ô nhập bị khóa, nút Sửa/Xóa tắt.
        }

        private void lvPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Đưa thông tin phòng ban đang chọn lên txtMaPhong, txtTenPhong, txtMoTa.
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // TODO: Sang chế độ thêm mới: xóa trắng ô nhập, mở khóa, đặt con trỏ vào txtMaPhong.
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // TODO: Mở khóa ô nhập để sửa phòng ban đang chọn.
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // TODO: Kiểm tra phòng ban có nhân viên không (nếu có thì không cho xóa),
            //       hỏi xác nhận rồi xóa và nạp lại danh sách.
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // TODO: Kiểm tra dữ liệu (không để trống mã / tên, mã không trùng),
            //       rồi thêm mới hoặc cập nhật phòng ban và lưu lại.
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // TODO: Hủy chế độ thêm/sửa, khôi phục thông tin dòng đang chọn.
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // TODO: Xóa trắng các ô nhập và bỏ chọn dòng.
        }
    }
}
