using KoiProject.Repositories;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using KoiProject.Service;
using KoiProject.Service.Interfaces;
using KoiProject.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký DbContext
builder.Services.AddDbContext<FengShuiKoiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

// 2. Đăng ký các dịch vụ và Repository
builder.Services.AddScoped<IKoiService, KoiService>();
builder.Services.AddScoped<IKoiRepository, KoiRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IKoiConsultationService, KoiConsultationService>();
builder.Services.AddScoped<IKoiSpeciesRepository, KoiSpeciesRepository>();
builder.Services.AddScoped<IPondFeaturesRepository, PondFeaturesRepository>();

// 3. Đăng ký Razor Pages và Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 4. Đăng ký Authentication và Authorization
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/DangNhap"; // Trang đăng nhập
        options.LogoutPath = "/Logout"; // Trang đăng xuất
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie hết hạn sau 60 phút
        options.SlidingExpiration = true; // Tự động gia hạn cookie nếu người dùng hoạt động
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor(); // Dùng để truy cập HttpContext

// 5. Xây dựng ứng dụng
var app = builder.Build();

// Middleware cho mọi response (Thêm header charset UTF-8)
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
    await next();
});

// 6. Cấu hình xử lý lỗi cho Production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // HSTS cho Production
}

// 7. Middleware cơ bản
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // Bắt buộc để xử lý định tuyến

app.UseAuthentication(); // Middleware xác thực
app.UseAuthorization(); // Middleware phân quyền

// 8. Map route
app.MapBlazorHub(); // Map Blazor
app.MapFallbackToPage("/_Host"); // Dự phòng Blazor
app.MapRazorPages(); // Map Razor Pages

// 9. Chạy ứng dụng
app.Run();
