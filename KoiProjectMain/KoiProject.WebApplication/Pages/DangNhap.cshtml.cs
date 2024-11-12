using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
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
			if (!await _accountRepository.DoesEmailExistAsync(Email))
			{
				ErrorMessage = "Email không t?n t?i.";
				return Page();
			}

			var isValidAccount = await _accountRepository.ValidateAccountAsync(Email, Password);

			if (isValidAccount)
			{
				var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Email, Email)
		};
				var identity = new ClaimsIdentity(claims, "Cookies");
				var principal = new ClaimsPrincipal(identity);

				await HttpContext.SignInAsync("Cookies", principal);

				if (string.IsNullOrEmpty(ReturnUrl) || !Url.IsLocalUrl(ReturnUrl))
				{
					ReturnUrl = "/Index";
				}

				return Redirect(ReturnUrl);
			}

			ErrorMessage = "M?t kh?u không chính xác.";
			return Page();
		}


	}
}
