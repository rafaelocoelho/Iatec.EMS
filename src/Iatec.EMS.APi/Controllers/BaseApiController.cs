using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Iatec.EMS.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseApiController() { }

        public BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
