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
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentsController(ILogger<StudentsController> logger,
                                 IMapper mapper,
                                 IStudentRepository studentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }


        [HttpGet(Name = "GetAllStudents")]
        public async Task<IActionResult> GetAllByDepartment([FromQuery] string departmentName)
        {
            var allStudents = await _studentRepository.GetAllByDepartmentNameAsync(departmentName);

            foreach (var student in allStudents)
            {
                // set studentcheckins to null since not needed
                // also removes unintended infinite refere loop, since studentcheckins refers back to student
                student.StudentCheckIns = null;
            }
            return Ok(allStudents);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var foundStudent = await _studentRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (foundStudent == null)
            {
                return NotFound();
            }

            return Ok(foundStudent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne([FromBody] StudentDto student)
        {

            var studentToAdd = _mapper.Map<Student>(student);
            studentToAdd.Id = Guid.NewGuid();

            _studentRepository.Create(studentToAdd);

            if (!await _studentRepository.SaveAsync())
            {
                _logger.LogError("Failed to create student");
            }

            return Ok(studentToAdd);

        }

        [HttpPost("bulkinsert", Name = "CreateManyStudents")]
        public async Task<IActionResult> CreateMany([FromBody] List<StudentDto> students)
        {
            List<List<Student>> listsToReturn = new List<List<Student>>();
            List<Student> studentsCreated = new List<Student>();
            List<Student> studentsExists = new List<Student>();

            foreach (var student in students)
            {
                // check if student with same fullname already exists in department.
                var exists = await _studentRepository.GetByDepartmentAndFullName(student.DepartmentId, $"{student.FirstName} {student.LastName}");
                // if it doesnt exist, create it and add to studentsCreated list
                if (exists == null)
                {
                    var studentToAdd = _mapper.Map<Student>(student);
                    studentToAdd.Id = Guid.NewGuid();
                    _studentRepository.Create(studentToAdd);
                    studentsCreated.Add(studentToAdd);
                }
                // else add it to list for already existing students
                else
                {
                    var studentExists = _mapper.Map<Student>(exists);
                    studentsExists.Add(studentExists);
                }
            }

            // Remove soft delete from students in database
            foreach (Student student in studentsExists)
            {
                if (student.IsDeleted)
                    _studentRepository.RemoveSoftDelete(student);
            }

            if (!await _studentRepository.SaveAsync())
            {
                _logger.LogError("Failed to create students from list");
            }

            // add both lists to nested return list
            listsToReturn.Add(studentsCreated);
            listsToReturn.Add(studentsExists);

            return Ok(listsToReturn);
        }

        [HttpPut("{id}", Name = "UpdateStudent")]
        public async Task<IActionResult> UpdateOne([FromBody] StudentDto student, [FromRoute] Guid id)
        {
            var studentFromDb = await _studentRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            var bod = _mapper.Map(student, studentFromDb);
            _studentRepository.Update(bod);

            if (!await _studentRepository.SaveAsync())
            {
                _logger.LogError("Failed to update student");
            }

            return Ok(bod);
        }

        [HttpPut("bulkreplace", Name = "ReplaceManyStudents")]
        public async Task<IActionResult> ReplaceMany([FromBody] List<StudentDto> replacementStudents)
        {
            // map incoming list to students
            List<Student> students = _mapper.Map<List<Student>>(replacementStudents);

            List<List<Student>> listsToReturn = new List<List<Student>>();
            List<Student> studentsToCreate = new List<Student>();
            List<Student> studentsExists = new List<Student>();
            List<Student> studentsToDelete = new List<Student>();

            // get all students to check if they are not in the replacement list
            var allStudents = await _studentRepository.GetAllByDepartmentIdAsync(students[0].DepartmentId);
            allStudents = allStudents.Where(s => s.IsDeleted == false);

            // filter out names to compare with allStudents fullnames
            List<string> studentNames = students.Select(s => s.FullName).ToList();
            // get lists of students not in replacement list to be SOFT DELETED
            studentsToDelete = allStudents.Where(s => !studentNames.Contains(s.FullName)).ToList();
            // get lists of student in list that already exists in db
            studentsExists = allStudents.Where(s => studentNames.Contains(s.FullName)).ToList();

            foreach (Student student in students)
            {
                // TODO: find better solution than check whole list
                // check if student with same fullname already exists in department.
                var exists = allStudents.FirstOrDefault(s => s.FullName.Contains(student.FullName));
                // if it doesnt exist, create it and add to studentsCreated list
                if (exists == null)
                {
                    student.Id = Guid.NewGuid();
                    _studentRepository.Create(student);
                    studentsToCreate.Add(student);
                }
            }

            // Remove soft delete from students in database
            foreach (Student student in studentsExists)
            {
                if (student.IsDeleted) 
                    _studentRepository.RemoveSoftDelete(student);
            }

            // Soft delete students in database that are not on replacement list
            foreach (Student student in studentsToDelete)
            {
                _studentRepository.SoftDelete(student);
            }

            if (!await _studentRepository.SaveAsync())
            {
                _logger.LogError("Failed to bulkreplace students from list");
            }

            // add all lists to nested return list
            listsToReturn.Add(studentsToCreate);
            listsToReturn.Add(studentsExists);
            listsToReturn.Add(studentsToDelete);

            return Ok(listsToReturn);
        }

        [HttpPut("bulkreplacechanges", Name = "GetReplaceManyStudentsChanges")]
        public async Task<IActionResult> GetReplaceManyChanges([FromBody] List<StudentDto> replacementStudents)
        {
            // map incoming list to students
            List<Student> students = _mapper.Map<List<Student>>(replacementStudents);

            List<List<Student>> listsToReturn = new List<List<Student>>();
            List<Student> studentsToCreate = new List<Student>();
            List<Student> studentsExists = new List<Student>();
            List<Student> studentsToDelete = new List<Student>();

            // get all students to check if they are not in the replacement list
            var allStudents = await _studentRepository.GetAllByDepartmentIdAsync(students[0].DepartmentId);
            allStudents = allStudents.Where(s => s.IsDeleted == false);

            // filter out names to compare with allStudents fullnames
            List<string> studentNames = students.Select(s => s.FullName).ToList();
            // get lists of students not in replacement list to be SOFT DELETED
            studentsToDelete = allStudents.Where(s => !studentNames.Contains(s.FullName)).ToList();
            // get lists of student in list that already exists in db
            studentsExists = allStudents.Where(s => studentNames.Contains(s.FullName)).ToList();

            foreach (var student in students)
            {
                // TODO: find better solution than check whole list
                // check if student with same fullname already exists in department.
                var exists = allStudents.FirstOrDefault(s => s.FullName.Contains(student.FullName));
                // if it doesnt exist, create it and add to studentsCreated list
                if (exists == null)
                {
                    studentsToCreate.Add(student);
                }
            }

            // add all lists to nested return list
            listsToReturn.Add(studentsToCreate);
            listsToReturn.Add(studentsExists);
            listsToReturn.Add(studentsToDelete);

            return Ok(listsToReturn);
        }

        [HttpDelete("{id}", Name = "DeleteStudent")]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            var foundStudent = await _studentRepository.GetFirstByExpressionAsync(x => x.Id == id);
            if (foundStudent == null)
            {
                return NotFound();
            }

            _studentRepository.Delete(foundStudent);

            if (!await _studentRepository.SaveAsync())
            {
                _logger.LogError("Failed to delete student");
            }

            return Ok(foundStudent);
        }
    }
}
