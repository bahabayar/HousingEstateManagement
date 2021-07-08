using System.Threading.Tasks;
using HousingEstateManagement.Core.Repositories;

namespace HousingEstateManagement.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAnnouncementRepository Announcements { get; }

        IBuildingRepository Buildings { get; }

        IExpenseRepository Expense { get; }

        IExpenseTypeRepository ExpenseTypes { get; }

        IFlatRepository Flats{ get; }

        IMessageRepository Messages { get; }
        
        IUserRepository Users { get; }

        Task CommitAsync();

        void Commit();
    }
}