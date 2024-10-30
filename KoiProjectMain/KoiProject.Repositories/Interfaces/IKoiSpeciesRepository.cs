using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
namespace KoiProject.Repositories.Interfaces
{
    public interface IKoiSpeciesRepository
    {
        List<KoiSpecy> GetKoiSpeciesByElement(string element);
    }
}
