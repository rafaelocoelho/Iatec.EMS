using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Infra.Contexts;
using Iatec.EMS.Infra.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Set<User>()
                                 .AsNoTracking()
                                 .Where(x => x.Name == name)
                                 .SingleOrDefaultAsync();
        }

        public async Task<User> GetByNameAndPassword(string name, string password)
        {
            return await _context.Set<User>()
                                 .AsNoTracking()
                                 .Where(x => x.Name == name && x.Password == password)
                                 .SingleOrDefaultAsync();
        }
    }
}
