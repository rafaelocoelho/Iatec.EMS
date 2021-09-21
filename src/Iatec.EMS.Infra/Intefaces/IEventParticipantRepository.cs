using Iatec.EMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Intefaces
{
    public interface IEventParticipantRepository : IBaseRepository<EventParticipant>
    {
        Task<List<EventParticipant>> GetByUserId(long userId);
        Task<EventParticipant> GetByUserIdAndEventId(long userId, long eventId);
    }
}
