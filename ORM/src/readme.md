# ORM — Quản lý sách (ASP.NET MVC + EF Core + Supabase)

## Mô tả

Ứng dụng web ASP.NET MVC thực hiện CRUD bảng **Book** (Id, Name, Price) trên **Supabase PostgreSQL**, sử dụng **Entity Framework Core** (kỹ thuật ORM) thay cho ADO.NET trong mẫu `BookRepository.cs`.

## Cấu trúc liên quan

```
Models/Book.cs              — Model + Data Annotations
Data/BookDbContext.cs       — DbContext (ánh xạ bảng Book)
Data/BookRepository.cs      — CRUD qua EF Core (ORM)
Controllers/BookController.cs — MVC actions
Views/Book/                 — Index, Detail, Create, Edit, Delete
Scripts/create_book_table.sql — Tạo bảng Book trên Supabase
```

## Thiết lập Supabase

1. Vào [Supabase Dashboard](https://supabase.com/dashboard) → mở project **test**.
2. Nếu project đang **Paused**, bấm **Restore** (cần slot project còn trống trong gói free).
3. Vào **Project Settings → Database**, copy **Database password**.
4. Vào **SQL Editor**, chạy nội dung file `Scripts/create_book_table.sql`.
5. Cập nhật mật khẩu trong `appsettings.Development.json`:

```json
"BookManagement": "Host=db.eoeqtjprmgppivqdaylm.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=<MAT_KHAU_CUA_BAN>;SSL Mode=Require;Trust Server Certificate=true"
```

## Chức năng CRUD

| Chức năng | URL | Mô tả |
|-----------|-----|--------|
| Danh sách | `/Book` | Hiển thị bảng sách |
| Chi tiết | `/Book/Detail/{id}` | Xem một sách |
| Thêm mới | `/Book/Create` | Form thêm sách |
| Sửa | `/Book/Edit/{id}` | Form chỉnh sửa |
| Xóa | `/Book/Delete/{id}` | Xác nhận trước khi xóa |

## Chạy project

```bash
cd ORM/src
dotnet run
```

Mở trình duyệt tại `http://localhost:5190`.

## So sánh với mẫu ADO.NET

Mẫu gốc dùng `SqlConnection`, `SqlCommand`, `SqlDataReader`. Project này dùng:

- `BookDbContext` + `DbSet<Book>` để ánh xạ object ↔ bảng
- LINQ / `SaveChanges()` thay cho câu lệnh SQL thủ công
- `BookRepository` giữ nguyên interface CRUD: `GetAll`, `GetById`, `Add`, `Update`, `Delete`
