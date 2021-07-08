using System.Collections.Generic;

namespace HousingEstateManagement.Core.Dtos
{
    public class FlatUpdateDto
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public bool IsEmpty { get; set; }
        public string TypeOfFlat{ get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }
        
        //------------------------------------------------
        public IEnumerable<BuildingDto> Building { get; set; } //id
        public IEnumerable<UserDto> Users { get; set; }//id
    }
}