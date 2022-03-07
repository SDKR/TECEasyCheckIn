using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using API.dto;
using Core.DataInterfaces;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    //[Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDailySettingsRepository _dailySettingsRepository;
        private readonly IInstructorRepository _instructorRepository;

        public DepartmentsController(ILogger<DepartmentsController> logger,
                                 IMapper mapper,
                                 IDepartmentRepository departmentRepository,
                                 IDailySettingsRepository dailySettingsRepository,
                                 IInstructorRepository instructorRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _dailySettingsRepository = dailySettingsRepository;
            _instructorRepository = instructorRepository;
        }


        [HttpGet(Name = "GetAllDepartments")]
        public async Task<IActionResult> GetAll()
        {
            var allDepartments = await _departmentRepository.GetAllAsync();

            return Ok(allDepartments);
        }

        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var foundDepartment = await _departmentRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (foundDepartment == null)
            {
                return NotFound();
            }

            return Ok(foundDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne([FromBody] Department department)
        {

            //var departmentToAdd = _mapper.Map<Department>(department);
            Department departmentToAdd = new Department();
            departmentToAdd.Name = department.Name;
            departmentToAdd.Id = Guid.NewGuid();

            var allDepartments = await _departmentRepository.GetAllAsync();

            if(!allDepartments.Any(depart => depart.Name.ToLower() == department.Name.ToLower()))
            {
                _departmentRepository.Create(departmentToAdd);

                if (!await _departmentRepository.SaveAsync())
                {
                    _logger.LogError("Failed to create department");
                }

                _dailySettingsRepository.CreateDefaultsForDepartment(departmentToAdd.Id);
                if (!await _dailySettingsRepository.SaveAsync())
                {
                    _logger.LogError("Failed to create default dailysettings for department");
                }

                _instructorRepository.CreateNoneInstructorForDepartment(departmentToAdd.Id);
                if (!await _instructorRepository.SaveAsync())
                {
                    _logger.LogError("Failed to create 'none' instructor for department");
                }
                departmentToAdd.Instructors = null;
                return Ok(departmentToAdd);
            }
            else
            {
                return Conflict();
            }           
            return null;
        }

        [HttpPut("{id}", Name = "UpdateDepartment")]
        public async Task<IActionResult> UpdateOne([FromBody] Department department, [FromRoute] Guid id)
        {
            var departmentFromDb = await _departmentRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (departmentFromDb == null)
            {
                return NotFound();
            }

            var allDepartments = await _departmentRepository.GetAllAsync();

            if (!allDepartments.Any(depart => depart.Name.ToLower() == department.Name.ToLower()))
            {
                var bod = departmentFromDb;
                bod.Name = department.Name;
                _departmentRepository.Update(bod);

                if (!await _departmentRepository.SaveAsync())
                {
                    _logger.LogError("Failed to update departmentcheckin");
                }
                return Ok(bod);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpDelete("{id}", Name = "DeleteDepartment")]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            var foundDepartment = await _departmentRepository.GetFirstByExpressionAsync(x => x.Id == id);
            if (foundDepartment == null)
            {
                return NotFound();
            }

            _departmentRepository.Delete(foundDepartment);

            if (!await _departmentRepository.SaveAsync())
            {
                _logger.LogError("Failed to delete department");
            }

            return Ok(foundDepartment);
        }
    }
}