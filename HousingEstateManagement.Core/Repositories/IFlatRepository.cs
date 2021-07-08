using System.Collections.Generic;
using System.Threading.Tasks;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Core.Repositories
{
    public interface IFlatRepository: IRepository<Flat>
    {
        Task<List<Flat>> GetAllFlatsByRelations();
    }
}