using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// MÀN HÌNH ĐĂNG NHẬP (frmLogin) – form không viền (FormBorderStyle = None).
    ///
    /// Giao diện đã được thiết kế sẵn bằng Windows Forms Designer và nằm nguyên trong
    /// file frmLogin.Designer.cs (logo, ô tên đăng nhập, ô mật khẩu, các nút...).
    /// File này CHỈ chứa phần LẬP TRÌNH – không dựng thêm control bằng code.
    ///
    /// CÁC VIỆC CẦN LÀM (xem chú thích TODO ở từng hàm):
    ///   1. Đọc tài khoản đã "ghi nhớ" trong Registry khi mở form.
    ///   2. Kiểm tra đăng nhập, sai 3 lần thì khóa 30 giây (đếm ngược bằng timerKhoa).
    ///   3. Hiện/ẩn mật khẩu, thoát chương trình, kéo form bằng chuột nếu cần.
    ///
    /// Tài khoản mẫu để thử: admin / admin123 ; nv01 / 123456 ; nv02 / 123456
    /// </summary>
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  CÁC HÀM CẦN LẬP TRÌNH (tên hàm do Designer gán sẵn cho sự kiện)
        // =====================================================================

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: Đọc tài khoản đã "Ghi nhớ đăng nhập" từ Registry
            //       (khóa HKCU\Software\QuanLyNhanSu: Tên đăng nhập / Mật khẩu đã lưu)
            //       rồi điền sẵn vào txtUsername, txtPassword và tick chkGhiNho.
            //       Nhớ xóa dòng cảnh báo lblLoi và đưa con trỏ vào txtUsername.
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // TODO: Lấy txtUsername.Text và txtPassword.Text rồi kiểm tra với danh sách tài khoản.
            //   - Đúng  : (nếu chkGhiNho được tick thì lưu tài khoản vào Registry, ngược lại thì xóa),
            //             đặt DialogResult = DialogResult.OK và đóng form để mở frmMain.
            //   - Sai   : đếm số lần sai; hiện thông báo ở lblLoi (tô đỏ);
            //             sai đủ 3 lần thì khóa: tắt btnDangNhap, bật timerKhoa (30 giây).
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: Cho phép hiện mật khẩu: txtPassword.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void timerKhoa_Tick(object sender, EventArgs e)
        {
            // TODO: Đếm ngược thời gian khóa (30 -> 0) và hiện lên lblLoi,
            //       khi hết giờ thì dừng timer, mở lại btnDangNhap và xóa lblLoi.
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // TODO: Đóng form đăng nhập (DialogResult = DialogResult.Cancel; Close();)
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // TODO: Thoát hẳn chương trình: Application.Exit();
        }
    }
}
