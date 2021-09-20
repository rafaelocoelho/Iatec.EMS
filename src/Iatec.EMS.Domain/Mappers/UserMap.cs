using Iatec.EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iatec.EMS.Domain.Mappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("ems_user");

            builder.HasKey(x => x.Id)
                   .HasName("pk_usr_id");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("usr_id")
                   .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                   .HasColumnName("usr_name")
                   .HasColumnType("VARCHAR(150)")
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnName("usr_email")
                   .HasColumnType("VARCHAR(180)")
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnName("usr_passwd")
                   .HasColumnType("VARCHAR(10)")
                   .IsRequired();

            builder.Property(x => x.Birthday)
                   .HasColumnName("usr_birthd")
                   .HasColumnType("DATE")
                   .IsRequired();

            builder.Property(x => x.Gender)
                   .HasColumnName("usr_gender")
                   .HasColumnType("BOOL")
                   .IsRequired();
        }
    }
}
