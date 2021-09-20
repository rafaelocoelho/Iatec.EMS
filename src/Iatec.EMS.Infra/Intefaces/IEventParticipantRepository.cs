using Iatec.EMS.Domain.Entities;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Intefaces
{
    public interface IEventParticipantRepository : IBaseRepository<EventParticipant>
    {
        Task<EventParticipant> GetByUserId(long userId);
    }
}
