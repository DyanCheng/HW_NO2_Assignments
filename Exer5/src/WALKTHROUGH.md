# Walkthrough - Bai 4, 5, 6

## 1) Bai 4 - Form Submit co ban (GET/POST)

Da tao `AccountController` voi 2 action:

- `GET /Account/Login`: hien thi form dang nhap
- `POST /Account/Login`: nhan du lieu tu form qua model binding (`LoginViewModel`)

Logic xu ly:

- `admin / 123` => hien thi `Login success`
- Gia tri khac => hien thi `Login failed`

File lien quan:

- `Controllers/AccountController.cs`
- `Models/LoginViewModel.cs`
- `Views/Account/Login.cshtml`

## 2) Bai 5 - Mini Project Quan ly sach

Da tao `BookController` va cac chuc nang:

### a) Danh sach sach

- Action: `Index()`
- URL: `/Book/Index`
- Hien thi danh sach 3 sach mau:
  - 1 - Clean Code - 20
  - 2 - ASP.NET MVC - 15
  - 3 - Design Pattern - 25

### b) Chi tiet sach

- Action: `Detail(int id)`
- Vi du URL: `/Book/Detail/1`
- Hien thi day du `Id`, `Name`, `Price`

### c) Them sach

- Action GET: `Create()` hien thi form nhap ten sach va gia
- Action POST: `Create(Book model)` xu ly submit
- Sau khi them thanh cong, hien thi thong bao: `Them sach thanh cong`

File lien quan:

- `Controllers/BookController.cs`
- `Models/Book.cs`
- `Views/Book/Index.cshtml`
- `Views/Book/Detail.cshtml`
- `Views/Book/Create.cshtml`

## 3) Bai 6 - Validation co ban

Validation duoc ap dung trong form them sach:

- Ten rong => `Khong duoc de trong`
- Gia <= 0 => `Gia phai lon hon 0`

Ky thuat da dung:

- Data Annotation trong `Book` model:
  - `[Required(ErrorMessage = "Khong duoc de trong")]`
  - `[Range(0.01, double.MaxValue, ErrorMessage = "Gia phai lon hon 0")]`
- Kiem tra `ModelState.IsValid` trong action POST `BookController.Create`
- Hien thi loi trong view bang `asp-validation-for` va `asp-validation-summary`

## 4) Cac URL de test nhanh

- Login page: `/Account/Login`
- Book list: `/Book/Index`
- Book detail mau: `/Book/Detail/1`
- Add book: `/Book/Create`

## 5) Chay ung dung

Tu thu muc `Exer3/src`, chay:

`dotnet run`

Sau do mo browser theo URL duoc in ra de test cac chuc nang.
