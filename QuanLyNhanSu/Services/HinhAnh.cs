using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace QuanLyNhanSu.Services
{
    /// <summary>Tiện ích xử lý hình ảnh (ảnh nhân viên, logo phần mềm).</summary>
    public static class HinhAnh
    {
        /// <summary>Chuyển ảnh sang chuỗi Base64 để lưu cùng hồ sơ.</summary>
        public static string SangBase64(Image anh)
        {
            if (anh == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                anh.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>Tạo ảnh từ chuỗi Base64 (trả về null nếu dữ liệu rỗng/sai).</summary>
        public static Image TuBase64(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
            {
                return null;
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (Image goc = Image.FromStream(ms))
                    {
                        return new Bitmap(goc);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>Bo tròn 4 góc cho một điều khiển (PictureBox...).</summary>
        public static void BoTron(Control c, int banKinh)
        {
            if (c == null || c.Width <= 0 || c.Height <= 0)
            {
                return;
            }

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle r = new Rectangle(0, 0, c.Width, c.Height);
                int d = banKinh * 2;
                path.AddArc(r.X, r.Y, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                c.Region = new Region(path);
            }
        }

        /// <summary>Tạo ảnh logo đơn giản (không cần tập tin tài nguyên).</summary>
        public static Bitmap TaoLogo(int rong, int cao, Color mau)
        {
            Bitmap bmp = new Bitmap(rong, cao);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                int r = Math.Min(rong, cao) / 2 - 6;
                int cx = rong / 2;
                int cy = cao / 2;

                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, cx - r, cy - r, r * 2, r * 2);
                }

                using (SolidBrush brush = new SolidBrush(mau))
                {
                    int rr = r - 8;
                    g.FillEllipse(brush, cx - rr, cy - rr, rr * 2, rr * 2);
                }

                // Biểu tượng người đơn giản ở giữa vòng tròn
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    int dauR = Math.Max(4, r / 3);
                    g.FillEllipse(brush, cx - dauR / 2, cy - dauR, dauR, dauR);
                    using (GraphicsPath than = new GraphicsPath())
                    {
                        than.AddArc(cx - dauR, cy - dauR, dauR * 2, dauR * 2, 180, 180);
                        than.CloseFigure();
                        g.FillPath(brush, than);
                    }
                }
            }

            return bmp;
        }

        /// <summary>Tạo ảnh đại diện mặc định có chữ viết tắt của họ tên.</summary>
        public static Bitmap TaoAnhDaiDien(string hoTen, Color mau, int kichThuoc)
        {
            Bitmap bmp = new Bitmap(kichThuoc, kichThuoc);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.WhiteSmoke);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(60, mau)))
                {
                    g.FillRectangle(brush, 0, 0, kichThuoc, kichThuoc);
                }

                string chu = LayChuVietTat(hoTen);
                using (Font f = new Font("Segoe UI", kichThuoc / 3F, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    SizeF size = g.MeasureString(chu, f);
                    g.DrawString(chu, f, brush,
                        (kichThuoc - size.Width) / 2, (kichThuoc - size.Height) / 2);
                }
            }

            return bmp;
        }

        private static string LayChuVietTat(string hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                return "?";
            }

            string[] tu = hoTen.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (tu.Length == 0)
            {
                return "?";
            }

            if (tu.Length == 1)
            {
                return tu[0].Substring(0, 1).ToUpper();
            }

            return (tu[0].Substring(0, 1) + tu[tu.Length - 1].Substring(0, 1)).ToUpper();
        }

        /// <summary>Thu nhỏ / mở rộng ảnh vừa khung để hiển thị đẹp hơn.</summary>
        public static Image VuaKhung(Image anh, Size khung)
        {
            if (anh == null || khung.Width <= 0 || khung.Height <= 0)
            {
                return anh;
            }

            double tl = Math.Min((double)khung.Width / anh.Width, (double)khung.Height / anh.Height);
            int w = Math.Max(1, (int)(anh.Width * tl));
            int h = Math.Max(1, (int)(anh.Height * tl));

            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(anh, 0, 0, w, h);
            }

            return bmp;
        }
    }
}
