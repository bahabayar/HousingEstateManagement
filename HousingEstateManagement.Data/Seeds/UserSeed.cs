using HousingEstateManagement.Core.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagement.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        string ADMIN_ID = "a21ccc6c-6a3e-4127-af9c-d537d19eb5cc";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var appUser = new User()
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                IdentificationNumber = "532515412352",
                NormalizedEmail = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName="ADMIN"
            };
          
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "admin123");

          
            builder.HasData(appUser);
        }
    }
}
