using KoiProject.Repositories.Entities;
using KoiProject.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
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
        private static int CalculateKoiNumber(int birthYear)
        {
            int age = DateTime.Now.Year - birthYear;
            return (age % 5) + 1;
        }

        public async Task OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Element))
            {
                var koiList = await GetKoiByElementAsync(Element);
                ConsultationResult = new ConsultationResult
                {
                    RecommendedKoi = koiList,
                    KoiNumber = CalculateKoiNumber(BirthYear).ToString()
                };
            }
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
}
