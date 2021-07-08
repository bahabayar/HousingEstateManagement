using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HousingEstateManagement.Data.Repositories
{
    public class FlatRepository: Repository<Flat>, IFlatRepository
    {
        public FlatRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Flat>> GetAllFlatsByRelations()
        {
            return  await _context.Flats
                .Include(x=>x.User)
                .Include(x=>x.Building)
                .OrderBy(x=>x.FlatNumber)
                .ToListAsync();
        }
    }
}