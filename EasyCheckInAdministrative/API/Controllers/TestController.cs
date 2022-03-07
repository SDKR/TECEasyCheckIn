using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Core.DataInterfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public TestController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok("Hello");
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetSomething()
        {
            var departments = await _departmentRepository.GetAllAsync();
            var content = JsonConvert.SerializeObject(departments);
            //return Ok(content);

            if(content != null)
            {
                return Ok("Databasen virker");
            }
            else
            {
                return Ok("Databasen virker ikke");
            }

        }
    }
}
