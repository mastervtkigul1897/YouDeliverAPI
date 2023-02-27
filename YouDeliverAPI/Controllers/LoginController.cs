using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YouDeliverAPI.Models;

namespace YouDeliverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly YoudeliverdbContext _context;
        public static int userId = 0;


        public LoginController(IConfiguration config, YoudeliverdbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tlogin user)
        {
            string hash = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(user.Password))).Replace("-", "").ToLower();

            if (user != null && user.Email != null && user.Password != null)
            {
                var userinfo = await _context.TUsers
                .Select(c => new {
                    userId = c.UserId,
                    loginId = c.Email,
                    loginPw = c.Password,
                }).FirstOrDefaultAsync(u => u.loginId == user.Email && u.loginPw == user.Password);

                if (userinfo != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", userinfo.userId.ToString())
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(accessToken);
                    var tokenS = jsonToken as JwtSecurityToken;

                    userId = int.Parse(tokenS.Claims.First(claim => claim.Type == "UserId").Value);

                    return Ok(new
                    {
                        accessToken, userId, status = "Ok"
                    });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
