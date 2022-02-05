using BookRentalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //1 Depedency Injection Configuration
        private readonly IConfiguration _config;

        //2 Constructor Injection 
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        //3 HTTP Post Method 
        [HttpPost("token")]
        public IActionResult Login([FromBody] Customers user)
        {
            //Checking authentication
            IActionResult response = Unauthorized();

            //Authenticate the user
            var loginUser = AuthenticateUser(user);

            //Validate the user and generate token 
            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });
            }
            //return Ok("Hello from API");
            return response;
        }

        //4 Authenticate User
        private Customers AuthenticateUser(Customers user)
        {
            Customers loginUser = null;

            //validate the user redentials
            if (user.CName == "AAA")
            {
                loginUser = new Customers
                {
                    CName = user.CName
                };
            }
            return loginUser;
        }

        //5 Generate JWT Token 
        private string GenerateJWToken(Customers loginUser)
        {
            //security key 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // singning credentials 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // claims -- Roles

            //GEnerate token 
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
