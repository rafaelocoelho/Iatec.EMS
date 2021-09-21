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

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Set<User>()
                                 .AsNoTracking()
                                 .Where(x => x.Email == email)
                                 .FirstOrDefaultAsync();
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Set<User>()
                                 .AsNoTracking()
                                 .Where(x => x.Email == email && 
                                             x.Password == password).FirstOrDefaultAsync();
        }
    }
}
