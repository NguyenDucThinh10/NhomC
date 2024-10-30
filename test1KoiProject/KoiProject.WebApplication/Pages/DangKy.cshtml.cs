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
            Console.WriteLine("OnPost method called!"); // In ra để kiểm tra xem có được gọi hay không

            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu không khớp.");
                return Page(); // Trả về lại trang nếu có lỗi
            }

            // Xử lý đăng ký tài khoản
            Message = "Đăng ký thành công!"; // Gán thông báo thành công

            return Page(); // Ở lại trang và hiển thị thông báo
        }

    }
}
