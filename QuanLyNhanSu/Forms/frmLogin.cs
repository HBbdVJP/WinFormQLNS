using System;
using System.Windows.Forms;
using System.IO;
using QuanLyNhanSu.Classes;
using System.Configuration;

namespace QuanLyNhanSu.Forms
{
    public partial class frmLogin : Form
    {
        public bool rememberLogin = false;
        public frmLogin()
        {
            InitializeComponent();
            timerKhoa.Tick += timerKhoa_Tick;
        }
        List<User> availableUsers = new List<User>();

        string rememberLoginFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "RememberLogin", "GhiNhoDangNhapTemp.txt");
        string userDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "DummyData", "User.txt");
        int failedLoginAttemptCount = 0;
        int maxFailedLoginAttempts = int.Parse(ConfigurationManager.AppSettings["DangNhapToiDa"]!);
        int lockoutTime = int.Parse(ConfigurationManager.AppSettings["ThoiGianKhoaPhut"]!);
        private DateTime? lockoutUntil;

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
            if (DangBiKhoa())
            {
                return;
            }

            User tryingLogin = new User("NaN", txtUsername.Text, txtPassword.Text);
            bool logged = false;
            foreach (User user in availableUsers)
            {
                if (user.TenDangNhap == tryingLogin.TenDangNhap && user.MatKhau == tryingLogin.MatKhau)
                {
                    if (rememberLogin)
                    {
                        // Save the username and password to a temporary file
                        using (StreamWriter sw = new StreamWriter(rememberLoginFilePath, false))
                        {
                            sw.WriteLine($"TenDangNhap: {txtUsername.Text}");
                            sw.WriteLine($"MatKhau: {txtPassword.Text}");
                        }
                    }
                    failedLoginAttemptCount = 0;
                    logged = true;
                    frmMain mainForm = new frmMain(user.MaTaiKhoan);
                    mainForm.Show();
                    this.Hide();
                    return;
                }
            }

            if (!logged)
            {
                failedLoginAttemptCount++;
            }

            if (failedLoginAttemptCount >= maxFailedLoginAttempts)
            {
                BatDauKhoa();
                return;
            }

            lblThongBaoLoi.ForeColor = System.Drawing.Color.Red;
            lblThongBaoLoi.Text = $"Tên đăng nhập hoặc mật khẩu không đúng | Còn {maxFailedLoginAttempts - failedLoginAttemptCount} lần thử";
        }

        private bool DangBiKhoa()
        {
            if (!lockoutUntil.HasValue)
            {
                return false;
            }

            if (DateTime.Now >= lockoutUntil.Value)
            {
                HetKhoa();
                return false;
            }

            CapNhatThongBaoKhoa();
            return true;
        }

        private void BatDauKhoa()
        {
            lockoutUntil = DateTime.Now.AddMinutes(Math.Max(0, lockoutTime));
            btnDangNhap.Enabled = false;
            timerKhoa.Start();
            CapNhatThongBaoKhoa();
        }

        private void timerKhoa_Tick(object? sender, EventArgs e)
        {
            if (!lockoutUntil.HasValue || DateTime.Now >= lockoutUntil.Value)
            {
                HetKhoa();
                return;
            }

            CapNhatThongBaoKhoa();
        }

        private void CapNhatThongBaoKhoa()
        {
            if (!lockoutUntil.HasValue)
            {
                return;
            }

            TimeSpan conLai = lockoutUntil.Value - DateTime.Now;
            int tongGiay = Math.Max(0, (int)Math.Ceiling(conLai.TotalSeconds));
            lblThongBaoLoi.ForeColor = System.Drawing.Color.Red;
            lblThongBaoLoi.Text = $"Tài khoản bị khóa, thử lại sau {tongGiay / 60:00}:{tongGiay % 60:00}";
        }

        private void HetKhoa()
        {
            lockoutUntil = null;
            failedLoginAttemptCount = 0;
            btnDangNhap.Enabled = true;
            timerKhoa.Stop();
            lblThongBaoLoi.Text = "Bạn có thể đăng nhập lại.";
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void chkGhiNho_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGhiNho.Checked)
            {
                rememberLogin = true;
            }
            else
            {
                rememberLogin = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
