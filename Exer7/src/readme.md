# Exer7 — Upload hình sản phẩm (ASP.NET MVC)

## Mô tả

Ứng dụng web ASP.NET MVC quản lý **sách/sản phẩm** với chức năng upload **một hoặc nhiều ảnh** (jpg/png) khi thêm hoặc sửa.

Dữ liệu lưu tạm trong `List<Book>` trong `BookController`, ảnh lưu tại `wwwroot/uploads/books/`.

## Upload ảnh

| Điều kiện | Kết quả |
|-----------|---------|
| jpg/png | Cho upload |
| File khác | Báo lỗi: *Chỉ cho phép upload file jpg/png* |

## Hiển thị danh sách

Danh sách sách (`/Book`) hiển thị:

- **Tên**
- **Giá**
- **Hình ảnh** (thumbnail)

## Chức năng chính

| Chức năng | URL | Mô tả |
|-----------|-----|--------|
| Danh sách | `/Book` | Tên, giá, hình ảnh |
| Chi tiết | `/Book/Detail/{id}` | Xem đầy đủ thông tin và ảnh |
| Thêm mới | `/Book/Create` | Form + upload ảnh |
| Sửa | `/Book/Edit/{id}` | Cập nhật + thêm ảnh |
| Xóa | `/Book/Delete/{id}` | Xác nhận trước khi xóa |

## Cấu trúc liên quan

```
Models/Book.cs                   — Model + ImagePaths
Services/ImageUploadService.cs   — Kiểm tra jpg/png, lưu file
Controllers/BookController.cs    — CRUD + xử lý upload
Views/Book/                      — Index, Detail, Create, Edit, Delete
wwwroot/uploads/books/           — Thư mục lưu ảnh upload
```

## Chạy project

```bash
cd Exer7/src
dotnet run
```

Mở trình duyệt tại `http://localhost:5017`.
