using KoiProject.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace KoiProject.WebApplication.Pages
{
    [Authorize]
    public class TuVanHoCaModel : PageModel
    {
        private readonly string _connectionString = "Data Source=DESKTOP-0TQPALR;Initial Catalog=FengShuiKoiDB1;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        [BindProperty]
        public string Element { get; set; }

        public List<PondFeatures> PondRecommendations { get; set; }

        public IActionResult OnGet()
        {
            // Kiểm tra trạng thái đăng nhập
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                // Chưa đăng nhập, chuyển đến trang Login
                return RedirectToPage("/DangNhap", new { returnUrl = "/TuVanHoCa" });
            }

            // Đã đăng nhập, tiếp tục hiển thị nội dung trang
            return Page();
        }
        public async Task OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Element))
            {
                // Lấy danh sách hồ cá phù hợp từ cơ sở dữ liệu dựa vào bản mệnh
                PondRecommendations = await GetPondsByElementAsync(Element);
            }
        }

        private async Task<List<PondFeatures>> GetPondsByElementAsync(string element)
        {
            var ponds = new List<PondFeatures>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT PondID, Shape, SuitableElement, Direction, Description FROM PondFeatures WHERE SuitableElement = @Element";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Element", element);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ponds.Add(new PondFeatures
                            {
                                PondID = reader.GetInt32(0),
                                Shape = reader.GetString(1),
                                SuitableElement = reader.GetString(2),
                                Direction = reader.GetString(3),
                                Description = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return ponds;
        }
    }
}
