using Iatec.EMS.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Services.Interfaces
{
    public interface IEventParticipantService
    {
        Task<EventParticipantDTO> Create(EventParticipantDTO eventParticipantDTO);
        Task Remove(long id);
        Task<EventParticipantDTO> Get(long id);
        Task<List<EventParticipantDTO>> Get();
        Task<List<EventParticipantDTO>> GetByUserId(long userId);
    }
}
