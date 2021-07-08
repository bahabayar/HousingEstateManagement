using HousingEstateManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingEstateManagement.Data.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {

     
        string ADMIN_ROLE_ID = "c188682f-35b7-45ad-87ff-23129d22c008";
        string RESIDENT_ROLE_ID = "eb8156ac-bbfc-483e-9358-cf14d762bbd3";
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID

                },
                new IdentityRole 
                {
                    Name = "Resident",
                    NormalizedName= "Resident",
                    Id=RESIDENT_ROLE_ID,
                    ConcurrencyStamp=RESIDENT_ROLE_ID
                });
        }
    }
}
