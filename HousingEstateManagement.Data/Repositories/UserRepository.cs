using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;

namespace HousingEstateManagement.Data.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}