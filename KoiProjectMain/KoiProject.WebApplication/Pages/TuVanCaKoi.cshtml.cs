using KoiProject.Repositories.Entities;
using KoiProject.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class TuVanCaKoiModel : PageModel
    {
        private readonly string _connectionString = "Data Source=DESKTOP-QFUFB46;Initial Catalog=FengShuiKoiDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        [BindProperty]
        public string Gender { get; set; }

        [BindProperty]
        public string Element { get; set; }

        [BindProperty]
        public int BirthYear { get; set; }

        public ConsultationResult? ConsultationResult { get; set; }

        public IActionResult OnGet()
        {
            // Kiểm tra trạng thái đăng nhập
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                // Chưa đăng nhập, chuyển đến trang Login
                return RedirectToPage("/DangNhap", new { returnUrl = "/TuVanCaKoi" });
            }

            // Đã đăng nhập, tiếp tục hiển thị nội dung trang
            return Page();
        }

        public async Task OnPostAsync()
        {
            int age = DateTime.Now.Year - BirthYear;

            // Kiểm tra nếu tuổi nằm trong khoảng hợp lệ (0 đến 100)
            if (age >= 0 && age <= 100 && !string.IsNullOrEmpty(Element))
            {
                var koiList = await GetKoiByElementAsync(Element);
                ConsultationResult = new ConsultationResult
                {
                    RecommendedKoi = koiList,
                    KoiNumber = CalculateKoiNumber(BirthYear, Element).ToString() // Sử dụng công thức mới
                };
            }
            else
            {
                // Nếu tuổi không hợp lệ, không thiết lập ConsultationResult (để mặc định là null)
                ConsultationResult = null;
            }
        }


        private static int CalculateKoiNumber(int birthYear, string element)
        {
            int age = DateTime.Now.Year - birthYear;

            // Các số may mắn theo ngũ hành
            var luckyNumbers = element switch
            {
                "Kim" => new[] { 5, 10 },
                "Mộc" => new[] { 6, 11 },
                "Thủy" => new[] { 7, 12 },
                "Hỏa" => new[] { 8, 14 },
                "Thổ" => new[] { 4, 9 },

            };

            // Tuổi trẻ chọn số nhỏ hơn, tuổi lớn hơn chọn số lớn hơn
            return age < 30 ? luckyNumbers[0] : luckyNumbers[1];
        }


        private async Task<List<KoiSpecy>> GetKoiByElementAsync(string element)
        {
            var koiList = new List<KoiSpecy>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            // Sử dụng KoiSpecies làm tên bảng trong câu truy vấn SQL
            var query = "SELECT KoiID, Name, SuitableElement, Description, ImageURL FROM KoiSpecies WHERE SuitableElement = @Element";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Element", element);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                koiList.Add(new KoiSpecy
                {
                    KoiId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    SuitableElement = reader.GetString(2),
                    Description = reader.GetString(3),
                    ImageUrl = reader.GetString(4)
                });
            }

            return koiList;
        }
    }

    // Class đại diện cho kết quả tư vấn
    public class ConsultationResult
    {
        public List<KoiSpecy> RecommendedKoi { get; set; }
        public string KoiNumber { get; set; }
    }

    // Class đại diện cho một giống cá Koi
    public class KoiSpecy
    {
        public int KoiId { get; set; }
        public string Name { get; set; }
        public string SuitableElement { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
