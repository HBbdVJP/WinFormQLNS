using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// QUẢN LÝ CHỨC VỤ (frmPosition) – màn hình con của frmMain.
    ///
    /// Giao diện đã có sẵn trong frmPosition.Designer.cs:
    ///   grpThongTin (txtMaChucVu, txtTenChucVu, nudHeSoLuong),
    ///   lvChucVu (danh sách chức vụ),
    ///   panelBottom (Thêm / Sửa / Xóa / Lưu / Hủy / Làm mới).
    /// </summary>
    public partial class frmPosition : Form
    {
        public frmPosition()
        {
            InitializeComponent();
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            // TODO: Nạp danh sách chức vụ lên lvChucVu
            //       (Mã chức vụ | Tên chức vụ | Hệ số lương | Số nhân viên).
            //       Đặt trạng thái ban đầu: ô nhập bị khóa, nút Sửa/Xóa tắt.
        }

        private void lvChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Đưa thông tin chức vụ đang chọn lên txtMaChucVu, txtTenChucVu, nudHeSoLuong.
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // TODO: Sang chế độ thêm mới: xóa trắng ô nhập, mở khóa, đặt con trỏ vào txtMaChucVu.
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // TODO: Mở khóa ô nhập để sửa chức vụ đang chọn.
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // TODO: Kiểm tra chức vụ có nhân viên không (nếu có thì không cho xóa),
            //       hỏi xác nhận rồi xóa và nạp lại danh sách.
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // TODO: Kiểm tra dữ liệu (không để trống mã / tên, hệ số lương > 0),
            //       rồi thêm mới hoặc cập nhật chức vụ và lưu lại.
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
