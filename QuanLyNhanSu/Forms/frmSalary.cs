using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyNhanSu.Data;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    /// <summary>
    /// Màn hình Tính lương &amp; Phiếu lương: tính lương theo tháng, xuất phiếu lương cá nhân
    /// ra tập tin .txt và xuất toàn bộ bảng lương ra tập tin .csv.
    /// </summary>
    public partial class frmSalary : Form
    {
        private bool dangNap;

        public frmSalary()
        {
            InitializeComponent();
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);

            dangNap = true;

            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }

            cboThang.SelectedIndex = DateTime.Today.Month - 1;
            nudNam.Value = DateTime.Today.Year;

            cboPhong.Items.Clear();
            cboPhong.Items.Add("-- Tất cả phòng ban --");
            foreach (PhongBan p in Store.Data.PhongBans)
            {
                cboPhong.Items.Add(p);
            }

            cboPhong.SelectedIndex = 0;

            dangNap = false;
            TinhLuong();

            CotDanhSach.VuaTieuDe(lvLuong);
        }

        private int ThangDangChon
        {
            get { return cboThang.SelectedIndex + 1; }
        }

        private int NamDangChon
        {
            get { return (int)nudNam.Value; }
        }

        private string MaPhongDangChon
        {
            get
            {
                PhongBan p = cboPhong.SelectedItem as PhongBan;
                return p == null ? "" : p.MaPhong;
            }
        }

        // ------------------------------------------------------------------
        // Tính lương
        // ------------------------------------------------------------------
        private void TinhLuong()
        {
            List<DongLuong> ds = NghiepVu.TinhLuongThang(ThangDangChon, NamDangChon, MaPhongDangChon);

            lvLuong.BeginUpdate();
            lvLuong.Items.Clear();

            decimal tongQuy = 0;
            foreach (DongLuong dl in ds)
            {
                ListViewItem item = new ListViewItem(dl.MaNV);
                item.SubItems.Add(dl.HoTen);
                item.SubItems.Add(dl.LuongCoBan.ToString("#,##0"));
                item.SubItems.Add(dl.NgayLam.ToString());
                item.SubItems.Add(dl.SoLanDiTre.ToString());
                item.SubItems.Add(dl.GioTangCa.ToString("0.##"));
                item.SubItems.Add(dl.PhepConLai.ToString());
                item.SubItems.Add(dl.TongLuong.ToString("#,##0"));
                item.Tag = dl;

                lvLuong.Items.Add(item);
                tongQuy += dl.TongLuong;
            }

            lvLuong.EndUpdate();

            lblThongTin.Text = string.Format(
                "Ngày công chuẩn: {0} | Trừ đi trễ: {1} đ/lần | Tổng quỹ lương: {2} VNĐ",
                CauHinh.NgayCongChuan,
                CauHinh.MucTruDiTre.ToString("#,##0"),
                tongQuy.ToString("#,##0"));
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            TinhLuong();
            MessageBox.Show(string.Format("Đã tính lương tháng {0}/{1} cho {2} nhân viên.",
                ThangDangChon, NamDangChon, lvLuong.Items.Count),
                "Tính lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TinhLuong();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNap && IsHandleCreated)
            {
                TinhLuong();
            }
        }

        private void nudNam_ValueChanged(object sender, EventArgs e)
        {
            if (!dangNap && IsHandleCreated)
            {
                TinhLuong();
            }
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNap && IsHandleCreated)
            {
                TinhLuong();
            }
        }

        // ------------------------------------------------------------------
        // Xuất phiếu lương (.txt)
        // ------------------------------------------------------------------
        private void btnXuatPhieuLuong_Click(object sender, EventArgs e)
        {
            if (lvLuong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên trên danh sách để xuất phiếu lương.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DongLuong dl = lvLuong.SelectedItems[0].Tag as DongLuong;
            if (dl == null)
            {
                return;
            }

            saveFileDialog1.Filter = "Tập tin văn bản (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*";
            saveFileDialog1.FileName = string.Format("phieu_luong_{0}_{1:00}_{2}.txt",
                dl.MaNV, ThangDangChon, NamDangChon);

            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(CauHinh.TenDonVi.ToUpper());
                sb.AppendLine("PHIẾU LƯƠNG NHÂN VIÊN");
                sb.AppendLine("Tháng " + ThangDangChon + " năm " + NamDangChon);
                sb.AppendLine(new string('=', 60));
                sb.AppendLine("Mã nhân viên     : " + dl.MaNV);
                sb.AppendLine("Họ và tên        : " + dl.HoTen);
                NhanVien nv = NghiepVu.TimNhanVien(dl.MaNV);
                if (nv != null)
                {
                    sb.AppendLine("Phòng ban        : " + NghiepVu.TenPhong(nv.MaPhong));
                    sb.AppendLine("Chức vụ          : " + NghiepVu.TenChucVu(nv.MaChucVu));
                }

                sb.AppendLine(new string('-', 60));
                sb.AppendLine("Lương cơ bản             : " + dl.LuongCoBan.ToString("#,##0") + " VNĐ");
                sb.AppendLine("Ngày công chuẩn          : " + CauHinh.NgayCongChuan + " ngày");
                sb.AppendLine("Ngày làm thực tế         : " + dl.NgayLam + " ngày");
                sb.AppendLine("Lương theo ngày công     : " + dl.LuongTheoNgayCong.ToString("#,##0") + " VNĐ");
                sb.AppendLine("Số giờ tăng ca           : " + dl.GioTangCa.ToString("0.##") + " giờ");
                sb.AppendLine("Tiền tăng ca             : " + dl.TienTangCa.ToString("#,##0") + " VNĐ");
                sb.AppendLine("Số lần đi trễ            : " + dl.SoLanDiTre);
                sb.AppendLine("Tiền trừ đi trễ          : -" + dl.TienTruDiTre.ToString("#,##0") + " VNĐ");
                sb.AppendLine("Ngày nghỉ phép           : " + dl.SoNgayNghiPhep);
                sb.AppendLine("Ngày nghỉ không phép     : " + dl.SoNgayNghiKhongPhep);
                sb.AppendLine("Phép năm còn lại         : " + dl.PhepConLai + " ngày");
                sb.AppendLine(new string('-', 60));
                sb.AppendLine("TỔNG LƯƠNG               : " + dl.TongLuong.ToString("#,##0") + " VNĐ");
                sb.AppendLine(new string('=', 60));
                sb.AppendLine("Ngày lập phiếu: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));

                MessageBox.Show("Đã xuất phiếu lương:\n" + saveFileDialog1.FileName,
                    "Xuất phiếu lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất phiếu lương thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------
        // Xuất bảng lương (.csv)
        // ------------------------------------------------------------------
        private void btnXuatBangLuong_Click(object sender, EventArgs e)
        {
            if (lvLuong.Items.Count == 0)
            {
                MessageBox.Show("Bảng lương đang trống, chưa có gì để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            saveFileDialog1.Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*";
            saveFileDialog1.FileName = string.Format("bang_luong_{0:00}_{1}.csv", ThangDangChon, NamDangChon);

            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Mã NV,Tên NV,Lương cơ bản,Ngày làm thực tế,Số lần đi trễ,Số giờ tăng ca,Phép năm còn lại,Tổng lương");

                foreach (ListViewItem item in lvLuong.Items)
                {
                    DongLuong dl = item.Tag as DongLuong;
                    if (dl == null)
                    {
                        continue;
                    }

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                        "{0},{1},{2},{3},{4},{5},{6},{7}",
                        dl.MaNV,
                        dl.HoTen.Replace(",", " "),
                        dl.LuongCoBan,
                        dl.NgayLam,
                        dl.SoLanDiTre,
                        dl.GioTangCa,
                        dl.PhepConLai,
                        dl.TongLuong));
                }

                // Ghi kèm BOM để Excel mở đúng tiếng Việt
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));

                MessageBox.Show("Đã xuất bảng lương:\n" + saveFileDialog1.FileName,
                    "Xuất bảng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất bảng lương thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
