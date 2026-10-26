# HỆ THỐNG QUẢN LÝ NHÂN SỰ

## 1. Mở và chạy
Hiện đang lỗi chữ ký ứng dụng nên nhớ tắt window security -> smart app control -> off rồi chạy nếu cần thiết.

Chạy xong bật lại là được

---
## 2. Trong đây có gì?
App Winform Quản lý nhân sự là trình quản lý nhân sự có các chức năng quản lý nhân sự cơ bản.

### 2.A. Scope
- Có RBAC cơ bản ở Login(phân quyền khả năng CRUD cho các frm như Thông tin nhân viên các thứ)
- Nạp dữ liệu bằng thư viện IO dùng StreamReader. Lưu dữ liệu thành file txt, csv bằng StreamWriter
    + Có thể bỏ qua dữ liệu lỗi mà không crash app
- Xem danh sách nhân viên theo TreeView, CUD Nhân viên tùy RBAC
    + Danh sách nhân viên có sort theo phòng ban và search theo tên, filter theo property
    + TreeView nên không có pagination
- Xem chấm công và chấm công tùy RBAC. Thao tác RBAC admin chỉnh được đi trễ <-> nghỉ phép
    + Quản lý nghỉ phép năm(có lương)
- Xem lương và tính lương tùy RBAC.
    + OT hệ số 1.5x <- magic number
- Xem sinh nhật nhân viên
- RBAC có guard khóa acc khi sai 3 lần liên tiếp hay đại loại
- Test case tối thiểu 15 trường hợp

### 2.B. Công nghệ
.NET Core 9.0. chứ còn muốn công nghệ gì nữa?

---

## 3. Phân công công việc
chứ để 1 người gánh thì hơi kỳ cục

### 3.A. Nhóm này có ai?
Đoàn Văn Bảo Minh - Thiết kế UI/UX Window Form

Đỗ Nguyễn Trần Hoài Bắc - Làm logic backend

Nguyễn Đức Sao Biển - Làm logic backend và BA

### 3.B. Ai làm những gì?
Theo Scope ở mục 2.A, đây là bảng phân công:

Sao Biển:
- Thiết kế Flowchart, Usecase, Activity Node, và Class Diagram
- Thực hiện logic phần sau của dự án gồm
    + Chấm công(có RBAC)
    + Tính lương(có RBAC)
- Phân chia và kiểm soát tiến độ làm việc của nhóm

Bảo Minh:
- Thiết kế Các Form theo phân tích của BA
- Gán các giá trị và thuộc tính ban đầu cho các Toolbox Item
- Tạo lập DummyData ban đầu cho Testcase

Hoài Bắc:
- Thực hiện logic phần form login và main để xem hồ sơ nhân viên các thứ
- Thực hiện logic phần cuối là xem sinh nhật và quản lý nghỉ phép năm(có tính lương)
- Thực hiện QA/QC/Testing:
    + Kiểm tra và nâng cấp/hoàn thiện dummydata(nếu cần)
    + Kiểm thử các chức năng trong Scope và ngoài Scope của App, check các vulnerability và mò bug để fix

TODO: Cần thêm Definition of Done để scale, mục 3.C đang hơi không có benchmark

### 3.C. Làm đến đâu rồi?
Bảo Minh:
- Thiết kế xong các Form UI hoàn chỉnh
- Gắn giá trị phù hợp
- Đã có một lượng dummydata tương đối

tiến độ: hoàn thành 92%

Hoài Bắc:
- xong login và gần xong main

tiến độ: hoàn thành 35% 

Sao Biển:
- Đã có thiết kế

tiến độ: hoàn thành 20%

---

## 4. Giải thích cấu trúc thư mục dự án
ai đó hoàn thành cái docs này với làm ơn, tôi quá lười

### 4.A. Các directory chứa gì?
Classes/ chứa các lớp

Forms/ chứa các form

Resources/ chứa dummydata text và image và cả temp như remember login

TODO: chộ 4.A này cần giải thích chi tiết hơn

### 4.B. Những gì cần làm trong các directory
TODO: tôi không biết phải ghi gì vào đây nữa

### 4.C. Tham số nghiệp vụ trong `App.config`

| Khóa | Giá trị | Ý nghĩa |
|---|---|---|
| `TenDonVi` | CÔNG TY TNHH GIẢI PHÁP ABC | Tên đơn vị in trên phiếu lương |
| `NgayCongChuan` | 26 | Số ngày công chuẩn trong tháng |
| `MucTruDiTre` | 100000 | Số tiền trừ cho mỗi lần đi trễ (VNĐ) |
| `HeSoTangCa` | 1.5 | Hệ số tiền tăng ca |
| `SoGioLamChuan` | 8 | Số giờ làm việc chuẩn 1 ngày |

Đọc bằng `ConfigurationManager.AppSettings["TênKhóa"]`.

**Công thức tính lương:**

```
Lương ngày       = Lương cơ bản / NgayCongChuan
Lương theo công  = Lương ngày * số ngày công thực tế
Trừ đi trễ       = số lần đi trễ * MucTruDiTre
Tiền tăng ca     = (Lương ngày / SoGioLamChuan) * số giờ tăng ca * HeSoTangCa
Thực lĩnh        = Lương theo công - Trừ đi trễ + Tiền tăng ca
```


Note: Biển ơi m làm CHấm công xong m chỉnh trong employee cái nudPhepNam cho t

Note 2: Cần sửa frm Main gọi frm MDI child đang lỗi tắt đi không bật lại được