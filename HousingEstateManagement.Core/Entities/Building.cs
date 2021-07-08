using System.Collections.Generic;

namespace HousingEstateManagement.Core.Entities
{
    public class Building:IEntity   
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public byte TotalFlat { get; set; }

        public List<Flat> Flats { get; set; }
    }
}