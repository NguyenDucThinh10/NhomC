using KoiProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using KoiProject.Repositories.Entities;

public class KoiSpeciesRepository : IKoiSpeciesRepository
{
    private readonly FengShuiKoiDbContext _context;

    public KoiSpeciesRepository(FengShuiKoiDbContext context)
    {
        _context = context;
    }

    public List<KoiSpecy> GetKoiSpeciesByElement(string element)
    {
        return _context.KoiSpecies
                       .Where(k => k.SuitableElement == element)
                       .ToList();
    }
}
