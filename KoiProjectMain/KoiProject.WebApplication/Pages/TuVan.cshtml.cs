using KoiProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// C?u tr�c c? s? d? li?u
public class FishSpecies
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Element { get; set; }
    public string Url { get; set; }
}

public class ConsultModel : PageModel
{
    private readonly FengShuiKoiDbContext _dbContext;

    public ConsultModel(FengShuiKoiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [BindProperty]
    public string Gender { get; set; }

    [BindProperty]
    public int BirthYear { get; set; }

    [BindProperty]
    public string Element { get; set; }

    [BindProperty]
    public string Preference { get; set; }

    public ConsultationResult ConsultationResult { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
       

        ConsultationResult = new ConsultationResult();

        // L?y gi?ng c� Koi t? b?ng FishSpecies d?a tr�n b?n m?nh
        var fishList = await _dbContext.KoiSpecies
                                       .Where(f => f.SuitableElement == Element)
                                       .ToListAsync();
        

        foreach (var fish in fishList)
        {
            Console.WriteLine(fish.Description); // Ki?m tra d? li?u ti?ng Vi?t c� ?�ng kh�ng
        }

        // X�c ??nh gi?ng c� Koi d?a tr�n y?u t? phong th?y
        switch (Element)
        {
            case "Metal":
                ConsultationResult.RecommendedKoi = "Platinum Ogon, Gin Rin";
                ConsultationResult.PondShape = "H�nh tr�n ho?c h�nh oval";
                ConsultationResult.Direction = "H??ng T�y";
                ConsultationResult.KoiNumber = "2-4";
                break;
            case "Wood":
                ConsultationResult.RecommendedKoi = "Chagoi, Soragoi";
                ConsultationResult.PondShape = "H�nh ch? nh?t";
                ConsultationResult.Direction = "H??ng ?�ng";
                ConsultationResult.KoiNumber = "3-5";
                break;
            case "Water":
                ConsultationResult.RecommendedKoi = "Asagi, Shusui";
                ConsultationResult.PondShape = "H�nh t? nhi�n, kh�ng ??u";
                ConsultationResult.Direction = "H??ng B?c";
                ConsultationResult.KoiNumber = "4-6";
                break;
            case "Fire":
                ConsultationResult.RecommendedKoi = "Hi Utsuri, Kohaku";
                ConsultationResult.PondShape = "H�nh tam gi�c";
                ConsultationResult.Direction = "H??ng Nam";
                ConsultationResult.KoiNumber = "1-3";
                break;
            case "Earth":
                ConsultationResult.RecommendedKoi = "Ochiba, Sanke";
                ConsultationResult.PondShape = "H�nh vu�ng";
                ConsultationResult.Direction = "Trung t�m";
                ConsultationResult.KoiNumber = "5-7";
                break;
        }

        // ?i?u ch?nh k?t qu? theo gi?i t�nh v� n?m sinh
        if (Gender == "Male" && BirthYear % 2 == 0)
        {
            ConsultationResult.RecommendedKoi += " (d�nh cho nam)";
        }
        else
        {
            ConsultationResult.RecommendedKoi += " (d�nh cho n?)";
        }

        // Th�m logic ?? ?i?u ch?nh theo s? th�ch c� nh�n
        if (!string.IsNullOrEmpty(Preference))
        {
            ConsultationResult.RecommendedKoi += $", v� c� th? c�n nh?c {Preference}";
        }

        // L?y URL c?a c�c gi?ng c� ph� h?p t? b?ng FishSpecies
        ConsultationResult.KoiUrls = fishList.Select(f => new KoiInfo
        {
            Name = f.Name,
            Url = f.ImageUrl
        }).ToList();

        return Page();
    }
}

// L?p ch?a th�ng tin k?t qu? t? v?n
public class ConsultationResult
{
    public string RecommendedKoi { get; set; }
    public string PondShape { get; set; }
    public string Direction { get; set; }
    public string KoiNumber { get; set; }
    public List<KoiInfo> KoiUrls { get; set; }
}

public class KoiInfo
{
    public string Name { get; set; }
    public string Url { get; set; }
}
