using AutoMapper;
using Iatec.EMS.Api.Utilitis;
using Iatec.EMS.Api.ViewModels;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iatec.EMS.Api.Controllers
{
    [Route(_version + "users")]
    public class UserController : BaseApiController
    {
        #region Properties
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UserController(
            IMapper mapper,
            IUserService userService) : base (mapper)
        {
            _userService = userService;
        }
        #endregion

        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(viewModel);
                UserDTO userCreated = await _userService.Create(userDTO);

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
            catch (Exception error)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPatch("update")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(viewModel);
                UserDTO userUpdated = await _userService.Update(userDTO);

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

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);

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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                UserDTO userDTO = await _userService.Get(id);

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

        [HttpGet]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<UserDTO> usersDTO = await _userService.Get();

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
