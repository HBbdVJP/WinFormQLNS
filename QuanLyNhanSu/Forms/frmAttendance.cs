using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Màn hình Chấm công hằng ngày: tick chọn nhân viên đi làm, dùng menu ngữ cảnh
    /// để đổi trạng thái (nghỉ phép, nghỉ không phép, đi trễ) và đánh dấu tăng ca.
    /// </summary>
    public partial class frmAttendance : Form
    {
        private bool dangNap;

        public frmAttendance()
        {
            InitializeComponent();
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            TuyChinh.ApDung(this);

            // Không cho phép chọn ngày tương lai
            dtpNgay.MaxDate = DateTime.Today;
            dtpNgay.Value = DateTime.Today;

            cboPhong.Items.Clear();
            cboPhong.Items.Add("-- Tất cả phòng ban --");
            foreach (PhongBan p in Store.Data.PhongBans)
            {
                cboPhong.Items.Add(p);
            }

            cboPhong.SelectedIndex = 0;
            NapBangChamCong();

            CotDanhSach.VuaTieuDe(lvChamCong);
        }

        // ------------------------------------------------------------------
        // Nạp danh sách chấm công của ngày đang chọn
        // ------------------------------------------------------------------
        private void NapBangChamCong()
        {
            dangNap = true;
            lvChamCong.BeginUpdate();
            lvChamCong.Items.Clear();

            string maPhong = "";
            PhongBan p = cboPhong.SelectedItem as PhongBan;
            if (p != null)
            {
                maPhong = p.MaPhong;
            }

            DateTime ngay = dtpNgay.Value.Date;

            foreach (NhanVien nv in Store.Data.NhanViens)
            {
                if (!string.IsNullOrEmpty(maPhong) && nv.MaPhong != maPhong)
                {
                    continue;
                }

                ChamCong cc = TimChamCong(nv.MaNV, ngay);
                LoaiChamCong tt = cc == null ? LoaiChamCong.DiLam : cc.TrangThai;
                double tangCa = cc == null ? 0 : cc.GioTangCa;
                string ghiChu = cc == null ? "" : cc.GhiChu;

                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(nv.MaNV);
                item.SubItems.Add(nv.HoTen);
                item.SubItems.Add(NghiepVu.TenPhong(nv.MaPhong));
                item.SubItems.Add(NghiepVu.TenTrangThaiChamCong(tt));
                item.SubItems.Add(tangCa.ToString("0.##"));
                item.SubItems.Add(ghiChu);
                item.Tag = nv;
                item.Checked = tt == LoaiChamCong.DiLam || tt == LoaiChamCong.DiTre;

                lvChamCong.Items.Add(item);
            }

            lvChamCong.EndUpdate();
            dangNap = false;
            CapNhatTong();
        }

        private ChamCong TimChamCong(string maNV, DateTime ngay)
        {
            return Store.Data.ChamCongs.Find(c => c.MaNV == maNV && c.Ngay.Date == ngay);
        }

        private void CapNhatTong()
        {
            int diLam = 0;
            foreach (ListViewItem item in lvChamCong.Items)
            {
                if (item.Checked)
                {
                    diLam++;
                }
            }

            lblTong.Text = string.Format("Tổng: {0} nhân viên - Đi làm: {1} - Nghỉ: {2}",
                lvChamCong.Items.Count, diLam, lvChamCong.Items.Count - diLam);
        }

        // ------------------------------------------------------------------
        // Sự kiện trên ListView
        // ------------------------------------------------------------------
        private void lvChamCong_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (dangNap)
            {
                return;
            }

            string hienTai = e.Item.SubItems[4].Text;
            if (e.Item.Checked)
            {
                if (hienTai != "Đi làm" && hienTai != "Đi trễ")
                {
                    DatTrangThai(e.Item, LoaiChamCong.DiLam);
                }
            }
            else if (hienTai == "Đi làm" || hienTai == "Đi trễ")
            {
                DatTrangThai(e.Item, LoaiChamCong.NghiPhep);
            }

            CapNhatTong();
        }

        private void lvChamCong_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            ListViewItem item = lvChamCong.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                lvChamCong.SelectedItems.Clear();
                return;
            }

            item.Selected = true;
            item.Focused = true;
        }

        private void cmsTrangThai_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lvChamCong.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void DatTrangThai(ListViewItem item, LoaiChamCong tt)
        {
            item.SubItems[4].Text = NghiepVu.TenTrangThaiChamCong(tt);

            dangNap = true;
            item.Checked = tt == LoaiChamCong.DiLam || tt == LoaiChamCong.DiTre;
            dangNap = false;

            if (tt == LoaiChamCong.NghiPhep || tt == LoaiChamCong.NghiKhongPhep)
            {
                item.SubItems[5].Text = "0";
            }
        }

        private void mnuDiLam_Click(object sender, EventArgs e)
        {
            XuLyMenu(LoaiChamCong.DiLam);
        }

        private void mnuNghiPhep_Click(object sender, EventArgs e)
        {
            XuLyMenu(LoaiChamCong.NghiPhep);
        }

        private void mnuNghiKhongPhep_Click(object sender, EventArgs e)
        {
            XuLyMenu(LoaiChamCong.NghiKhongPhep);
        }

        private void mnuDiTre_Click(object sender, EventArgs e)
        {
            XuLyMenu(LoaiChamCong.DiTre);
        }

        private void XuLyMenu(LoaiChamCong tt)
        {
            foreach (ListViewItem item in lvChamCong.SelectedItems)
            {
                DatTrangThai(item, tt);
            }

            CapNhatTong();
        }

        private void mnuTangCa_Click(object sender, EventArgs e)
        {
            if (lvChamCong.SelectedItems.Count == 0)
            {
                return;
            }

            double hienTai = 0;
            double.TryParse(lvChamCong.SelectedItems[0].SubItems[5].Text,
                NumberStyles.Float, CultureInfo.InvariantCulture, out hienTai);

            string nhap = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập số giờ tăng ca (0 để bỏ tăng ca):",
                "Đánh dấu tăng ca", hienTai.ToString("0.##"));

            if (string.IsNullOrWhiteSpace(nhap))
            {
                return;
            }

            double gio;
            if (!double.TryParse(nhap.Replace(",", "."), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out gio) || gio < 0 || gio > 12)
            {
                MessageBox.Show("Số giờ tăng ca không hợp lệ (từ 0 đến 12).", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ListViewItem item in lvChamCong.SelectedItems)
            {
                string trangThai = item.SubItems[4].Text;
                if (trangThai == "Nghỉ phép" || trangThai == "Nghỉ không phép")
                {
                    DatTrangThai(item, LoaiChamCong.DiLam);
                }

                item.SubItems[5].Text = gio.ToString("0.##");
                item.SubItems[6].Text = "Tăng ca";
            }
        }

        // ------------------------------------------------------------------
        // Điều hướng
        // ------------------------------------------------------------------
        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgay.Value.Date > DateTime.Today)
            {
                lblCanhBao.Text = "Không được chấm công cho ngày tương lai!";
                dtpNgay.Value = DateTime.Today;
                return;
            }

            lblCanhBao.Text = "";
            if (IsHandleCreated && !dangNap)
            {
                NapBangChamCong();
            }
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                NapBangChamCong();
            }
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            NapBangChamCong();
        }

        private void btnChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvChamCong.Items)
            {
                if (!item.Checked)
                {
                    item.Checked = true;
                }
                else
                {
                    DatTrangThai(item, LoaiChamCong.DiLam);
                }
            }

            CapNhatTong();
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvChamCong.Items)
            {
                item.Checked = false;
                DatTrangThai(item, LoaiChamCong.NghiPhep);
            }

            CapNhatTong();
        }

        // ------------------------------------------------------------------
        // Nhập từ CSV
        // ------------------------------------------------------------------
        private void btnNhapCSV_Click(object sender, EventArgs e)
        {
            if (openFileDialogCSV.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                string[] dong = File.ReadAllLines(openFileDialogCSV.FileName, Encoding.UTF8);
                int soDong = 0;

                foreach (string s in dong)
                {
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        continue;
                    }

                    string[] cot = s.Split(new[] { ',', ';', '\t' }, StringSplitOptions.None);
                    if (cot.Length < 2)
                    {
                        continue;
                    }

                    string maNV = cot[0].Trim();
                    if (maNV.Equals("MaNV", StringComparison.OrdinalIgnoreCase))
                    {
                        continue; // dòng tiêu đề
                    }

                    ListViewItem item = null;
                    foreach (ListViewItem it in lvChamCong.Items)
                    {
                        NhanVien nv = it.Tag as NhanVien;
                        if (nv != null && nv.MaNV.Equals(maNV, StringComparison.OrdinalIgnoreCase))
                        {
                            item = it;
                            break;
                        }
                    }

                    if (item == null)
                    {
                        continue;
                    }

                    DatTrangThai(item, DoanTrangThai(cot[1].Trim()));

                    if (cot.Length >= 3)
                    {
                        double gio;
                        if (double.TryParse(cot[2].Trim().Replace(",", "."),
                                NumberStyles.Float, CultureInfo.InvariantCulture, out gio))
                        {
                            item.SubItems[5].Text = gio.ToString("0.##");
                        }
                    }

                    soDong++;
                }

                CapNhatTong();
                MessageBox.Show(string.Format("Đã nhập {0} dòng chấm công từ tập tin.", soDong),
                    "Nhập từ CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đọc được tập tin CSV: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static LoaiChamCong DoanTrangThai(string chuoi)
        {
            string s = chuoi.ToLowerInvariant();
            if (s.Contains("trễ") || s.Contains("tre") || s.Contains("late"))
            {
                return LoaiChamCong.DiTre;
            }

            if (s.Contains("không phép") || s.Contains("khong phep") || s.Contains("kp"))
            {
                return LoaiChamCong.NghiKhongPhep;
            }

            if (s.Contains("phép") || s.Contains("phep") || s.Contains("nghỉ") || s.Contains("nghi"))
            {
                return LoaiChamCong.NghiPhep;
            }

            return LoaiChamCong.DiLam;
        }

        // ------------------------------------------------------------------
        // Lưu bảng công
        // ------------------------------------------------------------------
        private void btnLuuBangCong_Click(object sender, EventArgs e)
        {
            if (lvChamCong.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhân viên nào trong bảng chấm công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime ngay = dtpNgay.Value.Date;
            int soLuu = 0;

            foreach (ListViewItem item in lvChamCong.Items)
            {
                NhanVien nv = item.Tag as NhanVien;
                if (nv == null)
                {
                    continue;
                }

                LoaiChamCong tt = DoanTrangThai(item.SubItems[4].Text);

                double gio = 0;
                double.TryParse(item.SubItems[5].Text, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out gio);

                ChamCong cc = TimChamCong(nv.MaNV, ngay);
                if (cc == null)
                {
                    cc = new ChamCong { MaNV = nv.MaNV, Ngay = ngay };
                    Store.Data.ChamCongs.Add(cc);
                }

                cc.TrangThai = tt;
                cc.GioTangCa = gio;
                cc.GhiChu = item.SubItems[6].Text;
                soLuu++;
            }

            Store.Save();

            MessageBox.Show(string.Format("Đã lưu bảng công ngày {0:dd/MM/yyyy} cho {1} nhân viên.",
                ngay, soLuu), "Lưu bảng công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lvChamCong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
