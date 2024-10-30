using KoiProject.Service.Models;
namespace KoiProject.Service.Interfaces
{
    public interface IConsultationService
    {
        ConsultationResult GetConsultation(string gender, int birthYear, string element, string preference);
    }
}
