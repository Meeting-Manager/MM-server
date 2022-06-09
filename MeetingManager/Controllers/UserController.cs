using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        ILogger logger;
        IMapper mapper;
        public UserController(IUserBL userBL, ILogger<UserController> logger, IMapper mapper)
        {
            this.logger = logger;
            this.userBL = userBL;
            this.mapper = mapper;
        }
        
        [HttpPost("Login")]
        [AllowAnonymous]

        public async Task<ActionResult<User>> Login([FromBody] UserLoginDTO user)
        {
            logger.LogInformation("userName:" + user.Name + "  password:" + user.Password);
            User u = await userBL.Login(user.Name, user.Password, user.CustomerName);
            if (u == null)
                return NoContent();
            else
                return Ok(u);
        }
        [AllowAnonymous]

        // GET api/<UserController>/5
        [HttpGet("{customerId}")]
        public async Task<List<UserDTO>> Get(int customerId)
        {
            List<User> users = await userBL.GetByCustomerId(customerId);
            List<UserDTO> usersDTO = mapper.Map<List<User>, List<UserDTO>>(users);
            return usersDTO;
        }

        [AllowAnonymous]

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await userBL.UserPost(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User user)
        {
            await userBL.UserPut(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await userBL.userDelete(id);
        }
    }
}
