using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using KoiProject.Repositories.Interfaces;

namespace KoiProject.WebApplication.Pages
{
    public class DangNhapModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public DangNhapModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository; // Inject `IAccountRepository`
        }

        [BindProperty]
        public string Email { get; set; } // Nh?n giá tr? t? form ??ng nh?p

        [BindProperty]
        public string Password { get; set; } // Nh?n giá tr? t? form ??ng nh?p

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } // L?u trang ?ích sau khi ??ng nh?p

        [TempData]
        public string ErrorMessage { get; set; } // L?u thông báo l?i

        public IActionResult OnGet()
        {
            ReturnUrl ??= "/Index"; // Trang m?c ??nh n?u không có `ReturnUrl`
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Ki?m tra email có t?n t?i không
            if (!await _accountRepository.DoesEmailExistAsync(Email))
            {
                ErrorMessage = "Account does not exist.";
                return Page();
            }

            // L?y tài kho?n t? c? s? d? li?u
            var account = await _accountRepository.GetAccountByEmailAndPasswordAsync(Email, Password);

            if (account != null)
            {
                // T?o danh sách claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, account.Email), // Email ng??i dùng
                    new Claim(ClaimTypes.Name, account.FullName), // Tên ng??i dùng
                    new Claim("Role", account.UserRoleId == 3 ? "Admin" : "Member") // Phân bi?t role
                };

                // T?o ClaimsIdentity và ClaimsPrincipal
                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                // ??ng nh?p b?ng Cookie
                await HttpContext.SignInAsync("Cookies", principal);

                // Ki?m tra và x? lý ReturnUrl
                if (string.IsNullOrEmpty(ReturnUrl) || !Url.IsLocalUrl(ReturnUrl))
                {
                    // Chuy?n h??ng d?a vào Role
                    ReturnUrl = account.UserRoleId == 3 ? "/Dashboard" : "/Index";
                }

                return Redirect(ReturnUrl);
            }

            // N?u m?t kh?u không chính xác
            ErrorMessage = "Email or password is incorrect.";
            return Page();
        }
    }
}
