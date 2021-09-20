using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Domain.Enums;
using Iatec.EMS.Infra.Contexts;
using Iatec.EMS.Infra.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Event> GetByName(string name)
        {
            return await _context.Set<Event>()
                                 .AsNoTracking()
                                 .Where(x => x.Name == name)
                                 .SingleOrDefaultAsync();
        }

        public async Task<Event> GetByType(EventTypeEnum type)
        {
            return await _context.Set<Event>()
                                 .AsNoTracking()
                                 .Where(x => x.Type == type)
                                 .SingleOrDefaultAsync();
        }

        public async Task<Event> GetByDateAndType(DateTime date, EventTypeEnum type)
        {
            return await _context.Set<Event>()
                    .AsNoTracking()
                    .Where(x => x.Date == date && x.Type == type)
                    .SingleOrDefaultAsync();
        }
    }
}
