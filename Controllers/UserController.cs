namespace UserManagement.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using UserManagement.Applications;
    using UserManagement.Domains.Dtos;
    using UserManagement.Domains.Models;
    using UserManagement.Infrastructures.Log;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogManager _logger;
        private UserServices _userServices;
        private IMapper _mapper;
        public UserController(ILogManager logger, UserServices userServices, IMapper mapper)
        {
            _logger = logger;
            _userServices = userServices;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var listUsers = await _userServices.GetAllUsersAsync();
            _logger.LogInfo("Get all users successfully");

            return Ok(listUsers);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto userDto)
        {
            if (userDto is null)
            {
                throw new InvalidDataException();
            }

            if (!ModelState.IsValid)
            {
                throw new InvalidDataException();
            }

            var user = _mapper.Map<User>(userDto);
            await _userServices.CreateUserAsync(user);

            return Ok();
        }
    }
}