using System;
using System.Windows.Forms;
using System.IO;
using QuanLyNhanSu.Classes;
using System.Configuration;

namespace QuanLyNhanSu.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        List<User> availableUsers = new List<User>();

        string rememberLoginFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "RememberLogin", "GhiNhoDangNhapTemp.txt");
        string userDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "DummyData", "User.txt");
        int failedLoginAttemptCount = 0;
        int maxFailedLoginAttempts = int.Parse(ConfigurationManager.AppSettings["DangNhapToiDa"]!);
        int lockoutTime = int.Parse(ConfigurationManager.AppSettings["ThoiGianKhoaPhut"]!);
        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // import dummy from file
            availableUsers.Clear();

            using (StreamReader sr = new StreamReader(userDataFilePath))
            {
                string maTaiKhoan = "";
                string tenDangNhap = "";
                string matKhau = "";

                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if(line.StartsWith("MaTaiKhoan: "))
                    {
                        maTaiKhoan = line.Substring("MaTaiKhoan: ".Length);
                    }
                    else if (line.StartsWith("TenDangNhap: "))
                    {
                        tenDangNhap = line.Substring("TenDangNhap: ".Length);
                    }
                    else if (line.StartsWith("MatKhau: "))
                    {
                        matKhau = line.Substring("MatKhau: ".Length);
                    }
                    else if (line == "---") //File dummy phải kết thúc bằng "---"
                    {
                        availableUsers.Add(new User(maTaiKhoan, tenDangNhap, matKhau));
                        maTaiKhoan = "";
                        tenDangNhap = "";
                        matKhau = "";
                    }
                }
            }

            // auto-load remember login
            if(File.Exists(rememberLoginFilePath))
            {
                using (StreamReader sr = new StreamReader(rememberLoginFilePath))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("TenDangNhap: "))
                        {
                            txtUsername.Text = line.Substring("TenDangNhap: ".Length);
                        }
                        else if (line.StartsWith("MatKhau: "))
                        {
                            txtPassword.Text = line.Substring("MatKhau: ".Length);
                        }
                    }
                }
                //clear temp file manually if not want to remember login
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (failedLoginAttemptCount >= maxFailedLoginAttempts)
            {
                lblThongBaoLoi.ForeColor = System.Drawing.Color.Red;
                lblThongBaoLoi.Text = $"Bạn đã nhập sai quá {maxFailedLoginAttempts} lần, vui lòng thử lại sau!";
                return;
            }
            else
            {
                User tryingLogin = new User("NaN", txtUsername.Text, txtPassword.Text);
                bool logged = false;
                foreach (User user in availableUsers)
                {
                    if (user.TenDangNhap == tryingLogin.TenDangNhap && user.MatKhau == tryingLogin.MatKhau)
                    {
                        //reset failed attempt
                        failedLoginAttemptCount = 0;
                        logged = true;
                        // Open main form
                        frmMain mainForm = new frmMain(user.MaTaiKhoan);
                        mainForm.Show();
                        this.Hide();
                        return;
                    }
                }
                if(!logged)
                {
                    failedLoginAttemptCount++;
                }
                lblThongBaoLoi.ForeColor = System.Drawing.Color.Red;
                lblThongBaoLoi.Text = $"Tên đăng nhập hoặc mật khẩu không đúng | Còn {maxFailedLoginAttempts - failedLoginAttemptCount} lần thử";
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void chkGhiNho_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGhiNho.Checked)
            {
                // Save the username and password to a temporary file
                using (StreamWriter sw = new StreamWriter(rememberLoginFilePath))
                {
                    sw.WriteLine($"TenDangNhap: {txtUsername.Text}");
                    sw.WriteLine($"MatKhau: {txtPassword.Text}");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
