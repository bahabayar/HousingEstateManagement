using HousingEstateManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagement.Data.Seeds
{
    public class BuildingSeed : IEntityTypeConfiguration<Building>
    {
   
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasData(
                new Building {Id=1, BuildingName="A",TotalFlat=20},
                new Building {Id=2, BuildingName="B",TotalFlat=20},
                new Building {Id=3, BuildingName="C" , TotalFlat = 20 },
                new Building {Id=4, BuildingName="D" ,TotalFlat=20}
                
                );
        }
    }
}
