using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.SharedLibrary.Results;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HousingEstateManagement.Core.Services
{
    public interface IUserService
    { 
        Task<IDataResult<List<UserDto>>> GetAllAsync();
        Task<IResult> CreateUserAsync(RegisterDto registerDto);
        Task<IResult> UpdateUserAsync(UserDto userDto);
        Task<IDataResult<UserDto>> FindById(string id);
        Task<IDataResult<UserDto>> FindByName(string name);
        Task<IDataResult<UserDto>> FindByEmail(string email);
        User GetUserFromSession();
        IResult Remove(string id);
    }
}