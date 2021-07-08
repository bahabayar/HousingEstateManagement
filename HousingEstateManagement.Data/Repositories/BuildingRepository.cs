using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;

namespace HousingEstateManagement.Data.Repositories
{
    public class BuildingRepository: Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(AppDbContext context) : base(context)
        {
        }
    }
}