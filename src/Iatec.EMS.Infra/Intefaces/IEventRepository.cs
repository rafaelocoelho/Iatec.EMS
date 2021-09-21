using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Infra.Intefaces
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<Event> GetByName(string name);
        Task<List<Event>> GetByRangeDate(DateTime initialDate, DateTime finalDate);
        Task<Event> GetByDateAndType(DateTime date, EventTypeEnum type);
    }
}
