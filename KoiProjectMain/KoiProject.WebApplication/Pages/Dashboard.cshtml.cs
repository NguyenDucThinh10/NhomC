using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace KoiProject.WebApplication.Pages
{
    [Authorize] 
    public class DashboardModel : PageModel
    {
        public IActionResult OnGet()
        {
            try
            {
                Console.WriteLine("Dashboard OnGet ?ang ch?y.");

                if (!User.Identity?.IsAuthenticated ?? false)
                {
                    Console.WriteLine("Ng??i dùng ch?a ??ng nh?p.");
                    return RedirectToPage("/DangNhap");
                }

                var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
                Console.WriteLine($"Role c?a ng??i dùng: {userRole}");

                if (userRole != "Admin")
                {
                    Console.WriteLine("Ng??i dùng không ph?i Admin.");
                    return RedirectToPage("/AccessDenied");
                }

                Console.WriteLine("Trang Dashboard ?ang ???c t?i.");
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i trong Dashboard OnGet: {ex.Message}");
                return RedirectToPage("/Error");
            }
        }


    }
}
