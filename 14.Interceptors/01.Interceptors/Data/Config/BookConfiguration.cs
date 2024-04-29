using C01.BasicSaveWithTracking.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF018.ChangeTracking.Data.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(b => b.Author)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.IsDeleted)
                .IsRequired();

            //builder.HasQueryFilter(b => b.IsDeleted == false);

            builder.ToTable("Books");
        }
    }
}
