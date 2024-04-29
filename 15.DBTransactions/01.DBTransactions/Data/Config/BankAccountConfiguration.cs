using _01.DBTransactions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF018.ChangeTracking.Data.Config
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x => x.AccountId);
            builder.Property(x => x.AccountId).ValueGeneratedNever();

            builder.Property(x => x.AccountHolder)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20).IsRequired();

            builder.Property(x => x.CurrentBalance).HasColumnType("decimal(18, 2)").IsRequired();

            builder.HasMany(b => b.GLTransactions).WithOne();

            builder.ToTable("BankAccounts");
        }
    }
}
