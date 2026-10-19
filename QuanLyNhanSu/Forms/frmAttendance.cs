using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// YÊU CẦU 2 – CHẤM CÔNG (frmAttendance).
    ///
    /// Giao diện đã có sẵn trong frmAttendance.Designer.cs:
    ///   - panelTop : chọn phòng ban (cboPhong), ngày (dtpNgay), nút Tải danh sách,
    ///                nút Nhập từ CSV, nhãn tổng kết (lblTong)
    ///   - lvChamCong : danh sách nhân viên kèm CheckBox chọn
    ///   - cmsTrangThai : menu chuột phải đổi trạng thái (Đi làm / Nghỉ phép /
    ///                    Nghỉ không phép / Đi trễ / Tăng ca)
    ///   - panelBottom : nút Chọn tất cả / Bỏ chọn / Lưu bảng công
    ///
    /// CÁC VIỆC CẦN LÀM:
    ///   1. Không cho chọn ngày tương lai (dtpNgay.MaxDate = DateTime.Today).
    ///   2. Nạp danh sách nhân viên của phòng ban theo ngày đang chọn.
    ///   3. Đổi trạng thái chấm công bằng menu chuột phải, chọn/bỏ chọn tất cả.
    ///   4. Tính và hiện tổng kết (đi làm / nghỉ / đi trễ / tăng ca).
    ///   5. Lưu bảng công và nhập bảng công từ file CSV.
    /// </summary>
    public partial class frmAttendance : Form
    {
        public frmAttendance()
        {
            InitializeComponent();
        }

        // =====================================================================
        //  NẠP DỮ LIỆU
        // =====================================================================

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            // TODO: - Nạp danh sách phòng ban vào cboPhong.
            //       - Chặn chọn ngày tương lai: dtpNgay.MaxDate = DateTime.Today;
            //         và đặt dtpNgay.Value = DateTime.Today.
            //       - Gọi hàm nạp bảng công của ngày/phòng ban đang chọn.
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Nạp lại bảng công cho phòng ban vừa chọn.
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Nạp lại bảng công cho ngày vừa chọn.
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            // TODO: Nạp danh sách nhân viên đang công tác của phòng ban đang chọn vào lvChamCong,
            //       kèm trạng thái chấm công đã lưu của ngày đó (nếu chưa chấm thì mặc định "Chưa chấm").
        }

        private void lvChamCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Cập nhật thông tin chi tiết / nhãn cảnh báo (lblCanhBao) cho dòng đang chọn.
        }

        // =====================================================================
        //  CHỌN / TRẠNG THÁI CHẤM CÔNG
        // =====================================================================

        private void btnChonTatCa_Click(object sender, EventArgs e)
        {
            // TODO: Tick chọn tất cả các dòng trong lvChamCong.
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            // TODO: Bỏ tick tất cả các dòng trong lvChamCong.
        }

        private void lvChamCong_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // TODO: Tính lại và hiện lên lblTong: số người đi làm / nghỉ / đi trễ / tăng ca.
        }

        private void lvChamCong_MouseDown(object sender, MouseEventArgs e)
        {
            // TODO: Nếu là chuột phải (e.Button == MouseButtons.Right) và có dòng được chọn
            //       thì hiện menu cmsTrangThai tại vị trí con trỏ: cmsTrangThai.Show(lvChamCong, e.Location);
        }

        private void cmsTrangThai_Opening(object sender, CancelEventArgs e)
        {
            // TODO: Chỉ cho menu hiện khi có ít nhất một dòng được chọn
            //       (nếu không thì e.Cancel = true;).
        }

        private void mnuDiLam_Click(object sender, EventArgs e)
        {
            // TODO: Đặt trạng thái "Đi làm" cho các dòng đang chọn.
        }

        private void mnuNghiPhep_Click(object sender, EventArgs e)
        {
            // TODO: Đặt trạng thái "Nghỉ phép" cho các dòng đang chọn.
        }

        private void mnuNghiKhongPhep_Click(object sender, EventArgs e)
        {
            // TODO: Đặt trạng thái "Nghỉ không phép" cho các dòng đang chọn.
        }

        private void mnuDiTre_Click(object sender, EventArgs e)
        {
            // TODO: Đặt trạng thái "Đi trễ" cho các dòng đang chọn
            //       (nếu cần thì hỏi thêm số phút đi trễ để sau này trừ lương).
        }

        private void mnuTangCa_Click(object sender, EventArgs e)
        {
            // TODO: Đặt trạng thái "Tăng ca" cho các dòng đang chọn
            //       (nếu cần thì hỏi thêm số giờ tăng ca để sau này cộng lương).
        }

        // =====================================================================
        //  LƯU / NHẬP TỪ FILE
        // =====================================================================

        private void btnLuuBangCong_Click(object sender, EventArgs e)
        {
            // TODO: Lưu bảng công của ngày/phòng ban đang xem xuống dữ liệu rồi thông báo đã lưu.
        }

        private void btnNhapCSV_Click(object sender, EventArgs e)
        {
            // TODO: Mở OpenFileDialog chọn file .csv (mỗi dòng: Mã nhân viên, Trạng thái[, số giờ/ phút]),
            //       đọc file và cập nhật trạng thái chấm công tương ứng vào bảng công đang xem.
        }
    }
}
