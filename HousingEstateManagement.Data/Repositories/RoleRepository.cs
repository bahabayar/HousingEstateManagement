using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;

namespace HousingEstateManagement.Data.Repositories
{
    public class RoleRepository:Repository<Role>,IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}