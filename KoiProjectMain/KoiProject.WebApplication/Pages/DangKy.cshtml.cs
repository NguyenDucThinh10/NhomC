using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;

namespace KoiProject.WebApplication.Pages
{
    public class DangKyModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DangKyModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string FullName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public bool IsRegistered { get; set; } = false; // Xác định trạng thái đăng ký thành công
        public bool EmailExists { get; set; } = false; // Xác định trạng thái email tồn tại

        public void OnGet()
        {
            // Logic ban đầu nếu cần
        }

        public IActionResult OnPost()
        {
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu không khớp.");
                return Page();
            }

            try
            {
                // Kiểm tra xem email đã tồn tại chưa
                if (_accountService.IsEmailExists(Email))
                {
                    EmailExists = true;
                    ModelState.AddModelError("Email","Email đã được đăng ký."); // Thêm thông báo lỗi
                    return Page();
                }

                // Tạo đối tượng tài khoản mới
                var account = new Account
                {
                    FullName = FullName,
                    Email = Email,
                    Password = Password // Lưu ý: nên mã hóa mật khẩu trước khi lưu
                };

                // Lưu tài khoản vào cơ sở dữ liệu
                _accountService.RegisterAccount(account);

                // Đặt trạng thái đăng ký thành công
                IsRegistered = true;
                Message = "Đăng ký thành công!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi: " + ex.Message);
                return Page();
            }

            return Page();
        }
    }
}
