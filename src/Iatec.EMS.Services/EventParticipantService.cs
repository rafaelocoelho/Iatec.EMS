using AutoMapper;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Domain.Entities;
using Iatec.EMS.Infra.Intefaces;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Services
{
    public class EventParticipantService : IEventParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IEventParticipantRepository _repository;

        public EventParticipantService(
            IMapper mapper,
            IEventParticipantRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<EventParticipantDTO> Create(EventParticipantDTO eventParticipantDTO)
        {
            EventParticipant participantExists = await _repository.GetByUserIdAndEventId(eventParticipantDTO.UserId, eventParticipantDTO.EventId);

            if (participantExists is not null)
                throw new DomainException("Esse usuário já está participando desse evento");

            EventParticipant eventParticipant = _mapper.Map<EventParticipant>(eventParticipantDTO);
            eventParticipant.Validate();

            EventParticipant participantIncluded = await _repository.Create(eventParticipant);

            return _mapper.Map<EventParticipantDTO>(participantIncluded);
        }

        public async Task Remove(long id)
        {
            EventParticipant participantExists = await _repository.Get(id);

            if (participantExists is null)
                throw new DomainException("Não foi encontrado usuário participando desse evento com esse id.");

            await _repository.Remove(id);
        }

        public async Task<EventParticipantDTO> Get(long id)
        {
            EventParticipant eventParticipant = await _repository.Get(id);

            return _mapper.Map<EventParticipantDTO>(eventParticipant);
        }

        public async Task<List<EventParticipantDTO>> Get()
        {
            List<EventParticipant> events = await _repository.Get();

            return _mapper.Map<List<EventParticipantDTO>>(events);
        }

        public async Task<List<EventParticipantDTO>> GetByUserId(long id)
        {
            List<EventParticipant> events = await _repository.GetByUserId(id);

            return _mapper.Map<List<EventParticipantDTO>>(events);
        }
    }
}
