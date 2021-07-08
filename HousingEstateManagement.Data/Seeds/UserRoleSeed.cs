using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingEstateManagement.Data.Seeds
{
    public class UserRoleSeed : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            string ADMIN_ID = "a21ccc6c-6a3e-4127-af9c-d537d19eb5cc";
            string ADMIN_ROLE_ID = "c188682f-35b7-45ad-87ff-23129d22c008";
         

            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            }
            );
        }
    }
}
