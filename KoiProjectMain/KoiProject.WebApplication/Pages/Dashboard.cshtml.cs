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
                Console.WriteLine("");

                if (!User.Identity?.IsAuthenticated ?? false)
                {
                    Console.WriteLine("");
                    return RedirectToPage("/DangNhap");
                }

                var userRole = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;
                Console.WriteLine($": {userRole}");

                if (userRole != "Admin")
                {
                    Console.WriteLine("");
                    return RedirectToPage("/AccessDenied");
                }

                Console.WriteLine(".");
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
                return RedirectToPage("/Error");
            }
        }


    }
}
