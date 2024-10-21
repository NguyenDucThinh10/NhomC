using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using KoiProject.Service.Interfaces;
using KoiProject.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DI - Đăng ký các dịch vụ vào container
builder.Services.AddDbContext<FengShuiKoiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddScoped<IKoiRepository, KoiRepositories>();

// Đăng ký Razor Pages và Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Cấu hình HSTS cho môi trường production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Bắt buộc để xử lý định tuyến cho Razor Pages và Blazor

app.UseAuthorization(); // Sử dụng middleware xác thực (nếu có)

// Định nghĩa route cho Blazor và Razor Pages
app.MapBlazorHub(); // Map endpoint cho Blazor
app.MapFallbackToPage("/_Host"); // Dự phòng cho Blazor nếu không tìm thấy route

app.MapRazorPages(); // Map Razor Pages

app.Run();
