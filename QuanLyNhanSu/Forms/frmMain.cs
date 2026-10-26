using System;
using System.IO;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;

namespace QuanLyNhanSu.Forms
{
    public partial class frmMain : Form
    {
        public frmMain(string maTK)
        {
            InitializeComponent();
            maTaiKhoan = maTK;
        }
        public string maTaiKhoan;
        
        //filepath string comp
        public string phongBanFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "DummyData", "PhongBan.txt");
        public string chucVuFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "DummyData", "ChucVu.txt");
        public string nhanVienFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "DummyData", "NhanVien.txt");

        // init List<>
        List<PhongBan> phongBanList = new List<PhongBan>();
        List<ChucVu> chucVuList = new List<ChucVu>();
        List<NhanVien> nhanVienList = new List<NhanVien>();

        private void frmMain_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(phongBanFilePath))
            {
                string? line;
                string maPhongBan = "";
                string tenPhongBan = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("MaPhongBan: "))
                    {
                        maPhongBan = line.Substring("MaPhongBan: ".Length);
                    }
                    else if (line.StartsWith("TenPhongBan: "))
                    {
                        tenPhongBan = line.Substring("TenPhongBan: ".Length);
                    }
                    else if (line == "---")
                    {
                        phongBanList.Add(new PhongBan(maPhongBan, tenPhongBan));
                        maPhongBan = "";
                        tenPhongBan = "";
                    }
                }
            }
            using (StreamReader sr = new StreamReader(chucVuFilePath))
            {
                string? line;
                string maChucVu = "";
                string tenChucVu = "";
                decimal phuCap = 0;
                bool quyenHan = false;
                int constructorIndicator = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("MaChucVu: "))
                    {
                        constructorIndicator++;
                        maChucVu = line.Substring("MaChucVu: ".Length);
                    }
                    else if (line.StartsWith("TenChucVu: "))
                    {
                        constructorIndicator++;
                        tenChucVu = line.Substring("TenChucVu: ".Length);
                    }
                    else if (line.StartsWith("PhuCap: "))
                    {
                        constructorIndicator++;
                        phuCap = decimal.Parse(line.Substring("PhuCap: ".Length));
                    }
                    else if (line.StartsWith("QuyenHan: "))
                    {
                        constructorIndicator++;
                        quyenHan = bool.Parse(line.Substring("QuyenHan: ".Length));
                    }
                    else if (line == "---")
                    {
                        if (constructorIndicator == 4)
                        {
                            chucVuList.Add(new ChucVu(maChucVu, tenChucVu, phuCap, quyenHan));
                            maChucVu = "";
                            tenChucVu = "";
                            phuCap = 0;
                            quyenHan = false;
                            constructorIndicator = 0;
                        }
                        else
                        {
                            chucVuList.Add(new ChucVu(maChucVu, tenChucVu, phuCap));
                            maChucVu = "";
                            tenChucVu = "";
                            phuCap = 0;
                            constructorIndicator = 0;
                        }
                    }
                }
            }
            using (StreamReader sr = new StreamReader(nhanVienFilePath))
            {
                string? line;
                string maNhanVien = "";
                string tenNhanVien = "";
                string gioiTinh = "";
                DateTime ngaySinh = DateTime.MinValue;
                string maChucVu = "";
                string maPhongBan = "";
                string maTaiKhoan = "";
                int soNgayNghiPhep = 0;
                decimal luongCoBan = 0;
                Image? anhNhanVien = null;
                string pathAnhNhanVien = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("MaNhanVien: "))
                    {
                        maNhanVien = line.Substring("MaNhanVien: ".Length);
                    }
                    else if (line.StartsWith("TenNhanVien: "))
                    {
                        tenNhanVien = line.Substring("TenNhanVien: ".Length);
                    }
                    else if (line.StartsWith("GioiTinh: "))
                    {
                        gioiTinh = line.Substring("GioiTinh: ".Length);
                    }
                    else if (line.StartsWith("NgaySinh: "))
                    {
                        ngaySinh = DateTime.Parse(line.Substring("NgaySinh: ".Length));
                    }
                    else if (line.StartsWith("MaChucVu: "))
                    {
                        maChucVu = line.Substring("MaChucVu: ".Length);
                    }
                    else if (line.StartsWith("MaPhongBan: "))
                    {
                        maPhongBan = line.Substring("MaPhongBan: ".Length);
                    }
                    else if (line.StartsWith("MaTaiKhoan: "))
                    {
                        maTaiKhoan = line.Substring("MaTaiKhoan: ".Length);
                    }
                    else if (line.StartsWith("SoNgayNghiPhep: "))
                    {
                        soNgayNghiPhep = int.Parse(line.Substring("SoNgayNghiPhep: ".Length));
                    }
                    else if (line.StartsWith("LuongCoBan: "))
                    {
                        luongCoBan = decimal.Parse(line.Substring("LuongCoBan: ".Length));
                    }
                    else if (line.StartsWith("AnhNhanVien: "))
                    {
                        pathAnhNhanVien = line.Substring("AnhNhanVien: ".Length);
                    }
                    else if (line == "---")
                    {
                        nhanVienList.Add(new NhanVien(maNhanVien, tenNhanVien, gioiTinh, ngaySinh, maChucVu, maPhongBan, maTaiKhoan, soNgayNghiPhep, luongCoBan, pathAnhNhanVien));
                        maNhanVien = "";
                        tenNhanVien = "";
                        gioiTinh = "";
                        ngaySinh = DateTime.MinValue;
                        maChucVu = "";
                        maPhongBan = "";
                        maTaiKhoan = "";
                        soNgayNghiPhep = 0;
                        luongCoBan = 0;
                        anhNhanVien = null;
                        pathAnhNhanVien = "";
                    }
                }
            }

            //init session login
            SessionLogin nvdangnhap = new SessionLogin(maTaiKhoan);
            nvdangnhap.RBACAuth(nhanVienList, chucVuList);
            lblNguoiDungName.Text = nvdangnhap.TenNhanVien;
            lblVaiTroName.Text = nvdangnhap.TenChucVu;


            //mặc định khởi tạo các tab form và mở form employee và ẩn các form khác
            frmAttendance attendanceForm = new frmAttendance();
            attendanceForm.MdiParent = this;
            attendanceForm.Hide();

            frmDepartment departmentForm = new frmDepartment(phongBanList, nhanVienList, nvdangnhap);
            departmentForm.MdiParent = this;
            departmentForm.Hide();

            frmEmployee employeeForm = new frmEmployee(nhanVienList, chucVuList, phongBanList, nvdangnhap);
            employeeForm.MdiParent = this;
            employeeForm.Show();

            frmPosition positionForm = new frmPosition(chucVuList,nhanVienList,nvdangnhap);
            positionForm.MdiParent = this;
            positionForm.Hide();

            frmSalary salaryForm = new frmSalary();
            salaryForm.MdiParent = this;
            salaryForm.Hide();
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mnuMultiMDIChildView_Click(object sender, EventArgs e)
        {
            mnuMultiMDIChildView.Text = mnuMultiMDIChildView.Text!.Contains("Bật") ? "Xem đa cửa sổ(Tắt)" : "Xem đa cửa sổ(Bật)";
        }
        private void mnuHoSoNhanVien_Click(object sender, EventArgs e)
        {
            // dấu ! để chắc chắn không null. mỗi ngày code học 1 điều mới www
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmEmployee)
                {
                    form.Show();
                    form.Activate();
                }
                else if (!mnuMultiMDIChildView.Text!.Contains("Bật"))
                {
                    form.Hide();
                }
            }
        }
        private void mnuPhongBan_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmDepartment)
                {
                    form.Show();
                    form.Activate();
                }
                else if (!mnuMultiMDIChildView.Text!.Contains("Bật"))
                {
                    form.Hide();
                }
            }
        }
        private void mnuChucVu_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmPosition)
                {
                    form.Show();
                    form.Activate();
                }
                else if (!mnuMultiMDIChildView.Text!.Contains("Bật"))
                {
                    form.Hide();
                }
            }
        }
        private void mnuChamCong_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmAttendance)
                {
                    form.Show();
                    form.Activate();
                }
                else if (!mnuMultiMDIChildView.Text!.Contains("Bật"))
                {
                    form.Hide();
                }
            }
        }
        private void mnuLuong_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmSalary)
                {
                    form.Show();
                    form.Activate();
                }
                else if (!mnuMultiMDIChildView.Text!.Contains("Bật"))
                {
                    form.Hide();
                }
            }
        }
        private void mnuXepChong_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        private void mnuXepNgang_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void mnuXepDoc_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void frmMain_Leave(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
