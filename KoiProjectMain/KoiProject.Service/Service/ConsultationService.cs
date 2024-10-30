using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using KoiProject.Service.Models;
using System.Collections.Generic;

namespace KoiProject.Service
{
    public class ConsultationService : IConsultationService
    {
        private readonly IKoiSpeciesRepository _koiSpeciesRepository;
        private readonly IPondFeaturesRepository _pondFeaturesRepository;

        public ConsultationService(IKoiSpeciesRepository koiSpeciesRepository,
                                   IPondFeaturesRepository pondFeaturesRepository)
        {
            _koiSpeciesRepository = koiSpeciesRepository;
            _pondFeaturesRepository = pondFeaturesRepository;
        }

        public ConsultationResult GetConsultation(string gender, int birthYear, string element, string preference)
        {
            var recommendedKoi = _koiSpeciesRepository.GetKoiSpeciesByElement(element);
            var pondFeatures = _pondFeaturesRepository.GetPondFeaturesByElement(element);

            // Điều chỉnh số lượng cá dựa trên giới tính và năm sinh
            string koiNumber = (gender == "Male" && birthYear % 2 == 0) ? "2-4" : "1-3";

            // Thêm giống cá từ sở thích cá nhân
            if (!string.IsNullOrEmpty(preference))
            {
                recommendedKoi.Add(new KoiSpecy { Name = preference, Description = "User's preference" });
            }

            return new ConsultationResult
            {
                RecommendedKoi = recommendedKoi,
                PondFeatures = pondFeatures,
                KoiNumber = koiNumber
            };
        }
    }
}
