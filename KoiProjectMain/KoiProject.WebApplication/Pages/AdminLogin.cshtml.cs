using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace KoiProject.WebApplication.Pages
{
    public class AdminLoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public AdminLoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }



        public IActionResult OnPost()
        {
            var account = _accountService.GetAccountByEmailAndPassword(Email, Password);
            if (account != null)
            {
                // ??ng xu?t tr??c khi ??ng nh?p ?? tr�nh tr�n quy?n
                HttpContext.SignOutAsync("Cookies").Wait();

                // G�n quy?n d?a tr�n UserRoleId
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, account.Email),
            new Claim(ClaimTypes.Role, account.UserRoleId.ToString()) // G�n UserRoleId l�m Role
        };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("Cookies", principal);

                // ?i?u h??ng d?a tr�n vai tr�
                if (account.UserRoleId == 3) // Admin
                {
                    return Redirect("/Dashboard/index.html");
                }

                if (account.UserRoleId == 2) // Member
                {
                    return RedirectToPage("/Index");
                }
            }
            else
            {
                ErrorMessage = "Email or password is incorrect.";
                return Page();
            }

            return Page();
        }


    }
}
