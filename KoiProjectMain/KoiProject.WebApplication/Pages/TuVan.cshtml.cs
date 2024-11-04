using KoiProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// C?u trúc c? s? d? li?u
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

        // L?y gi?ng cá Koi t? b?ng FishSpecies d?a trên b?n m?nh
        var fishList = await _dbContext.KoiSpecies
                                       .Where(f => f.SuitableElement == Element)
                                       .ToListAsync();
        

        foreach (var fish in fishList)
        {
            Console.WriteLine(fish.Description); // Ki?m tra d? li?u ti?ng Vi?t có ?úng không
        }

        // Xác ??nh gi?ng cá Koi d?a trên y?u t? phong th?y
        switch (Element)
        {
            case "Metal":
                ConsultationResult.RecommendedKoi = "Platinum Ogon, Gin Rin";
                ConsultationResult.PondShape = "Hình tròn ho?c hình oval";
                ConsultationResult.Direction = "H??ng Tây";
                ConsultationResult.KoiNumber = "2-4";
                break;
            case "Wood":
                ConsultationResult.RecommendedKoi = "Chagoi, Soragoi";
                ConsultationResult.PondShape = "Hình ch? nh?t";
                ConsultationResult.Direction = "H??ng ?ông";
                ConsultationResult.KoiNumber = "3-5";
                break;
            case "Water":
                ConsultationResult.RecommendedKoi = "Asagi, Shusui";
                ConsultationResult.PondShape = "Hình t? nhiên, không ??u";
                ConsultationResult.Direction = "H??ng B?c";
                ConsultationResult.KoiNumber = "4-6";
                break;
            case "Fire":
                ConsultationResult.RecommendedKoi = "Hi Utsuri, Kohaku";
                ConsultationResult.PondShape = "Hình tam giác";
                ConsultationResult.Direction = "H??ng Nam";
                ConsultationResult.KoiNumber = "1-3";
                break;
            case "Earth":
                ConsultationResult.RecommendedKoi = "Ochiba, Sanke";
                ConsultationResult.PondShape = "Hình vuông";
                ConsultationResult.Direction = "Trung tâm";
                ConsultationResult.KoiNumber = "5-7";
                break;
        }

        // ?i?u ch?nh k?t qu? theo gi?i tính và n?m sinh
        if (Gender == "Male" && BirthYear % 2 == 0)
        {
            ConsultationResult.RecommendedKoi += " (dành cho nam)";
        }
        else
        {
            ConsultationResult.RecommendedKoi += " (dành cho n?)";
        }

        // Thêm logic ?? ?i?u ch?nh theo s? thích cá nhân
        if (!string.IsNullOrEmpty(Preference))
        {
            ConsultationResult.RecommendedKoi += $", và có th? cân nh?c {Preference}";
        }

        // L?y URL c?a các gi?ng cá phù h?p t? b?ng FishSpecies
        ConsultationResult.KoiUrls = fishList.Select(f => new KoiInfo
        {
            Name = f.Name,
            Url = f.ImageUrl
        }).ToList();

        return Page();
    }
}

// L?p ch?a thông tin k?t qu? t? v?n
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
