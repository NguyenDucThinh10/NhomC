using KoiProject.Repositories.Entities;

namespace KoiProject.Service.Models
{

    public class ConsultationResult
    {
        public List<KoiSpecy>? RecommendedKoi { get; set; } = new List<KoiSpecy>();
        public List<KoiSpecy>? KoiDetails => RecommendedKoi;  // Thêm thuộc tính KoiDetails
        public string? KoiNumber { get; set; } = string.Empty;
    }
}
