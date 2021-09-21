using Iatec.EMS.Domain.Enums;
using System;

namespace Iatec.EMS.Services.DTOs
{
    public class EventDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Local { get; set; }
        public EventTypeEnum Type { get; set; }

        public EventDTO() { }

        public EventDTO(long id, string name, string description, DateTime date, string local, EventTypeEnum type)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Local = local;
            Type = type;
        }
    }
}
