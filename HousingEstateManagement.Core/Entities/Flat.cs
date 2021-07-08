using System.Collections.Generic;

namespace HousingEstateManagement.Core.Entities
{
    public class Flat:IEntity
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string TypeOfFlat{ get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}