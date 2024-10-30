using KoiProject.Repositories.Entities;

namespace KoiProject.Service.Models
{

    public class ConsultationResult
    {
        public List<KoiSpecy>? RecommendedKoi { get; set; } = new List<KoiSpecy>();
        public List<PondFeature>? PondFeatures { get; set; } = new List<PondFeature>();
        public string? KoiNumber { get; set; } = string.Empty;


    }
}
