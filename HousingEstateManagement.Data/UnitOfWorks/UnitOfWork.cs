using System.Threading.Tasks;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.Data.Context;
using HousingEstateManagement.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace HousingEstateManagement.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private  AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private AnnouncementRepository _announcementRepository;
        private BuildingRepository _buildingRepository;
        private ExpenseRepository _expenseRepository;
        private ExpenseTypeRepository _expenseTypeRepository;
        private FlatRepository _flatRepository;
        private MessageRepository _messageRepository;
        private UserRepository _userRepository;

        public IAnnouncementRepository Announcements => _announcementRepository = _announcementRepository ?? new AnnouncementRepository(_context);

        public IBuildingRepository Buildings => _buildingRepository = _buildingRepository ?? new  BuildingRepository(_context);

        public IExpenseRepository Expense => _expenseRepository = _expenseRepository ?? new ExpenseRepository(_context);

        public IExpenseTypeRepository ExpenseTypes => _expenseTypeRepository = _expenseTypeRepository ?? new ExpenseTypeRepository(_context);

        public IFlatRepository Flats => _flatRepository = _flatRepository ?? new FlatRepository(_context);

        public IMessageRepository Messages => _messageRepository = _messageRepository ?? new MessageRepository(_context);
        
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}