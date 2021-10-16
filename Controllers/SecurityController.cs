using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth_Jwt_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("LlavedeSeguridad"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Issuer", "Shiv"),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, username)
            };

            var token = new JwtSecurityToken("Shiv",
                "Shiv",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        // GET: api/<SecurityController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return GenerateJSONWebToken("danielv");
        //}

        // GET api/<SecurityController>/5
        [HttpGet]
        public string Get()
        {
            return GenerateJSONWebToken("danielv");
        }

        // POST api/<SecurityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SecurityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
