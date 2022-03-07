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
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    //[Authorize]
    public class InstructorsController : ControllerBase
    {
        private readonly ILogger<InstructorsController> _logger;
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;

        public InstructorsController(ILogger<InstructorsController> logger,
                                 IMapper mapper,
                                 IInstructorRepository instructorRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _instructorRepository = instructorRepository;
        }


        [HttpGet(Name = "GetAllInstructors")]
        public async Task<IActionResult> GetAll()
        {
            var allInstructors = await _instructorRepository.GetAllAsync();

            return Ok(allInstructors);
        }

        [HttpGet("byDepartment/{departmentName}",Name = "GetAllInstructorsForDepartment")]
        public async Task<IActionResult> GetAllForDepartment([FromRoute] string departmentName)
        {
            var allInstructors = await _instructorRepository.GetAllByDepartmentNameAsync(departmentName);

            return Ok(allInstructors);
        }

        [HttpGet("{id}", Name = "GetInstructor")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var foundInstructor = await _instructorRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (foundInstructor == null)
            {
                return NotFound();
            }

            return Ok(foundInstructor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne([FromBody] InstructorDto instructor)
        {

            var instructorToAdd = _mapper.Map<Instructor>(instructor);
            instructorToAdd.Id = Guid.NewGuid();

            _instructorRepository.Create(instructorToAdd);

            if (!await _instructorRepository.SaveAsync())
            {
                _logger.LogError("Failed to create instructor");
            }

            return Ok(instructorToAdd);

        }

        [HttpPost("bulkinsert", Name = "CreateManyInstructors")]
        public async Task<IActionResult> CreateMany([FromBody] List<InstructorDto> instructors)
        {
            List<List<Instructor>> listsToReturn = new List<List<Instructor>>();
            List<Instructor> instructorsCreated = new List<Instructor>();
            List<Instructor> instructorsExists = new List<Instructor>();

            //instructors[0].DepartmentId = new Guid ("3B097E5E-AF52-48A6-8D19-764C20D84F3B");

            //Check for duplicates
            var allInstructors = await _instructorRepository.GetAllAsync();
            //
            foreach (var instructor in instructors)
            {

                if (!allInstructors.Any(ins => ins.Initials.ToLower() == instructor.Initials.ToLower()))
                {
                    var instructorToAdd = _mapper.Map<Instructor>(instructor);
                    instructorToAdd.Id = Guid.NewGuid();
                    _instructorRepository.Create(instructorToAdd);
                    instructorsCreated.Add(instructorToAdd);
                }
                else
                {
                    return Conflict();
                }
            }

            if (!await _instructorRepository.SaveAsync())
            {
                _logger.LogError("Failed to create students from list");
            }

            // add both lists to nested return list
            listsToReturn.Add(instructorsCreated);
            listsToReturn.Add(instructorsExists);

            return Ok(listsToReturn);
        }

        [HttpPost("Update", Name = "UpdateInstructor")]
        public async Task<IActionResult> UpdateOne([FromBody] InstructorDto instructor)
        {
            var instructorFromDb = await _instructorRepository.GetFirstByExpressionAsync(x => x.Id == instructor.Id);

            if (instructorFromDb == null)
            {
                return NotFound();
            }

            if (instructorFromDb.Password == instructor.Password)
            { 
                var allInstructors = await _instructorRepository.GetAllAsync();
                if (allInstructors.Any(ins => ins.Initials.ToLower() == instructor.Initials.ToLower() && instructor.Id != ins.Id))
                {
                    return Conflict();
                }
            }

            var bod = _mapper.Map(instructor, instructorFromDb);
            _instructorRepository.Update(bod);

            if (!await _instructorRepository.SaveAsync())
            {
                _logger.LogError("Failed to update instructor");
            }

            return Ok(bod);
        }

        [HttpDelete("Delete/{id}", Name = "DeleteInstructor")]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            var foundInstructor = await _instructorRepository.GetFirstByExpressionAsync(x => x.Id == id);
            if (foundInstructor == null)
            {
                return NotFound();
            }

            // Re-instructor students with deleted instructor
            await _instructorRepository.ChangeToDefaultInstructor(id);

            _instructorRepository.Delete(foundInstructor);

            if (!await _instructorRepository.SaveAsync())
            {
                _logger.LogError("Failed to delete instructor");
            }

            return Ok(foundInstructor);
        }
    }
}