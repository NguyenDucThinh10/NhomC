using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace KoiProject.WebApplication.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // Xóa cookie xác th?c
            await HttpContext.SignOutAsync("Cookies");

            // Chuy?n h??ng v? trang ??ng nh?p
            return RedirectToPage("/DangNhap");
        }
    }
}
