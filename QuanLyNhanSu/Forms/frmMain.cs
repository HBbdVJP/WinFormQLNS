using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            
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
    }
}
