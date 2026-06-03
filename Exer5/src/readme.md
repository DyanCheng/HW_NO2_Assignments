### 1.Middleware dùng để làm gì?
Xử lý HTTP request/response theo chuỗi pipeline: log, auth, routing, cache, chặn request lỗi, v.v. — trước/sau khi vào Controller.

### 2.Khác Controller ở đâu?
Middleware chạy cho mọi request khớp pipeline; Controller chỉ chạy khi routing chọn action cụ thể. Middleware không map URL → action như Controller.

### 3.await _next(context);
Gọi middleware tiếp theo trong pipeline (hoặc endpoint). Sau khi phần sau xử lý xong, code phía dưới dòng này mới chạy (log status code, v.v.).

### 4.Vì sao return; thì không vào Controller?
return kết thúc middleware hiện tại không gọi _next → pipeline dừng, response đã gửi (400 + nội dung) → không còn bước nào tới Controller.

### 5.Đặt middleware sau MapControllerRoute?
Middleware không chạy cho các route đã map (hoặc không chạy đúng như mong muốn). Log/chặn URL sẽ không áp dụng được cho request Book.

### 6.Thêm middleware khác?
Đăng ký thêm trước MapControllerRoute, theo thứ tự cần dùng:

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<AnotherMiddleware>();
app.MapControllerRoute(...);
Hoặc app.Use(...) / extension app.UseXxx() tương tự.