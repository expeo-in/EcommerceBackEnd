using EcommerceBackEnd.Data;
using EcommerceBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly EcommerceDbContext dbContext;

        public AdminController(EcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<UserAuthenticateResponse> Authenticate(UserAuthenticateRequest user)
        {
            UserAuthenticateResponse response = new UserAuthenticateResponse();

            var entity = dbContext.Users.FirstOrDefault(p => p.Email == user.Email && p.Password == user.Password);

            if (entity != null)
            {
                response.Email = user.Email;
                response.Token = GenerateJwtToken("1");
                response.Role = "admin";
                return response;
            }
            else
                return Unauthorized();
        }

        private string GenerateJwtToken(string id)
        {
            string secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";

            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //new Claim(ClaimTypes.Name, user.Id.ToString())
                Subject = new ClaimsIdentity(new[] { new Claim("id", id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
