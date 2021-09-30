using AutoMapper;
using Iatec.EMS.Api.Utilitis;
using Iatec.EMS.Api.ViewModels;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using Iatec.EMS.Token.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Iatec.EMS.Api.Controllers
{
    [Route(_version + "events")]
    public class EventController : BaseApiController
    {
        #region Properties
        private readonly IEventService _eventService;
        private readonly IEventParticipantService _eventParticipantService;
        private readonly IUserService _userService;
        
        #endregion

        #region Constructor
        public EventController(
            IMapper mapper,
            ITokenProvider tokenProvider,
            IEventService eventService,
            IEventParticipantService eventParticipantService,
            IUserService userService)
            : base (mapper, tokenProvider)
        {
            _eventService = eventService;
            _eventParticipantService = eventParticipantService;
            _userService = userService;
        }
        #endregion

        [HttpPost("create")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                var userId = GetValueUserPropertyByType(ClaimTypes.NameIdentifier);

                EventDTO eventDTO = _mapper.Map<EventDTO>(viewModel);
                EventDTO eventCreated = await _eventService.Create(eventDTO, Convert.ToInt32(userId));

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

        [HttpPut("update")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                EventDTO eventDTO = _mapper.Map<EventDTO>(viewModel);
                EventDTO eventUpdated = await _eventService.Update(eventDTO);

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

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _eventService.Remove(id);

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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                EventDTO eventDTO = await _eventService.Get(id);

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

        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<EventDTO> eventsDTO = await _eventService.Get();

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

        [HttpGet("search")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromBody] SearchEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                DateTime initialDate = Convert.ToDateTime(viewModel?.InitialDate);
                DateTime finalDate = Convert.ToDateTime(viewModel?.FinalDate);
                string name = viewModel?.Name;

                List<EventDTO> eventsDTO = await _eventService.Search(initialDate, finalDate);

                if (eventsDTO?.Count() < 1)
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
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage(ex.Message));
            }
        }
    }
}
