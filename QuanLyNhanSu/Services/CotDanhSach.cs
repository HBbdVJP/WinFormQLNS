using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyNhanSu.Services
{
    /// <summary>
    /// Tiện ích cho ListView.
    /// ListView (chế độ Details) không tự giãn độ rộng cột theo DPI / cỡ chữ,
    /// nên trên màn hình có tỷ lệ hiển thị lớn (125%, 150%, 225%...) tiêu đề cột
    /// thường bị cắt chữ. Hàm <see cref="VuaTieuDe"/> đo lại tiêu đề theo font
    /// đang dùng và chỉ nới rộng cột khi cần (không bao giờ thu hẹp cột).
    /// </summary>
    public static class CotDanhSach
    {
        private const int LVM_GETCOLUMNWIDTH = 0x101D;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Nới rộng các cột của ListView sao cho tiêu đề không bị cắt chữ.
        /// Gọi sau khi form đã tạo handle (trong sự kiện Load).
        /// </summary>
        public static void VuaTieuDe(ListView lv)
        {
            if (lv == null || !lv.IsHandleCreated || lv.Columns.Count == 0)
            {
                return;
            }

            lv.BeginUpdate();
            try
            {
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    ColumnHeader cot = lv.Columns[i];

                    // Độ rộng tối thiểu để tiêu đề không bị cắt
                    int rongTieuDe = TextRenderer.MeasureText(cot.Text, lv.Font).Width + 26;

                    // Nới thêm cho vừa dữ liệu (tối đa gấp đôi tiêu đề để không quá rộng)
                    int rongNoiDung = 0;
                    foreach (ListViewItem item in lv.Items)
                    {
                        if (i < item.SubItems.Count)
                        {
                            int rong = TextRenderer.MeasureText(item.SubItems[i].Text, lv.Font).Width + 26;
                            if (rong > rongNoiDung)
                            {
                                rongNoiDung = rong;
                            }
                        }
                    }

                    int rongCanThiet = Math.Min(Math.Max(rongTieuDe, rongNoiDung), rongTieuDe * 2);
                    int rongHienTai = (int)SendMessage(lv.Handle, LVM_GETCOLUMNWIDTH, (IntPtr)i, IntPtr.Zero);

                    if (rongHienTai < rongCanThiet)
                    {
                        cot.Width = rongCanThiet;
                    }
                }
            }
            finally
            {
                lv.EndUpdate();
            }
        }
    }
}
