using KoiProject.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

using System.Linq;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class TuVanHoCaModel : PageModel
    {
        private readonly string _connectionString = "Data Source=DESKTOP-0TQPALR;Initial Catalog=FengShuiKoiDB1;Integrated Security=True;Trust Server Certificate=True";

        [BindProperty]
        public string Element { get; set; }

        public List<PondFeatures> PondRecommendations { get; set; }

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
