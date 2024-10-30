using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KoiProject.Repositories.Interfaces
{
    public interface IPondFeaturesRepository
    {
        List<PondFeature> GetPondFeaturesByElement(string element);
    }

}
