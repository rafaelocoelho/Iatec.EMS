
using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Infra.Contexts;
using Iatec.EMS.Infra.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Repositories
{
    public class EventParticipantRepository : BaseRepository<EventParticipant>, IEventParticipantRepository
    {
        private readonly ApplicationDbContext _context;

        public EventParticipantRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EventParticipant>> GetByUserId(long userId)
        {
            return await _context.Set<EventParticipant>()
                                 .AsNoTracking()
                                 .Include(x => x.Event)
                                 .Include(x => x.User)
                                 .Where(x => x.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<EventParticipant> GetByUserIdAndEventId(long userId, long eventId)
        {
            return await _context.Set<EventParticipant>()
                                 .AsNoTracking()
                                 .Where(x => x.UserId == userId &&
                                             x.EventId == eventId).FirstOrDefaultAsync();
        }
    }
}
