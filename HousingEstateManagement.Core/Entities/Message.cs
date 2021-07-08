namespace HousingEstateManagement.Core.Entities
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}