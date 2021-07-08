using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.SharedLibrary.Results;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HousingEstateManagement.Core.Services
{
    public interface IFlatService
    {
        Task<IDataResult<FlatDto>> GetByIdAsync(int id);

        Task<IDataResult<List<FlatDto>>> GetAllAsync();

        Task<IDataResult<FlatCreateDto>> AddAsync(FlatCreateDto flatCreateDto);

        Task<IDataResult<List<FlatCreateDto>>> AddRangeAsync(List<FlatCreateDto> flatCreateDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<FlatDto> flatDtos);

        IDataResult<FlatUpdateDto> Update(FlatUpdateDto flatUpdateDto);
        
        Task<IDataResult<List<FlatDto>>> GetAllFlatsByRelations();
    }
}