using System;

namespace HousingEstateManagement.Core.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarLicensePlate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}