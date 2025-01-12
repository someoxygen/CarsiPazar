using AutoMapper;
using CarsiPazarAPI.Data;
using CarsiPazarAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarsiPazarAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IAppRepository _appRepository;
        IMapper _mapper;
        public UserController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getUserById")]
        public ActionResult GetUserById(int id)
        {
            var user = _appRepository.GetUserById(id);
            var userToReturn = _mapper.Map<UserForReturnDto>(user);
            return Ok(userToReturn);
        }
    }
}
