using _04.CallingDbViews.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CallingDbViews.Data.Config
{
    public class CourseOverviewConfiguration : IEntityTypeConfiguration<CourseOverview>
    {
        public void Configure(EntityTypeBuilder<CourseOverview> builder)
        {
            builder.HasNoKey();
            builder.ToView("CourseOverview");
        }
    }
}
