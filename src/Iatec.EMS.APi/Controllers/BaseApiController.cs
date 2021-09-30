using AutoMapper;
using Iatec.EMS.Token.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Iatec.EMS.Api.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ITokenProvider _tokenProvider;
        protected const string _version = "api/v1/";

        public BaseApiController(
            IMapper mapper,
            ITokenProvider tokenProvider)
        {
            _mapper = mapper;
            _tokenProvider = tokenProvider;
        }

        public BaseApiController(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        public BaseApiController()
        {
        }

        protected string GetValueUserPropertyByType(string claimType)
        {
            return HttpContext?.User?.Claims.FirstOrDefault(claim => claim.Type == claimType)?.Value;
        }
    }
}
