using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.SharedLibrary.Results;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HousingEstateManagement.Core.Services
{
    public interface IMessageService
    {
        Task<IDataResult<MessageDto>> GetByIdAsync(int id);

        Task<IDataResult<List<MessageDto>>> GetAllAsync();

        Task<IDataResult<MessageDto>> AddAsync(MessageDto messageDto);

        Task<IDataResult<List<MessageDto>>> AddRangeAsync(List<MessageDto> messageDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<MessageDto> messageDto);

        IDataResult<MessageDto> Update(MessageDto messageDto);
        Task<IDataResult<List<MessageDto>>> GetListOutbox(List<MessageDto> messageList);
        Task<IDataResult<List<MessageDto>>> GetListInbox(List<MessageDto> messageList);
    }
}