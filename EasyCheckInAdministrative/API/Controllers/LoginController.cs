using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DataInterfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IMapper _mapper;
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILogger<LoginController> logger,
                                 IMapper mapper,
                                 ILoginRepository loginRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _loginRepository = loginRepository;
        }

        //[HttpGet(Name = "GetIntructorList")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var allInstructors = await _loginRepository.GetAllAsync();

        //    return Ok(allInstructors);
        //}

        [HttpPost("Login", Name = "Login")]
        public async Task<IActionResult> Login([FromBody] Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Model State Invalid");
            }

            //var checkInstructor = await _loginRepository.GetFirstByExpressionAsync(x => x.Initials == instructor.Initials && x.Password == instructor.Password);
            var checkInstructor = await _loginRepository.LoginCheck(instructor);

            if(checkInstructor == null)
            {
                return NotFound();
            }

            return Ok(checkInstructor);
        }



    }
}
