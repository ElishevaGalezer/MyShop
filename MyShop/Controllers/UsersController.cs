using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PresidentsApp.Middlewares;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        IUserService _userService ;
        IMapper _mapper;
        ILogger<UsersController> _logger;
        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost("Login")]
        public async Task <ActionResult> Login([FromQuery] string UserName, [FromQuery] string Password)
        {
         User user =await _userService.Login(UserName, Password);
            UserDTO userDTO = _mapper.Map<User,UserDTO>(user);
            if (user != null) {
                _logger.LogInformation($"user {user.Id} enter to the aplication");
                return Ok(userDTO);
            }
            return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]

        public async Task<ActionResult> Post([FromBody] PostUserDTO postUserDTO)
        { 
        
            User user = _mapper.Map<PostUserDTO,User>(postUserDTO);
             int score = Password(user.Password);
                if (score <= 2)
                    return BadRequest();
            user =await _userService.Post(user);
            if (user == null)
               return BadRequest();
               
                
                UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, userDTO);
            
            
           
        }

        [HttpPost("Password")]

        public int Password([FromBody] string password)
        {
          int score = _userService.Password(password);
            return score;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostUserDTO userToUpdateDTO)

        {

            User user = _mapper.Map<PostUserDTO, User>(userToUpdateDTO);

            int score = Password(user.Password);
            if (score <= 2)
                return BadRequest();
            
            await _userService.Put(id, user);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);

            return Ok(userDTO);
 
        }
    }
}
