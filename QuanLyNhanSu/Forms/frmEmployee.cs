using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// YÊU CẦU 1 – QUẢN LÝ HỒ SƠ NHÂN VIÊN (frmEmployee).
    ///
    /// Giao diện đã được thiết kế sẵn trong frmEmployee.Designer.cs:
    ///   - Trái : cây sơ đồ tổ chức tvToChuc + bộ lọc (cboLocPhong) + tìm kiếm (txtTimKiem, btnTimKiem)
    ///   - Phải : các ô nhập thông tin (txtMaNV, txtHoTen, cboGioiTinh, dtpNgaySinh,
    ///            txtDienThoai, txtEmail, txtDiaChi, cboPhongBanInfo, cboChucVu,
    ///            txtLuong, dtpNgayVaoLam, cboTrangThai, nudPhepNam), ảnh picAnh,
    ///            các nút Thêm/Sửa/Xóa/Lưu/Hủy/Làm mới và ListView lvNhanVien.
    /// File này CHỈ chứa phần LẬP TRÌNH.
    ///
    /// CÁC VIỆC CẦN LÀM:
    ///   1. Nạp dữ liệu lên cây tổ chức, ComboBox và ListView.
    ///   2. Thêm / Sửa / Xóa / Lưu / Hủy / Làm mới hồ sơ nhân viên (lưu xuống dữ liệu).
    ///   3. Kiểm tra dữ liệu: ô nào sai thì tô viền đỏ + hiện tooltip (errorProvider1)
    ///      + đưa con trỏ vào đúng ô đó.
    ///   4. Đổi ảnh / xóa ảnh đại diện.
    ///   5. Tìm kiếm theo từ khóa và lọc theo phòng ban.
    /// </summary>
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  NẠP DỮ LIỆU
        // =====================================================================

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            // TODO: - Nạp danh sách phòng ban vào cboLocPhong và cboPhongBanInfo.
            //       - Nạp danh sách chức vụ vào cboChucVu; nạp Giới tính và Trạng thái.
            //       - Dựng cây sơ đồ tổ chức cho tvToChuc (Tên đơn vị > Phòng ban > Chức vụ).
            //       - Đặt trạng thái ban đầu: các ô nhập bị khóa, nút Sửa/Xóa tắt.
            //       - Gọi hàm nạp danh sách nhân viên lên lvNhanVien.
        }

        private void cboLocPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Nạp lại lvNhanVien chỉ với nhân viên thuộc phòng ban đang chọn.
        }

        private void tvToChuc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // TODO: Khi chọn một nút trên cây thì lọc danh sách theo phòng ban / chức vụ tương ứng.
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // TODO: Lọc lvNhanVien theo từ khóa trong txtTimKiem
            //       (tìm trong mã nhân viên, họ tên, điện thoại, email) + phòng ban ở cboLocPhong.
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            // TODO: Nếu người dùng nhấn Enter thì gọi lại phần tìm kiếm như btnTimKiem_Click.
        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Đưa thông tin nhân viên đang chọn lên các ô nhập và hiện ảnh lên picAnh.
        }

        // =====================================================================
        //  THÊM / SỬA / XÓA / LƯU / HỦY / LÀM MỚI
        // =====================================================================

        private void btnThem_Click(object sender, EventArgs e)
        {
            // TODO: Chuyển sang chế độ THÊM MỚI:
            //       xóa trắng các ô nhập, mở khóa cho nhập, tắt nút Sửa/Xóa,
            //       bỏ chọn dòng trong lvNhanVien và đặt con trỏ vào txtMaNV.
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // TODO: Chuyển sang chế độ SỬA cho dòng đang chọn (mở khóa các ô nhập).
            //       Lưu lại mã nhân viên gốc để khi Lưu biết đây là cập nhật, không phải thêm mới.
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // TODO: Hỏi xác nhận (MessageBox) rồi xóa nhân viên đang chọn, lưu dữ liệu
            //       và nạp lại danh sách.
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // TODO: - Kiểm tra dữ liệu: bắt buộc nhập Mã nhân viên, Họ tên; ngày sinh < ngày hiện tại;
            //         lương phải là số... Nếu sai: tô đỏ ô đó + errorProvider1.SetError(...) + Focus().
            //       - Nếu hợp lệ: thêm mới hoặc cập nhật nhân viên, lưu xuống dữ liệu,
            //         nạp lại lvNhanVien, thoát chế độ thêm/sửa và báo thành công.
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // TODO: Hủy chế độ thêm/sửa và khôi phục lại thông tin của dòng đang chọn.
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // TODO: Xóa trắng toàn bộ ô nhập, xóa ô tìm kiếm, bỏ chọn dòng, trở về trạng thái ban đầu.
        }

        // =====================================================================
        //  ẢNH ĐẠI DIỆN
        // =====================================================================

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            // TODO: Mở OpenFileDialog lọc ảnh (*.jpg;*.jpeg;*.png;*.bmp).
            //       Nếu chọn file: hiện ảnh lên picAnh (lưu ý giữ đúng tỉ lệ) và nhớ đường dẫn ảnh
            //       để khi Lưu thì chuyển ảnh sang chuỗi Base64 lưu vào dữ liệu.
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            // TODO: Xóa ảnh của nhân viên đang chọn: picAnh.Image = null; xóa đường dẫn ảnh đã nhớ.
        }
    }
}
