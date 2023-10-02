using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Backend.Services;

namespace WebApplication_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServiceI userService;

        public UserController(UserServiceI userService) {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(userService.GetAll());
        }

        [HttpGet("{username}")]
        public IActionResult GetByUsername(string username) {
            return Ok(userService.GetByUsername(username));
        }
    }
}
