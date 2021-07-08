using System.Threading.Tasks;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Core.Services
{
    public interface IRoleService
    {
        Task<Role> AddRole();
        Task<Role> DeleteRole();
        Task<Role> UpdateRole();
    }
}