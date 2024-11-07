using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
namespace KoiProject.Service.Services;

public class KoiConsultationService : IKoiConsultationService
{
    private readonly IKoiRepository _koiRepository;

    public KoiConsultationService(IKoiRepository koiRepository)
    {
        _koiRepository = koiRepository;
    }

    public async Task<List<KoiSpecy>> GetKoiRecommendationByElementAsync(string element, int quantity)
    {
        var koiList = await _koiRepository.GetKoiSpeciesByElementAsync(element);
        // Apply additional logic for quantity if needed
        return koiList;
    }
}
