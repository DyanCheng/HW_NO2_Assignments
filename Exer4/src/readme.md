### 1. Định nghĩa các quy tắc kiểm tra trên Model (`Models/Book.cs`)
Bằng cách sử dụng **Data Annotations** (các attribute được cung cấp sẵn của .NET) khai báo cho dữ liệu sách:
```csharp
public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Không được để trống")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal Price { get; set; }
}
```
- Thuộc tính `Name` sử dụng `[Required]` để đảm bảo người dùng bắt buộc nhập tên sách.
- Thuộc tính `Price` sử dụng `[Range]` để quy định giá sách phải là một số dương (nhỏ nhất là `0.01`).

### 2. Giao diện form nhập liệu (`Views/Book/Create.cshtml`)
Khi người dùng truy cập trang thêm sách (gọi Action `GET /Book/Create`), giao diện form sẽ được hiển thị. Trong file View này sẽ chứa các **Tag Helper** tích hợp sẵn của ASP.NET Core để bắt lỗi:
- `asp-validation-summary="ModelOnly" / "All"`: Hiển thị danh sách tổng hợp tất cả lỗi.
- `asp-validation-for="Name"`  và `asp-validation-for="Price"`: Hiển thị câu thông báo lỗi cụ thể (ErrorMessage đã định nghĩa trong class Book) nằm ngay dưới ô input nếu trường đó bị nhập sai.

### 3. Thực thi Validation khi Submit form (`Controllers/BookController.cs`)
Khi người dùng điền form và nhấn Submit, dữ liệu sẽ được gửi tới action xử lý (POST request):
```csharp
[HttpPost]
public IActionResult Create(Book model)
{
    // ASP.NET tự động kiểm tra model dựa vào các Annotation.
    
    // Nếu kiểm tra thất bại (ví dụ: Name để trống hoặc Price = 0)
    if (!ModelState.IsValid)
    {
        // Trả lại giao diện form cùng model người dùng vừa nhập để họ xem được lỗi
        return View(model);
    }

    // Nếu dữ liệu hợp lệ: xử lý thêm sách vào List
    model.Id = Books.Max(b => b.Id) + 1;
    Books.Add(model);

    TempData["SuccessMessage"] = "Thêm sách thành công";
    return RedirectToAction(nameof(Create));
}
```
**Luồng chi tiết tại Action POST:**
1. **Model Binding:** ASP.NET Core tự động nhận dữ liệu từ các thẻ input của HTML và chuyển (bind) thành đối tượng `Book model`. Trong lúc đó, hệ thống cũng kiểm tra đối chiếu dữ liệu với các `Data Annotations`.
2. **Kiểm tra `ModelState.IsValid`:**
    - **Lỗi (False):** Controller sẽ lập tức `return View(model);`. Giao diện được render lại, các Tag Helper `asp-validation-*` sẽ lấy lỗi hiện tại ở `ModelState` in ra màn hình cảnh báo người dùng.
    - **Hợp lệ (True):** Cuốn sách mới được cấp ID, lưu vào bộ nhớ `Books`, gán câu thông báo thành công thông qua bộ nhớ tạm `TempData` và điều hướng (redirect) về lại trang mới (chức năng PRGán GET Create) để kết thúc một chu kỳ hoạt động.