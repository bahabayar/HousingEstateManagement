using System.Collections.Generic;

namespace HousingEstateManagement.Core.Entities
{
    public class ExpenseType:IEntity
    {
        public int Id { get; set; }

        public string ExpenseTypeName { get; set; } 

        public List<Expense> Expenses { get; set; }
    }
}