using Iatec.EMS.Domain.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Iatec.EMS.Infra.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EventParticipantMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
