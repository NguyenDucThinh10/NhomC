using KoiProject.Service.Interfaces;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiProject.WebApplication.Pages
{
    public class ConsultationModel : PageModel
    {
        private readonly IKoiConsultationService _consultationService;

        public ConsultationModel(IKoiConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [BindProperty]
        public string Gender { get; set; }

        [BindProperty]
        public int BirthYear { get; set; }

        [BindProperty]
        public string Element { get; set; }

        public ConsultationResult? ConsultationResult { get; set; }

        public async Task OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Element))
            {
                // G?i ph??ng th?c ?? l?y danh s�ch c� Koi ph� h?p v?i b?n m?nh
                var koiList = await _consultationService.GetKoiRecommendationByElementAsync(Element, CalculateKoiNumber(BirthYear));

                // T?o ??i t??ng ConsultationResult v� g�n c�c gi� tr? v�o
                ConsultationResult = new ConsultationResult
                {
                    RecommendedKoi = "C�c gi?ng c� Koi ph� h?p",
                    KoiNumber = CalculateKoiNumber(BirthYear),
                    KoiDetails = koiList.Select(koi => new KoiDetail
                    {
                        Name = koi.Name,
                        Description = koi.Description
                    }).ToList()
                };
            }
        }


        private int CalculateKoiNumber(int birthYear)
        {
            // V� d? ??n gi?n cho s? l??ng c� d?a tr�n tu?i
            int age = 2024 - birthYear;
            return (age % 5) + 1;  // Tr? v? s? l??ng t? 1 ??n 5 t�y thu?c v�o tu?i
        }
    }

    public class ConsultationResult
    {
        public string RecommendedKoi { get; set; }
        public int KoiNumber { get; set; }
        public List<KoiDetail> KoiDetails { get; set; }
    }

    public class KoiDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
