using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using Microsoft.Data.SqlClient;

public class IndexModel : PageModel
{
    private readonly IKoiService _koiService;
    private readonly string _connectionString;
    public IndexModel(IKoiService koiService)
    {
        _koiService = koiService;
        _connectionString = "Data Source=DESKTOP-QFUFB46;Initial Catalog=FengShuiKoiDB;Persist Security Info=True;User ID=sa;Password=123123;MultipleActiveResultSets=True;TrustServerCertificate=True";
    }

    public IEnumerable<Koi>? KoiList { get; set; }

    public async Task OnGetAsync()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            try
            {
                connection.Open(); // Th? m? k?t n?i
                Console.WriteLine("ket noi thanh cong databse");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"khong the ket noi: {ex.Message}");
            }
        }
        KoiList = await _koiService.getKoiAsync();
    }
   
}
