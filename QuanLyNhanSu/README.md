# HỆ THỐNG QUẢN LÝ NHÂN SỰ — BẢN KHUNG GIAO DIỆN

> **Đây là bản "khung giao diện" để chia việc cho nhóm.**
> Toàn bộ giao diện (8 màn hình) đã được thiết kế bằng **Windows Forms Designer** và
> nằm nguyên trong các file `*.Designer.cs`. Phần **lập trình (code xử lý sự kiện) đã được
> để trống** — mỗi thành viên nhận màn hình nào thì mở file `.cs` tương ứng và điền code
> vào các hàm có ghi `// TODO:`.

Chương trình **vẫn build và chạy được** ngay (0 lỗi, 0 cảnh báo), chỉ là bấm nút chưa có gì xảy ra.

---

## 1. Mở và chạy

1. Mở file `QuanLyNhanSu.sln` bằng **Visual Studio 2022**.
2. Nhấn `F5` (hoặc `Ctrl + F5`) để chạy. Yêu cầu **.NET 9 SDK**.
3. Mặc định chương trình mở màn hình chính `frmMain`.

### Chạy nhanh 1 màn hình để lập trình / kiểm tra giao diện

Mỗi thành viên nên test riêng màn hình mình làm, không cần chờ các màn hình khác:

- **Trong Visual Studio:** chuột phải project `QuanLyNhanSu` → `Properties` → `Debug` →
  `Open debug launch profiles UI` → ô **Command line arguments**, gõ tên form, ví dụ: `frmEmployee`
- **Hoặc ở dòng lệnh:** `dotnet run -- frmEmployee`

Tên form hợp lệ: `frmLogin`, `frmMain`, `frmDashboard`, `frmEmployee`, `frmAttendance`,
`frmSalary`, `frmDepartment`, `frmPosition`.

---

## 2. Quy tắc làm việc với giao diện (quan trọng)

Mỗi màn hình gồm **3 file**, không được xóa file nào:

| File | Nội dung | Ai sửa |
|---|---|---|
| `frmX.Designer.cs` | Giao diện do Designer sinh ra (control, vị trí, màu, font...) | **Chỉ sửa bằng cách kéo–thả trong Designer**, không gõ tay vào file này |
| `frmX.resx` | Tài nguyên của form (VS tự quản lý) | Không sửa |
| `frmX.cs` | **Phần lập trình**: các hàm xử lý sự kiện (đang để trống) | Thành viên phụ trách điền code |

> ⚠️ **Không dựng thêm control bằng code** (không viết `new Label()`, `new Button()`,
> `Controls.Add(...)`). Cần thêm/sửa control thì mở form trong **Designer** rồi kéo–thả.
>
> ⚠️ Tên hàm trong `frmX.cs` **phải giữ đúng như Designer đang gán sự kiện** — xóa hoặc
> đổi tên là chương trình **không build được**.

Cách mở Designer: trong Solution Explorer bấm đúp vào `frmX.cs` (hoặc `frmX.Designer.cs`)
là VS mở giao diện để kéo–thả.

**Riêng `frmLogin.Designer.cs`** có dùng logo từ `Properties/Resources.resx` (ảnh `ảnh_icon`)
→ **không xóa thư mục `Properties/`**, nếu không sẽ lỗi build.

---

## 3. Chia việc theo yêu cầu của bài

| Yêu cầu | Màn hình | File cần lập trình | Số hàm cần làm |
|---|---|---|---|
| Đăng nhập + ghi nhớ + khóa sau 3 lần sai | `frmLogin` | `Forms/frmLogin.cs` | 6 |
| Màn hình chính MDI + menu + đồng hồ + đổi màu/font + sao lưu | `frmMain` | `Forms/frmMain.cs` | 20 |
| Bảng điều khiển (thống kê + sinh nhật trong tháng) | `frmDashboard` | `Forms/frmDashboard.cs` | 1 |
| **Yêu cầu 1 — Hồ sơ nhân viên** (cây tổ chức, ảnh, tìm kiếm, kiểm tra dữ liệu) | `frmEmployee` | `Forms/frmEmployee.cs` | 14 |
| **Yêu cầu 2 — Chấm công** (chặn ngày tương lai, menu trạng thái, nhập CSV) | `frmAttendance` | `Forms/frmAttendance.cs` | 17 |
| **Yêu cầu 3 — Tính lương** (tính lương, xuất CSV/TXT) | `frmSalary` | `Forms/frmSalary.cs` | 8 |
| Danh mục phòng ban | `frmDepartment` | `Forms/frmDepartment.cs` | 8 |
| Danh mục chức vụ | `frmPosition` | `Forms/frmPosition.cs` | 8 |

