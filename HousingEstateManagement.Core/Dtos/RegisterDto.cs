using System.ComponentModel.DataAnnotations;

namespace HousingEstateManagement.Core.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        
        public string CarLicensePlate { get; set; }
    }
}