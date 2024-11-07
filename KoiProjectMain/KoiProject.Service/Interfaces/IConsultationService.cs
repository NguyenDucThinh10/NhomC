using KoiProject.Service.Models;
using KoiProject.Repositories.Entities;
namespace KoiProject.Service.Interfaces
{
    public interface IKoiConsultationService
    {
        Task<List<KoiSpecy>> GetKoiRecommendationByElementAsync(string element, int quantity);
    }
}
