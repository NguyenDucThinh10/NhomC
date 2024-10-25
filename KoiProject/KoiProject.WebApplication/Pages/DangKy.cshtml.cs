using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Pages
{
    public class DangKyModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        // Ph??ng th?c n�y x? l� khi trang ???c truy c?p
        public void OnGet()
        {
            // C� th? th�m logic x? l� ban ??u n?u c?n
        }

        // Ph??ng th?c n�y x? l� khi form ???c submit
        public IActionResult OnPost()
        {
            // Ki?m tra m?t kh?u c� kh?p kh�ng
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "M?t kh?u kh�ng kh?p.");
                return Page(); // Tr? v? l?i trang n?u c� l?i
            }

            // X? l� ??ng k� t�i kho?n (v� d? l?u v�o c? s? d? li?u)
            Message = "??ng k� th�nh c�ng!";

            return RedirectToPage("/Index"); // Chuy?n h??ng sau khi ??ng k� th�nh c�ng
        }
    }
}
