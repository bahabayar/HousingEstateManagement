using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HousingEstateManagement.Core.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string UserName { get; set; }
        public List<UserDto> Users { get; set; }
    }
}