using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iatec.EMS.Api.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected const string _version = "api/v1/";

        public BaseApiController(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        public BaseApiController()
        {
        }
    }
}
