using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace QuanLyNhanSu.Services
{
    /// <summary>
    /// Quản lý tùy chỉnh giao diện (màu sắc, font chữ) và trạng thái "Ghi nhớ đăng nhập".
    /// Tất cả thiết lập được lưu trong Registry: HKEY_CURRENT_USER\Software\QuanLyNhanSu
    /// </summary>
    public static class TuyChinh
    {
        private const string DuongDanRegistry = @"Software\QuanLyNhanSu";

        private const string KhoaMauChinh = "MauChinh";
        private const string KhoaFontName = "FontName";
        private const string KhoaFontSize = "FontSize";
        private const string KhoaGhiNho = "GhiNhoDangNhap";
        private const string KhoaTenDangNhap = "TenDangNhapDaNho";

        /// <summary>Màu chủ đạo của giao diện (Flat Design).</summary>
        public static Color MauChinh { get; set; } = Color.FromArgb(45, 108, 223);

        /// <summary>Màu nền nhạt dùng cho các vùng nội dung.</summary>
        public static Color MauNen { get; set; } = Color.FromArgb(244, 246, 249);

        public static string TenFont { get; set; } = "Segoe UI";

        public static float CoFont { get; set; } = 9F;

        /// <summary>Trạng thái "Ghi nhớ đăng nhập" lưu trong Registry.</summary>
        public static bool GhiNhoDangNhap { get; set; }

        /// <summary>Tên đăng nhập đã ghi nhớ trong Registry.</summary>
        public static string TenDangNhapDaNho { get; set; } = "";

        public static Font FontGiaoDien
        {
            get { return new Font(TenFont, CoFont); }
        }

        public static Color MauDam
        {
            get { return ControlPaint.Dark(MauChinh, 0.25f); }
        }

        // ------------------------------------------------------------------
        // Registry
        // ------------------------------------------------------------------
        public static void Load()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(DuongDanRegistry))
                {
                    if (key == null)
                    {
                        return;
                    }

                    object mau = key.GetValue(KhoaMauChinh);
                    if (mau != null)
                    {
                        int argb;
                        if (int.TryParse(Convert.ToString(mau), out argb))
                        {
                            MauChinh = Color.FromArgb(argb);
                        }
                    }

                    object fn = key.GetValue(KhoaFontName);
                    if (fn != null && !string.IsNullOrWhiteSpace(Convert.ToString(fn)))
                    {
                        TenFont = Convert.ToString(fn);
                    }

                    object fs = key.GetValue(KhoaFontSize);
                    if (fs != null)
                    {
                        float size;
                        if (float.TryParse(Convert.ToString(fs), out size) && size >= 7F && size <= 24F)
                        {
                            CoFont = size;
                        }
                    }

                    GhiNhoDangNhap = Convert.ToString(key.GetValue(KhoaGhiNho)) == "1";
                    TenDangNhapDaNho = Convert.ToString(key.GetValue(KhoaTenDangNhap)) ?? "";
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi Registry, dùng giá trị mặc định
            }
        }

        public static void Save()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(DuongDanRegistry))
                {
                    if (key == null)
                    {
                        return;
                    }

                    key.SetValue(KhoaMauChinh, MauChinh.ToArgb().ToString());
                    key.SetValue(KhoaFontName, TenFont);
                    key.SetValue(KhoaFontSize, CoFont.ToString());
                    key.SetValue(KhoaGhiNho, GhiNhoDangNhap ? "1" : "0");
                    key.SetValue(KhoaTenDangNhap, TenDangNhapDaNho ?? "");
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi Registry
            }
        }

        // ------------------------------------------------------------------
        // Áp dụng giao diện
        // ------------------------------------------------------------------
        /// <summary>Áp dụng màu sắc / font chữ cho một Form và toàn bộ điều khiển con.</summary>
        public static void ApDung(Form form)
        {
            if (form == null)
            {
                return;
            }

            form.Font = FontGiaoDien;
            form.ForeColor = Color.FromArgb(51, 51, 51);

            ApDungDieuKhien(form);

            if (form.IsMdiContainer)
            {
                foreach (Control c in form.Controls)
                {
                    MdiClient client = c as MdiClient;
                    if (client != null)
                    {
                        client.BackColor = Color.FromArgb(226, 230, 236);
                    }
                }
            }
        }

        private static void ApDungDieuKhien(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                Button btn = c as Button;
                if (btn != null)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = MauChinh;
                    btn.ForeColor = Color.White;
                    btn.Cursor = Cursors.Hand;
                    btn.UseVisualStyleBackColor = false;
                }

                Label lbl = c as Label;
                if (lbl != null && lbl.ForeColor == Color.Empty)
                {
                    lbl.ForeColor = Color.FromArgb(51, 51, 51);
                }

                GroupBox grp = c as GroupBox;
                if (grp != null)
                {
                    grp.ForeColor = MauDam;
                }

                MenuStrip menu = c as MenuStrip;
                if (menu != null)
                {
                    menu.BackColor = MauChinh;
                    menu.ForeColor = Color.White;
                    menu.Renderer = new ToolStripProfessionalRenderer(new BoMauMenu());
                    ToMauMenuChinh(menu.Items);
                }

                StatusStrip status = c as StatusStrip;
                if (status != null)
                {
                    status.BackColor = MauDam;
                    status.ForeColor = Color.White;
                    status.SizingGrip = false;
                    foreach (ToolStripItem it in status.Items)
                    {
                        it.ForeColor = Color.White;
                    }
                }

                ApDungDieuKhien(c);
            }
        }

        /// <summary>Tô màu cho các mục menu cấp cao nhất (nền màu chủ đạo).</summary>
        private static void ToMauMenuChinh(ToolStripItemCollection items)
        {
            foreach (ToolStripItem it in items)
            {
                it.ForeColor = Color.White;
                ToolStripMenuItem mi = it as ToolStripMenuItem;
                if (mi != null)
                {
                    ToMauMenuCon(mi.DropDownItems);
                }
            }
        }

        /// <summary>Tô màu cho các mục menu bên trong (nền trắng).</summary>
        private static void ToMauMenuCon(ToolStripItemCollection items)
        {
            foreach (ToolStripItem it in items)
            {
                it.ForeColor = Color.FromArgb(51, 51, 51);
                ToolStripMenuItem mi = it as ToolStripMenuItem;
                if (mi != null)
                {
                    ToMauMenuCon(mi.DropDownItems);
                }
            }
        }

        /// <summary>Bảng màu cho menu theo màu chủ đạo.</summary>
        private class BoMauMenu : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return MauDam; }
            }

            public override Color MenuItemBorder
            {
                get { return MauDam; }
            }

            public override Color MenuStripGradientBegin
            {
                get { return MauChinh; }
            }

            public override Color MenuStripGradientEnd
            {
                get { return MauChinh; }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return Color.White; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return Color.White; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return Color.White; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return Color.White; }
            }
        }
    }
}
