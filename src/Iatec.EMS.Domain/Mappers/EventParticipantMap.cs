using Iatec.EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iatec.EMS.Domain.Mappers
{
    public class EventParticipantMap : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.ToTable("ems_eveprt");

            builder.HasKey(x => x.Id)
                   .HasName("pk_ept_id");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("ept_id")
                   .HasColumnType("BIGINT");

            builder.Property(x => x.EventId)
                   .HasColumnName("ept_evt_id")
                   .HasColumnType("BIGINT")
                   .IsRequired();

            builder.HasOne<Event>()
                   .WithMany(x => x.EventParticipants)
                   .HasForeignKey(x => x.EventId)
                   .HasConstraintName("fk_ept_evt")
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .HasColumnName("evt_usr_id")
                   .HasColumnType("BIGINT")
                   .IsRequired();

            builder.HasOne<User>()
                   .WithMany(x => x.EventParticipants)
                   .HasForeignKey(x => x.UserId)
                   .HasConstraintName("fk_ept_usr")
                   .IsRequired();
        }
    }
}
