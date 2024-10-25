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

        // Ph??ng th?c này x? lý khi trang ???c truy c?p
        public void OnGet()
        {
            // Có th? thêm logic x? lý ban ??u n?u c?n
        }

        // Ph??ng th?c này x? lý khi form ???c submit
        public IActionResult OnPost()
        {
            // Ki?m tra m?t kh?u có kh?p không
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "M?t kh?u không kh?p.");
                return Page(); // Tr? v? l?i trang n?u có l?i
            }

            // X? lý ??ng ký tài kho?n (ví d? l?u vào c? s? d? li?u)
            Message = "??ng ký thành công!";

            return RedirectToPage("/Index"); // Chuy?n h??ng sau khi ??ng ký thành công
        }
    }
}
