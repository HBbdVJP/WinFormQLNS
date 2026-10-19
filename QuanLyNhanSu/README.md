# HỆ THỐNG QUẢN LÝ NHÂN SỰ

Bài báo cáo môn **Lập trình Windows Form** — ứng dụng WinForms (.NET 9) quản lý nhân sự,
chấm công và tính lương.

## 1. Cách mở và chạy

1. Mở tập tin **`QuanLyNhanSu.sln`** bằng **Visual Studio 2022** (bản 17.12 trở lên).
2. Chọn cấu hình `Debug` — `Any CPU`, nhấn **F5** để chạy.
3. Yêu cầu máy đã cài **.NET SDK 9** (`dotnet --list-sdks`).

Chạy bằng dòng lệnh:

```
dotnet build
dotnet run --project QuanLyNhanSu
```

> Toàn bộ giao diện được thiết kế bằng **Windows Forms Designer** (các tập tin
> `*.Designer.cs`). Có thể mở từng form trong VS rồi kéo/thả, chỉnh sửa trực tiếp.

## 2. Tài khoản dùng thử

| Tên đăng nhập | Mật khẩu | Vai trò |
|---|---|---|
| `admin` | `admin123` | Quản trị (toàn quyền) |
| `nv01`  | `123456`   | Nhân viên |
| `nv02`  | `123456`   | Nhân viên |

- Nhập sai 3 lần sẽ bị **khoá đăng nhập** trong 60 giây.
- Tùy chọn **Ghi nhớ đăng nhập** lưu tên đăng nhập vào Registry
  `HKEY_CURRENT_USER\Software\QuanLyNhanSu` (mật khẩu không lưu).
- Vai trò *Nhân viên* bị vô hiệu hoá các chức năng: Quản lý phòng ban, chức vụ,
  sao lưu và phục hồi dữ liệu.

## 3. Chức năng chính

### Yêu cầu 1 — Hồ sơ nhân viên (frmEmployee)
- Sơ đồ tổ chức dạng **TreeView** (Công ty → Phòng ban → Nhân viên), chọn nút để lọc.
- Lọc theo phòng ban, tìm kiếm theo tên / mã nhân viên.
- Thông tin chi tiết: mã, họ tên, giới tính, ngày sinh, điện thoại, email, địa chỉ,
  phòng ban, chức vụ, ngày vào làm, lương cơ bản, phép năm, trạng thái.
- Ảnh nhân viên: **Đổi ảnh…** / **Xóa ảnh** (ảnh lưu kèm trong dữ liệu).
- Danh sách dạng **ListView**, các nút **Thêm / Sửa / Xóa / Lưu / Hủy / Làm mới**.
- Kiểm tra dữ liệu: ô sai được **báo đỏ**, có **tooltip** giải thích và tự focus vào ô lỗi
  (ví dụ: *Mã nhân viên không được để trống*, *Ngày sinh phải nhỏ hơn ngày hiện tại*).

### Yêu cầu 2 — Chấm công hằng ngày (frmAttendance)
- Chọn ngày chấm công (**DatePicker không cho chọn ngày tương lai**), lọc theo phòng ban.
- **Nhập từ CSV…** để nạp bảng chấm công từ tập tin.
- Danh sách có **CheckBox** (chọn nhân viên có mặt), nút **Chọn tất cả / Bỏ chọn tất cả**.
- **Nhấn chuột phải** vào danh sách để đổi trạng thái: Đi làm, Đi trễ, Nghỉ phép,
  Nghỉ không phép và nhập số giờ tăng ca.
- **Lưu bảng công** để ghi lại bảng chấm công của ngày đang chọn.

### Yêu cầu 3 — Tính lương và phiếu lương (frmSalary)
- Lọc theo **tháng / năm / phòng ban**, nhấn **Tính lương**.
- Bảng lương: Mã NV, Tên NV, Lương cơ bản, Ngày làm thực tế, Số lần đi trễ,
  Số giờ tăng ca, Phép năm còn lại, **TỔNG LƯƠNG**.
