using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SeedDataModel.Data.Config
{
    public class CorporateConfiguration : IEntityTypeConfiguration<Corporate>
    {
        public void Configure(EntityTypeBuilder<Corporate> builder)
        {
            builder.ToTable("Corporates");
            builder.HasData(SeedData.LoadCorporates());
        }
    }
}
