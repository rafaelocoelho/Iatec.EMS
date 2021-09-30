using Iatec.EMS.Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Iatec.EMS.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventDTO> Create(EventDTO eventDTO, long userId);
        Task<EventDTO> Update(EventDTO eventDTO);
        Task Remove(long id);
        Task<EventDTO> Get(long id);
        Task<List<EventDTO>> Get();
        Task<EventDTO> GetByName(string name);
        Task<List<EventDTO>> Search(DateTime initialDate, DateTime finalDate);
    }
}
