using Iatec.EMS.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventDTO> Create(EventDTO eventDTO);
        Task<EventDTO> Update(EventDTO eventDTO);
        Task Remove(long id);
        Task<EventDTO> Get(long id);
        Task<List<EventDTO>> Get();
        Task<EventDTO> GetByName(string name);
        Task<List<EventDTO>> GetByRangeDate(DateTime initialDate, DateTime finalDate);
    }
}
