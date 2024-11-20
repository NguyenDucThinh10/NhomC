using KoiProject.Repositories;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using KoiProject.Service;
using KoiProject.Service.Interfaces;
using KoiProject.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

builder.Services.AddAuthorization(options =>
{
    // Thêm chính sách chỉ dành cho Admin
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("Role", "Admin")); // Xác định Role = Admin
});

builder.Services.AddHttpContextAccessor(); // Dùng để truy cập HttpContext

// 5. Xây dựng ứng dụng
var app = builder.Build();

// Middleware xử lý lỗi
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hiển thị thông báo lỗi chi tiết trong Development
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
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
