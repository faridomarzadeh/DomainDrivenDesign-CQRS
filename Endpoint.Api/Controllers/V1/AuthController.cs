using Clean_arch.Application.Users.Register;
using Clean_arch.Query.Models.Users;
using Clean_arch.Query.Users.GetByEmail;
using Clean_arch.Query.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Endpoint.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public AuthController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RgisterUser([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("", result);
        }

        [HttpGet]
        public async Task<UserReadModel> GetUser(long id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _mediator.Send(new GetUserByEmailQuery(email));
            if (user == null)
            {
                return NotFound("user not found");
            }
            if (user.PhoneNumber.Phone != password)
            {
                return NotFound("user not found");
            }

            var claims = new List<Claim>()
            {
                new Claim("email",user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Name)
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:SignInKey"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                claims = claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwtToken);
        }
    }
}
