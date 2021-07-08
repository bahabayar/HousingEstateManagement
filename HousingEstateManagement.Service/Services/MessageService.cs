using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.SharedLibrary.Results;


namespace HousingEstateManagement.Service.Services
{
    public class MessageService:IMessageService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IMessageRepository _messageRepository;
        private IUserService _userService;

        public MessageService(IMapper mapper, IUnitOfWork unitOfWork, IMessageRepository messageRepository,
              IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _userService = userService;
        }
        
        public async Task<IDataResult<MessageDto>> GetByIdAsync(int id)
        {
            var messageDto = _mapper.Map<MessageDto>(await _unitOfWork.Messages.GetByIdAsync(id));
            if (messageDto != null)
            {
                return new SuccessDataResult<MessageDto>(messageDto);
            }
            return new ErrorDataResult<MessageDto>();
        }

        public async Task<IDataResult<List<MessageDto>>> GetAllAsync()
        {
            var messageDtos = _mapper.Map<List<MessageDto>>(await _unitOfWork.Messages.GetAllAsync());
            if (messageDtos != null)
            {
                return new SuccessDataResult<List<MessageDto>>(messageDtos);
            }
            return new ErrorDataResult<List<MessageDto>>();
        }

        public async Task<IDataResult<MessageDto>> AddAsync(MessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            await _messageRepository.AddAsync(message);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<MessageDto>(messageDto);
        }

        public async Task<IDataResult<List<MessageDto>>> AddRangeAsync(List<MessageDto> messageDtos)
        {
            var message = _mapper.Map<List<Message>>(messageDtos);
            await _messageRepository.AddRangeAsync(message);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<MessageDto>>(messageDtos);
        }

        public IResult Remove(int id)
        {
            var message = _messageRepository.GetByIdAsync(id).Result;
            _messageRepository.Remove(message);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IResult RemoveRange(List<MessageDto> messageDtos)
        {
            var messages = _mapper.Map<List<Message>>(messageDtos);
            _messageRepository.RemoveRange(messages);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IDataResult<MessageDto> Update(MessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            _messageRepository.Update(message);
            _unitOfWork.Commit();
            return new SuccessDataResult<MessageDto>(messageDto);
        }

        public async Task<IDataResult<List<MessageDto>>> GetListOutbox(List<MessageDto> messageList)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var item in messageList)
            {
                var reciever = await _userService.FindById(item.ReceiverId);
                var messageDto = new MessageDto
                {
                    Id = item.Id,
                    SenderId = item.SenderId,
                    ReceiverId = item.ReceiverId,
                    MessageContent = item.MessageContent,
                    UserName = reciever.Data.UserName
                };
                messageDtos.Add(messageDto);
            }
            return new SuccessDataResult<List<MessageDto>>(messageDtos);
        }

        public async Task<IDataResult<List<MessageDto>>> GetListInbox(List<MessageDto> messageList)
        {
            List<MessageDto> messageDtos = new List<MessageDto>();
            foreach (var item in messageList)
            {
                var sender = await _userService.FindById(item.SenderId);
                var messageDto = new MessageDto
                {
                    Id = item.Id,
                    SenderId = item.SenderId,
                    ReceiverId = item.ReceiverId,
                    MessageContent = item.MessageContent,
                    UserName = sender.Data.UserName
                };
                messageDtos.Add(messageDto);
            }
            return new SuccessDataResult<List<MessageDto>>(messageDtos);
        }

    }
}