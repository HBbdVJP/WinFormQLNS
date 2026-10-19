using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// MÀN HÌNH CHÍNH (frmMain) – form cha MDI chứa thanh MenuStrip và StatusStrip.
    ///
    /// Giao diện đã có sẵn trong frmMain.Designer.cs: 5 menu (Hệ thống, Quản lý,
    /// Nghiệp vụ, Cửa sổ, Trợ giúp), StatusStrip có lblNguoiDung, lblVaiTro, lblDongHo.
    /// File này chỉ chứa phần LẬP TRÌNH.
    ///
    /// CÁC VIỆC CẦN LÀM:
    ///   1. Mở các màn hình con (Dashboard, Hồ sơ, Phòng ban, Chức vụ, Chấm công, Tính lương).
    ///   2. Đồng hồ thời gian thực trên StatusStrip.
    ///   3. Đổi màu / đổi font giao diện và lưu lại (Registry).
    ///   4. Sao lưu / phục hồi dữ liệu.
    ///   5. Xếp các cửa sổ con, đăng xuất, giới thiệu, thoát.
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  CÁC HÀM CẦN LẬP TRÌNH
        // =====================================================================

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: - Đặt tiêu đề form (Text) theo tên đơn vị đọc từ App.config.
            //       - Hiện tên người đăng nhập ở lblNguoiDung và quyền ở lblVaiTro.
            //       - Bật timerDongHo để cập nhật đồng hồ.
            //       - Mở form Dashboard làm cửa sổ con đầu tiên (xem mnuBangDieuKhien_Click).
            //       - Áp dụng màu nền / font chữ đã lưu trong Registry (xem mnuDoiMau_Click).
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            // TODO: lblDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void mnuBangDieuKhien_Click(object sender, EventArgs e)
        {
            // TODO: Mở form Dashboard (frmDashboard) dưới dạng form con MDI.
        }

        private void mnuHoSo_Click(object sender, EventArgs e)
        {
            // TODO: Mở màn hình Quản lý hồ sơ nhân viên (frmEmployee).
        }

        private void mnuPhongBan_Click(object sender, EventArgs e)
        {
            // TODO: Mở màn hình Quản lý phòng ban (frmDepartment).
        }

        private void mnuChucVu_Click(object sender, EventArgs e)
        {
            // TODO: Mở màn hình Quản lý chức vụ (frmPosition).
        }

        private void mnuChamCong_Click(object sender, EventArgs e)
        {
            // TODO: Mở màn hình Chấm công (frmAttendance).
        }

        private void mnuTinhLuong_Click(object sender, EventArgs e)
        {
            // TODO: Mở màn hình Tính lương (frmSalary).
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // TODO: Đóng tất cả form con, ẩn frmMain rồi mở lại frmLogin (ShowDialog);
            //       nếu đăng nhập lại thành công thì hiện frmMain trở lại.
        }

        private void mnuDoiMau_Click(object sender, EventArgs e)
        {
            // TODO: Mở ColorDialog cho người dùng chọn màu, áp dụng cho menuStrip1/statusStrip1
            //       (và các form con đang mở) rồi lưu màu vào Registry để lần sau tự nạp lại.
        }

        private void mnuDoiFont_Click(object sender, EventArgs e)
        {
            // TODO: Mở FontDialog, áp dụng font cho toàn bộ form và các form con, lưu vào Registry.
        }

        private void mnuMacDinh_Click(object sender, EventArgs e)
        {
            // TODO: Trả giao diện về màu và font mặc định, xóa giá trị đã lưu trong Registry.
        }

        private void mnuSaoLuu_Click(object sender, EventArgs e)
        {
            // TODO: SaveFileDialog -> sao chép file dữ liệu (JSON) ra nơi người dùng chọn.
            //       (Gợi ý: dùng File.Copy)
        }

        private void mnuPhucHoi_Click(object sender, EventArgs e)
        {
            // TODO: OpenFileDialog chọn file sao lưu -> hỏi xác nhận -> ghi đè file dữ liệu -> nạp lại.
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            // TODO: Hỏi xác nhận rồi đóng ứng dụng: Close();
        }

        private void mnuXepChong_Click(object sender, EventArgs e)
        {
            // TODO: LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuXepNgang_Click(object sender, EventArgs e)
        {
            // TODO: LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuXepDoc_Click(object sender, EventArgs e)
        {
            // TODO: LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            // TODO: Hộp thoại giới thiệu chương trình (MessageBox.Show với tên bài, tên nhóm, phiên bản).
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: Hỏi "Bạn có chắc muốn thoát?" – nếu chọn Không thì e.Cancel = true;
        }
    }
}
