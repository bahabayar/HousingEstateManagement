using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;

namespace HousingEstateManagement.Data.Repositories
{
    public class MessageRepository: Repository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}