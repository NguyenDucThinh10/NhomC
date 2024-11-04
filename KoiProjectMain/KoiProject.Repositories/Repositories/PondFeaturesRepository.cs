using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
public class PondFeaturesRepository : IPondFeaturesRepository
{
    private readonly FengShuiKoiDbContext _context;

    public PondFeaturesRepository(FengShuiKoiDbContext context)
    {
        _context = context;
    }

    public List<PondFeature> GetPondFeaturesByElement(string element)
    {
        return _context.PondFeatures
                       .Where(p => p.SuitableElement == element)
                       .ToList();
    }
}
