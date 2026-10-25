using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Classes;

namespace QuanLyNhanSu.Forms
{
    public partial class frmEmployee : Form
    {
        public frmEmployee(List<NhanVien> danhsachNV, List<ChucVu> danhsachCV, List<PhongBan> danhsachPB)
        {
            InitializeComponent();
            DanhSachNhanVien = danhsachNV;
            DanhSachChucVu = danhsachCV;
            DanhSachPhongBan = danhsachPB;
        }
        public List<NhanVien> DanhSachNhanVien { get; private set; } = new List<NhanVien>();
        public List<ChucVu> DanhSachChucVu { get; private set; } = new List<ChucVu>();
        public List<PhongBan> DanhSachPhongBan { get; private set; } = new List<PhongBan>();
    }
}
