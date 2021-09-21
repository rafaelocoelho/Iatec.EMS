using AutoMapper;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Domain.Enums;
using Iatec.EMS.Infra.Intefaces;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _repository;

        public EventService(
            IMapper mapper,
            IEventRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EventDTO> Create(EventDTO eventDTO)
        {
            Event eventExists = null;

            if (eventDTO.Type == EventTypeEnum.Exclusive)
                eventExists = await _repository.GetByDateAndType(eventDTO.Date, eventDTO.Type);

            if (eventExists is not null)
                throw new DomainException($"Já existe um evento exclusívo registrado em {eventDTO.Date.Date}");

            Event @event = _mapper.Map<Event>(eventDTO);
            @event.Validate();

            Event eventCreated = await _repository.Create(@event);

            return _mapper.Map<EventDTO>(eventCreated);
        }

        public async Task<EventDTO> Update(EventDTO eventDTO)
        {
            Event eventExists = await _repository.Get(eventDTO.Id);

            if (eventExists is null)
                throw new DomainException("Não existe nunhum evento com o id informado.");

            Event @event = _mapper.Map<Event>(eventDTO);
            @event.Validate();

            Event eventUpdated = await _repository.Update(@event);

            return _mapper.Map<EventDTO>(eventUpdated);
        }

        public async Task Remove(long id)
        {
            Event eventExists = await _repository.Get(id);

            if (eventExists is null)
                throw new DomainException("Não existe nunhum evento com o id informado.");

            await _repository.Remove(id);
        }

        public async Task<EventDTO> Get(long id)
        {
            Event @event = await _repository.Get(id);

            return _mapper.Map<EventDTO>(@event);
        }

        public async Task<List<EventDTO>> Get()
        {
            List<Event> events = await _repository.Get();

            return _mapper.Map<List<EventDTO>>(events);
        }

        public async Task<EventDTO> GetByName(string name)
        {
            Event @event = await _repository.GetByName(name);

            return _mapper.Map<EventDTO>(@event);
        }

        public async Task<List<EventDTO>> GetByRangeDate(DateTime initialDate, DateTime finalDate)
        {
            List<Event> events = await _repository.GetByRangeDate(initialDate, finalDate);

            return _mapper.Map<List<EventDTO>>(events);
        }
    }
}