- **Xuất Bảng Lương (CSV)** mở hộp thoại lưu tập tin (UTF-8, mở được bằng Excel).
- **Xuất Phiếu Lương (TXT)** cho nhân viên đang chọn (phiếu lương in dạng văn bản).

### Tiện ích khác (frmMain)
- Menu **Hệ thống**: Sao lưu dữ liệu, Phục hồi dữ liệu, Đổi màu giao diện,
  Đổi font chữ, Đăng xuất, Thoát.
- Menu **Quản lý**: Hồ sơ nhân viên, Phòng ban, Chức vụ.
- Menu **Nghiệp vụ**: Chấm công hằng ngày, Tính lương và phiếu lương.
- Dashboard: thống kê số nhân viên / phòng ban / chức vụ và **danh sách sinh nhật**
  trong tháng, nhấp đúp một dòng để mở hồ sơ nhân viên.
- Thanh trạng thái: người dùng, vai trò và **đồng hồ cập nhật mỗi giây**.

Phím tắt: `Ctrl+H` hồ sơ nhân viên, `Ctrl+M` chấm công, `Ctrl+L` tính lương,
`Ctrl+D` dashboard, `Ctrl+Shift+P` phòng ban, `Ctrl+Shift+C` chức vụ.

## 4. Tham số nghiệp vụ (App.config)

| Khoá | Ý nghĩa | Giá trị |
|---|---|---|
| `TenDonVi` | Tên đơn vị hiển thị trên tiêu đề và phiếu lương | CÔNG TY TNHH GIẢI PHÁP ABC |
| `NgayCongChuan` | Số ngày công chuẩn trong tháng | 26 |
| `MucTruDiTre` | Số tiền trừ cho mỗi lần đi trễ (VNĐ) | 100000 |
| `HeSoTangCa` | Hệ số tiền tăng ca | 1.5 |
| `SoGioLamChuan` | Số giờ làm việc chuẩn mỗi ngày | 8 |

Công thức: lương theo ngày công = lương cơ bản / `NgayCongChuan` × ngày làm thực tế;
tiền tăng ca = lương cơ bản / (`NgayCongChuan` × `SoGioLamChuan`) × `HeSoTangCa` × giờ tăng ca;
trừ đi trễ = số lần đi trễ × `MucTruDiTre`.

## 5. Nơi lưu dữ liệu

- Dữ liệu: `%AppData%\QuanLyNhanSu\data.json` (JSON, gồm phòng ban, chức vụ, nhân viên,
  tài khoản, chấm công và ảnh nhân viên dạng base64). Lần chạy đầu sẽ tự sinh dữ liệu mẫu.
- Tùy chỉnh giao diện & ghi nhớ đăng nhập: Registry `HKCU\Software\QuanLyNhanSu`.

## 6. Cấu trúc thư mục

```
QuanLyNhanSu/
├─ Program.cs                 điểm khởi động, cấu hình văn hoá vi-VN
├─ App.config                 tham số nghiệp vụ
├─ Models/                    Enums, PhongBan, ChucVu, NhanVien, ChamCong, TaiKhoan
├─ Data/DataStore.cs          đọc/ghi dữ liệu JSON + dữ liệu mẫu
├─ Services/
│   ├─ CauHinh.cs             đọc App.config
│   ├─ PhienLamViec.cs        người dùng đang đăng nhập
│   ├─ TuyChinh.cs            màu/font giao diện + Registry
│   ├─ HinhAnh.cs             xử lý ảnh (bo góc, base64, logo)
│   ├─ NghiepVu.cs            tính lương, sinh nhật, tra cứu
│   └─ CotDanhSach.cs         giãn độ rộng cột ListView theo DPI
└─ Forms/                     frmLogin, frmMain, frmDashboard, frmEmployee,
                              frmAttendance, frmSalary, frmDepartment, frmPosition
                              (mỗi form gồm .cs và .Designer.cs)
```
