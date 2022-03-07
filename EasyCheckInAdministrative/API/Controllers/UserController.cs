using AutoMapper;
using API.dto;
using Core.DataInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public UserController(IConfiguration configuration ,ILogger<UserController> logger, IAdminRepository adminRepository, IMapper mapper)
        {
            _logger = logger;
            _configuration = configuration;
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(UserDto user)
        {
            var foundUser = await _adminRepository.GetFirstByExpressionAsync(x => x.Username == user.Username);
            var correctPassword = BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password);

            if (foundUser != null && correctPassword)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", foundUser.Id.ToString()),
                    new Claim("UserName", foundUser.Username.ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                 _configuration["Jwt:Audience"],
                                                 claims,
                                                 expires: DateTime.UtcNow.AddDays(1),
                                                 signingCredentials: signIn);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}