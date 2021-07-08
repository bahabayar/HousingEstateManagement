namespace HousingEstateManagement.Core.Entities
{
    public class Announcement:IEntity
    {
        public int Id { get; set; }
        public string AnnouncementText { get; set; }
    }
}