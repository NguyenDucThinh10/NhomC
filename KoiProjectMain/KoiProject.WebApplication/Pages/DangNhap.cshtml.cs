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
        public string Email { get; set; } // Nh?n gi� tr? t? form ??ng nh?p

        [BindProperty]
        public string Password { get; set; } // Nh?n gi� tr? t? form ??ng nh?p

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; } // L?u trang ?�ch sau khi ??ng nh?p

        [TempData]
        public string ErrorMessage { get; set; } // L?u th�ng b�o l?i

        public IActionResult OnGet()
        {
            ReturnUrl ??= "/Index"; // Trang m?c ??nh n?u kh�ng c� `ReturnUrl`
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Ki?m tra email c� t?n t?i kh�ng
            if (!await _accountRepository.DoesEmailExistAsync(Email))
            {
                ErrorMessage = "Account does not exist.";
                return Page();
            }

            // L?y t�i kho?n t? c? s? d? li?u
            var account = await _accountRepository.GetAccountByEmailAndPasswordAsync(Email, Password);

            if (account != null)
            {
                // T?o danh s�ch claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, account.Email), // Email ng??i d�ng
                    new Claim(ClaimTypes.Name, account.FullName), // T�n ng??i d�ng
                    new Claim("Role", account.UserRoleId == 3 ? "Admin" : "Member") // Ph�n bi?t role
                };

                // T?o ClaimsIdentity v� ClaimsPrincipal
                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                // ??ng nh?p b?ng Cookie
                await HttpContext.SignInAsync("Cookies", principal);

                // Ki?m tra v� x? l� ReturnUrl
                if (string.IsNullOrEmpty(ReturnUrl) || !Url.IsLocalUrl(ReturnUrl))
                {
                    // Chuy?n h??ng d?a v�o Role
                    ReturnUrl = account.UserRoleId == 3 ? "/Dashboard" : "/Index";
                }

                return Redirect(ReturnUrl);
            }

            // N?u m?t kh?u kh�ng ch�nh x�c
            ErrorMessage = "Email or password is incorrect.";
            return Page();
        }
    }
}
