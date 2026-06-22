using Microsoft.EntityFrameworkCore;
using OrmApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("BookManagement")
    ?? throw new InvalidOperationException("Connection string 'BookManagement' not found.");

builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<BookRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
