using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DictoData.Model;
using DictoInfrasctructure.Core;
using DictoInfrasctructure.Dtos;
using DictoServices.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog.Events;

namespace DictoWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : CoreController<LoginController>
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IOptions<AzureAdB2COptions> _options;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public LoginController(IOptions<AzureAdB2COptions> options, IAccountService accontService, IMapper mapper, ILogger<LoginController> logger)
            :base(logger)
        {
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            _options = options;
            _accountService = accontService;
            _mapper = mapper;
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public IActionResult SighUp([FromBody] UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<UserDto, User>(userDto);
                user = _accountService.Create(user,user.Password);
                return new OkObjectResult(userDto);
            }
            catch (Exception e)
            {
                Log(e.ToString());
                return BadRequest(e);
            }
        } 


        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token([FromBody]UserDto user)
        {
            var identity = await GetClaimsIdentity(user);
            if (identity == null)
            {
                return new BadRequestObjectResult($"There is no user with name {user.Email}");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                identity.FindFirst("Administrator")
            };
            var jwt = new JwtSecurityToken(
                issuer: _options.Value.ClientId,
                audience: _options.Value.ClientId,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_options.Value.Expires),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Serialize and return the response
            var response = new
            {
                user = user.Email,
                token = encodedJwt,
                expiration = jwt.ValidTo
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }


        private async Task<ClaimsIdentity> GetClaimsIdentity(UserDto user)
        {
            var dbUser = _mapper.Map<User>(user);
            var u = await _accountService.Authenticate(dbUser.Email,user.Password);
            
            if (u != null)
            {
                return new ClaimsIdentity(new GenericIdentity(user.Email, "Token"),
                    new Claim[]
                    {
                        new Claim("Administrator",String.Empty)
                    }
                );
            }
            return null;
        }
    }
}