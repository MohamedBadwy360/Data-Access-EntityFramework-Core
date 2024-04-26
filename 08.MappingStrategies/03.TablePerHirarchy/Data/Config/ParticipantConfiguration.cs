using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.Property(s => s.FirstName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasDiscriminator<string>("PraticipantType")
                .HasValue<Individual>("INDV")
                .HasValue<Coporate>("COPR");

            builder.Property("PraticipantType")
                .HasColumnType("VARCHAR")
                .HasMaxLength(4);

            builder.ToTable("Participants");

        }
    }
}
