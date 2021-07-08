namespace HousingEstateManagement.Core.Dtos
{
    public class FlatDto
    {
        public int Id { get; set; }
        public byte FlatNumber { get; set; }
        public string TypeOfFlat{ get; set; }
        public bool IsEmpty { get; set; }
        public string UserName { get; set; }
        public string BuildingName{ get; set; }
    }
}