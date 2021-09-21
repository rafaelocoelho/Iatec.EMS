using AutoMapper;
using Iatec.EMS.Api.Utilitis;
using Iatec.EMS.Api.ViewModels;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Api.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        protected readonly IMapper _mapper;
        private readonly IEventService _service;

        public EventController(
            IMapper mapper, 
            IEventService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("/api/events/create")]
        public async Task<IActionResult> Create([FromBody] CreateEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                EventDTO eventDTO = _mapper.Map<EventDTO>(viewModel);
                EventDTO eventCreated = await _service.Create(eventDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Evento criado com sucesso!",
                    Success = true,
                    Data = eventCreated
                });
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErroMessage(exception.Message, exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut("/api/events/update")]
        public async Task<IActionResult> Update([FromBody] UpdateEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                EventDTO eventDTO = _mapper.Map<EventDTO>(viewModel);
                EventDTO eventUpdated = await _service.Update(eventDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Evento atualizado com sucesso!",
                    Success = true,
                    Data = eventUpdated
                });
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErroMessage(exception.Message, exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete("/api/events/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _service.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Evento removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErroMessage(exception.Message, exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet("/api/events/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                EventDTO eventDTO = await _service.Get(id);

                if (eventDTO is null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum evento foi encontrado com o id informado!",
                        Success = false,
                        Data = eventDTO
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Evento encontrado com sucesso!",
                    Success = true,
                    Data = eventDTO
                });
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErroMessage(exception.Message, exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet("/api/events")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<EventDTO> eventsDTO = await _service.Get();

                if (eventsDTO is null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum evento foi encontrado!",
                        Success = false,
                        Data = eventsDTO
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Eventos encontratos com sucesso!",
                    Success = true,
                    Data = eventsDTO
                });
            }
            catch (DomainException exception)
            {
                return BadRequest(Responses.DomainErroMessage(exception.Message, exception.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
