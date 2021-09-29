using AutoMapper;
using Iatec.EMS.Api.Utilitis;
using Iatec.EMS.Api.ViewModels;
using Iatec.EMS.Core.Exceptions;
using Iatec.EMS.Services.DTOs;
using Iatec.EMS.Services.Interfaces;
using Iatec.EMS.Token.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Iatec.EMS.Api.Controllers
{
    [Route(_version + "auth")]
    public class AuthenticateController : BaseApiController
    {
        #region Properties
        private readonly IUserService _userService;
        private readonly ITokenProvider _tokenProvider;
        #endregion

        #region Constructor
        public AuthenticateController(
            IMapper mapper,
            ITokenProvider tokenProvider,
            IUserService userService) : base(mapper)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
        }
        #endregion

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(Responses.ApplicationErrorMessage("Parâmetros inválidos!"));

            try
            {
                var userDTO = _mapper.Map<UserDTO>(viewModel);
                var userLoged = await _userService.GetByEmailAndPassword(userDTO.Email, userDTO.Password);

                if (userLoged is not null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenProvider.TokenGernerate(userLoged)
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnautorizedErrorMessage());
                }
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
