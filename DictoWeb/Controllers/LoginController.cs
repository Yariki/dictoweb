using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DictoDtos.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DictoWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IOptions<AzureAdB2COptions> _options;

        public LoginController(IOptions<AzureAdB2COptions> options)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            _options = options;
        }

        // GET
        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token([FromBody]UserDto user)
        {
            var identity = await GetClaimsIdentity(user);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                identity.FindFirst("Administrator")
            };
            var jwt = new JwtSecurityToken(
                issuer: _options.Value.Domain,
                audience: _options.Value.Domain,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.Value.Expires),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Serialize and return the response
            var response = new
            {
                token = encodedJwt,
                expiration = jwt.ValidTo
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }


        private static Task<ClaimsIdentity> GetClaimsIdentity(UserDto user)
        {
            if (user.Email == "user" && user.Password == "password")
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.Email, "Token"),
                    new Claim[]
                    {
                        new Claim("Administrator",String.Empty)
                    }
                ));
            }
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}