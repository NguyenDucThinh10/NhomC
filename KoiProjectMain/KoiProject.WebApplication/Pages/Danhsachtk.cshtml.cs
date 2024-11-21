using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Pages
{
    [Authorize]
    public class DanhsachtkModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DanhsachtkModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public List<Account> Accounts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                // Ki?m tra xem ng??i d�ng ?� ??ng nh?p ch?a
                if (!User.Identity?.IsAuthenticated ?? false)
                {
                    return RedirectToPage("/DangNhap");
                }

                // L?y quy?n c?a ng??i d�ng t? claim
                var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;

                // Ki?m tra n?u kh�ng ph?i Admin th� chuy?n h??ng ??n trang AccessDenied
                if (userRole != "Admin")
                {
                    return RedirectToPage("/AccessDenied");
                }

                // N?u l� Admin, ti?p t?c l?y danh s�ch t�i kho?n
                Accounts = await _accountService.GetAllAccountsAsync();

                return Page();
            }
            catch (Exception ex)
            {
                // Log l?i (t�y ch?n)
                Console.WriteLine($": {ex.Message}");
                return RedirectToPage("/Error");
            }
        }
    }
}
