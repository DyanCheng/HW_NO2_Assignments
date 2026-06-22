# Exer6 — Quản lý sinh viên

## Chủ đề đã chọn

**Quản lý sinh viên** — ứng dụng web ASP.NET MVC cho phép thêm, xem, sửa và xóa thông tin sinh viên (Id, Name, Email, Phone).

Dữ liệu lưu tạm trong `List<Student>` trong `StudentController`, chưa sử dụng database.

## Chức năng chính

| Chức năng | URL | Mô tả |
|-----------|-----|--------|
| Danh sách | `/Student` | Hiển thị bảng sinh viên, link Chi tiết / Sửa / Xóa |
| Chi tiết | `/Student/Detail/{id}` | Xem đầy đủ thông tin một sinh viên |
| Thêm mới | `/Student/Create` | Form GET/POST, có validation |
| Sửa | `/Student/Edit/{id}` | Form chỉnh sửa, có validation |
| Xóa | `/Student/Delete/{id}` | Trang xác nhận trước khi xóa |

Sau thêm / sửa / xóa thành công, hệ thống redirect về danh sách và hiển thị thông báo qua `TempData`.

## Cấu trúc liên quan

```
Models/Student.cs              — Model + Data Annotations
Controllers/StudentController.cs — CRUD actions
Views/Student/                 — Index, Detail, Create, Edit, Delete
Views/Shared/_Layout.cshtml    — Layout chung (Header, Menu, Footer)
```

## Chạy project

```bash
cd Exer6/src
dotnet run
```

Mở trình duyệt tại `http://localhost:5016`.
