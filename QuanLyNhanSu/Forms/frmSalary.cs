using System;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// YÊU CẦU 3 – TÍNH LƯƠNG (frmSalary).
    ///
    /// Giao diện đã có sẵn trong frmSalary.Designer.cs:
    ///   - panelTop : chọn tháng (cboThang), năm (nudNam), phòng ban (cboPhong),
    ///                nút Xem (btnXem)
    ///   - lvLuong  : bảng lương (dòng cuối là TỔNG LƯƠNG)
    ///   - panelBottom : nút Tính lương, Xuất bảng lương, Xuất phiếu lương
    ///
    /// CÁC VIỆC CẦN LÀM:
    ///   1. Nạp tháng / năm / phòng ban và tính lương theo điều kiện đang chọn.
    ///   2. Công thức đọc các tham số từ App.config (xem mục appSettings):
    ///        NgayCongChuan (26), MucTruDiTre (100000), HeSoTangCa (1.5), SoGioLamChuan (8),
    ///        TenDonVi (tên đơn vị in trên phiếu lương).
    ///   3. Xuất bảng lương ra file CSV và xuất phiếu lương của một nhân viên ra file TXT.
    /// </summary>
    public partial class frmSalary : Form
    {
        public frmSalary()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  NẠP DỮ LIỆU – TÍNH LƯƠNG
        // =====================================================================

        private void frmSalary_Load(object sender, EventArgs e)
        {
            // TODO: - Nạp tháng 1..12 vào cboThang (mặc định tháng hiện tại).
            //       - Nạp năm vào nudNam (MinYear = năm hiện tại - 5, mặc định năm hiện tại).
            //       - Nạp phòng ban vào cboPhong, thêm mục "Tất cả phòng ban".
            //       - Đọc các tham số lương từ App.config (ConfigurationManager.AppSettings).
            //       - Gọi tính lương cho tháng/năm hiện tại.
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // TODO: Tải lại (tính lại) bảng lương theo tháng / năm / phòng ban đang chọn.
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Tính lại bảng lương khi đổi tháng.
        }

        private void nudNam_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Tính lại bảng lương khi đổi năm.
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Tính lại bảng lương khi đổi phòng ban.
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            // TODO: Tính lương cho từng nhân viên rồi đổ lên lvLuong, gồm các cột:
            //         Mã NV | Họ tên | Phòng ban | Lương cơ bản | Ngày công |
            //         Trừ đi trễ | Tiền tăng ca | Thực lĩnh
            //       Công thức gợi ý:
            //         Lương ngày      = Lương cơ bản / NgayCongChuan
            //         Lương theo công = Lương ngày * số ngày công thực tế
            //         Trừ đi trễ      = số lần đi trễ * MucTruDiTre
            //         Tiền tăng ca    = Lương ngày / SoGioLamChuan * số giờ tăng ca * HeSoTangCa
            //         Thực lĩnh       = Lương theo công - Trừ đi trễ + Tiền tăng ca
            //       Dòng cuối cùng của ListView là TỔNG LƯƠNG của toàn bộ danh sách.
        }

        // =====================================================================
        //  XUẤT FILE
        // =====================================================================

        private void btnXuatBangLuong_Click(object sender, EventArgs e)
        {
            // TODO: SaveFileDialog (bảng lương.csv) -> ghi toàn bộ bảng lương ra file CSV
            //       (nên ghi theo UTF-8 để không lỗi tiếng Việt trong Excel).
        }

        private void btnXuatPhieuLuong_Click(object sender, EventArgs e)
        {
            // TODO: SaveFileDialog (phiếu lương.txt) -> ghi phiếu lương của nhân viên
            //       đang chọn trong lvLuong, gồm tên đơn vị (TenDonVi), họ tên, phòng ban,
            //       tháng/năm, các khoản lương và thực lĩnh.
        }
    }
}
