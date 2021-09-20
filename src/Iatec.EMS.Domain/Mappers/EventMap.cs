using Iatec.EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iatec.EMS.Domain.Mappers
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("ems_event");

            builder.HasKey(x => x.Id)
                   .HasName("pk_evt_id");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("evt_id")
                   .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                   .HasColumnName("evt_name")
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasColumnName("evt_descri")
                   .HasColumnType("VARCHAR(240)")
                   .IsRequired();

            builder.Property(x => x.Date)
                   .HasColumnName("evt_date")
                   .HasColumnType("DATE")
                   .IsRequired();

            builder.Property(x => x.Local)
                   .HasColumnName("evt_local")
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.Property(x => x.Type)
                   .HasColumnName("evt_type")
                   .HasColumnType("SMALLINT")
                   .IsRequired();
        }
    }
}
