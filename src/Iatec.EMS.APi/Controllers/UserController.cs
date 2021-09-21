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
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        protected readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserController(
            IMapper mapper,
            IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("/api/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(viewModel);
                UserDTO userCreated = await _service.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = userCreated
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

        [HttpPut("/api/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(viewModel);
                UserDTO userUpdated = await _service.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = userUpdated
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

        [HttpDelete("/api/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _service.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
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

        [HttpGet("/api/users/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                UserDTO userDTO = await _service.Get(id);

                if (userDTO is null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o id informado!",
                        Success = false,
                        Data = userDTO
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = userDTO
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

        [HttpGet("/api/users")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<UserDTO> usersDTO = await _service.Get();

                if (usersDTO is null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado!",
                        Success = false,
                        Data = usersDTO
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontratos com sucesso!",
                    Success = true,
                    Data = usersDTO
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
