using HousingEstateManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HousingEstateManagement.Data.Configurations
{
    public class FlatConfiguration:IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {

            builder.HasOne<User>(b => b.User)
                .WithMany(u => u.Flats)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne<Building>(b => b.Building)
                .WithMany(u => u.Flats)
                .HasForeignKey(b => b.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}