Mỗi file `.cs` đã ghi rõ từng hàm cần làm việc gì ở dòng `// TODO:`.

---

## 4. Tầng dữ liệu (cả nhóm tự tạo)

Bản này **đã xóa** các thư mục `Models/`, `Data/`, `Services/` để nhóm tự làm. Gợi ý cấu trúc
chung (nên thống nhất trước khi chia việc):

```
Models/NhanVien.cs      MaNV, HoTen, GioiTinh, NgaySinh, DienThoai, Email, DiaChi,
                        MaPhong, MaChucVu, HeSoLuong, LuongCoBan, NgayVaoLam,
                        TrangThai, PhepNam, Anh (chuỗi Base64)
Models/PhongBan.cs      MaPhong, TenPhong, MoTa
Models/ChucVu.cs        MaChucVu, TenChucVu, HeSoLuong
Models/ChamCong.cs      MaNV, Ngay, TrangThai, SoPhutTre, SoGioTangCa
Models/TaiKhoan.cs      TenDangNhap, MatKhau, VaiTro
Data/DataStore.cs       Đọc/ghi danh sách trên ra file JSON và nạp dữ liệu mẫu lần đầu
Services/...            Các hàm dùng chung: tính lương, tìm kiếm, xử lý ảnh, đọc App.config
```

Gợi ý lưu dữ liệu: đối tượng → **JSON** (`System.Text.Json`) tại
`%AppData%\QuanLyNhanSu\data.json`; ảnh nhân viên lưu dạng **chuỗi Base64**.

Tài khoản mẫu: `admin / admin123` (Quản trị), `nv01 / 123456`, `nv02 / 123456`.

---

## 5. Tham số nghiệp vụ trong `App.config`

| Khóa | Giá trị | Ý nghĩa |
|---|---|---|
| `TenDonVi` | CÔNG TY TNHH GIẢI PHÁP ABC | Tên đơn vị in trên phiếu lương |
| `NgayCongChuan` | 26 | Số ngày công chuẩn trong tháng |
| `MucTruDiTre` | 100000 | Số tiền trừ cho mỗi lần đi trễ (VNĐ) |
| `HeSoTangCa` | 1.5 | Hệ số tiền tăng ca |
| `SoGioLamChuan` | 8 | Số giờ làm việc chuẩn 1 ngày |

Đọc bằng `ConfigurationManager.AppSettings["TênKhóa"]`.

**Công thức tính lương gợi ý:**

```
Lương ngày       = Lương cơ bản / NgayCongChuan
Lương theo công  = Lương ngày * số ngày công thực tế
Trừ đi trễ       = số lần đi trễ * MucTruDiTre
Tiền tăng ca     = (Lương ngày / SoGioLamChuan) * số giờ tăng ca * HeSoTangCa
Thực lĩnh        = Lương theo công - Trừ đi trễ + Tiền tăng ca
```

---

## 6. Ghi chú kỹ thuật

- Target framework: `net9.0-windows`, `UseWindowsForms = true`.
- Ngôn ngữ/định dạng ngày giờ được đặt theo `vi-VN` trong `Program.cs`.
- `Program.cs` có sẵn phần chạy nhanh một màn hình khi lập trình (xem mục 1) và chỗ để
  bật lại luồng đăng nhập khi `frmLogin` đã làm xong.
- Màu nền / font giao diện lưu trong Registry tại `HKCU\Software\QuanLyNhanSu`.
- **Bản chạy hoàn chỉnh trước đây** (đã có đủ code) vẫn nằm trong lịch sử Git. Muốn xem lại:

  ```bash
  git log --oneline          # tìm commit cũ
  git show <mã-commit> --stat
  git checkout <mã-commit> -- QuanLyNhanSu   # lấy lại toàn bộ code cũ
  ```
