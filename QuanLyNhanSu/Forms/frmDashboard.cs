using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// MÀN HÌNH BẢNG ĐIỀU KHIỂN (frmDashboard) – cửa sổ con của frmMain.
    ///
    /// Giao diện đã có sẵn trong frmDashboard.Designer.cs: 4 thẻ số liệu
    /// (pnlThe1..pnlThe4 với lblSo1..lblSo4 / lblTen1..lblTen4), lời chào
    /// (lblChaoMung, lblHomNay) và danh sách sinh nhật (grpSinhNhat + lstSinhNhat).
    /// </summary>
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  CÁC HÀM CẦN LẬP TRÌNH
        // =====================================================================

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // TODO: - Hiện lời chào + ngày giờ hiện tại lên lblChaoMung / lblHomNay.
            //       - Đếm và hiện lên 4 thẻ số liệu:
            //           lblSo1 = tổng số nhân viên,  lblSo2 = tổng số phòng ban,
            //           lblSo3 = tổng số chức vụ,    lblSo4 = số nhân viên đang công tác.
            //       - Nạp danh sách nhân viên có sinh nhật trong tháng hiện tại vào lstSinhNhat
            //         (họ tên – ngày sinh – phòng ban).
        }
    }
}
