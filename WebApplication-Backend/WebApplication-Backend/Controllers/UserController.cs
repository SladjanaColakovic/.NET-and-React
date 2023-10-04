using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Backend.DTOs;
using WebApplication_Backend.Model;
using WebApplication_Backend.Services;

namespace WebApplication_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServiceI userService;
        private readonly IConfiguration config;

        public UserController(UserServiceI userService, IConfiguration config) {
            this.userService = userService;
            this.config = config;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll() {
            return Ok(userService.GetAll());
        }

        [HttpGet("{username}")]
        public IActionResult GetByUsername(string username) {
            return Ok(userService.GetByUsername(username));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginDTO userLogin) {
            User user = userService.GetByUsername(userLogin.Username);
            if (user != null) {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials
                    
                );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }

        [HttpGet("current")]
        [Authorize]
        public IActionResult Current() {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null) {
                var claims = identity.Claims;

                var user = new User
                {
                    Username = claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = claims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value,
                    Name = claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value,
                    Surname = claims.FirstOrDefault(u => u.Type == ClaimTypes.Surname)?.Value,
                    Role = claims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value
                };

                return Ok(user);
            }

            return NotFound();
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminFunc() {
            return Ok("Admin Func");
        }

        [HttpGet("seller")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellerFunc()
        {
            return Ok("Seller Func");
        }

        [HttpGet("admin/seller")]
        [Authorize(Roles = "Admin, Seller")]
        public IActionResult AdminSellerFunc()
        {
            return Ok("Admin Seller Func");
        }
    }
}
