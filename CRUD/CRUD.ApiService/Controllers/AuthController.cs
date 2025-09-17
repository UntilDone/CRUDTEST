using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD.Model.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace CRUD.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult<LoginResponseModel> Login([FromBody] LoginModel loginModel)
        {
            if(loginModel.Username == "Admin" && loginModel.Passwword == "Admin")
            {
                var token = GenerateJwtToken(loginModel.Username);
                return Ok(new LoginResponseModel { Token = token });
            }
            return null;
        }
        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,"Admin")
            };
            string secret = configuration.GetValue<string>("Jwt:Secret");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "doseHieu",
                audience: "doseHieu",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), 
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
    }
}
