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
    public class ExpenseTypeSeed:IEntityTypeConfiguration<ExpenseType>
    {
  

        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.HasData(
                new ExpenseType { Id = 1, ExpenseTypeName = "Elektrik" },
                new ExpenseType { Id = 2, ExpenseTypeName = "Su" },
                new ExpenseType { Id = 3, ExpenseTypeName = "Doğalgaz" },
                new ExpenseType { Id = 4, ExpenseTypeName = "İnternet" },
                new ExpenseType { Id = 5, ExpenseTypeName = "Apsiyon" }

            );
        }



    }
}
