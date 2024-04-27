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
    public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.ToTable("Individuals");
            //builder.HasData(SeedData.LoadIndividuals());
        }
    }
}
