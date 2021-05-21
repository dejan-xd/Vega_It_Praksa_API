using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VegaITPraksa.Data;
using VegaITPraksa.DTO;
using VegaITPraksa.Models;

namespace VegaITPraksa.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {

        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("")]
        public IActionResult GetUsers()
        {
            var users = _dataContext.Users.ToList();
            return Json(users);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            //var newUser = new TeamMember {Id = user.Id, Name = user.Name };
            //await _dataContext.Users.AddAsync(newUser);
            //await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
