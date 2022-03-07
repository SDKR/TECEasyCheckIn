using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using Core.DataInterfaces;
using Core.Model;
using AutoMapper;
using API.dto;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;
using Core.Model.Enums;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    //[Authorize]
    public class StudentCheckinsController : ControllerBase
    {
        private readonly ILogger<StudentCheckinsController> _logger;
        private readonly IStudentCheckInRepository _studentCheckInRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IDailySettingsRepository _dailySettingsRepository;
        private readonly IMapper _mapper;

        public StudentCheckinsController(ILogger<StudentCheckinsController> logger,
                                         IStudentCheckInRepository studentCheckInRepository,
                                         IStudentRepository studentRepository,
                                         IDailySettingsRepository dailySettingsRepository,
                                         IMapper mapper)
        {
            _logger = logger;
            _studentCheckInRepository = studentCheckInRepository;
            _studentRepository = studentRepository;
            _dailySettingsRepository = dailySettingsRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllStudentcheckins")]
        public async Task<IActionResult> GetAllForSelectedWeek([FromQuery] string departmentName, [FromQuery] string[] selectedDays)
        {
            DateTime[] selectedWeek = Array.ConvertAll(selectedDays, sd =>
            {
                DateTime d = Convert.ToDateTime(sd);
                return d;
            });

            var allStudents = await _studentRepository.GetAllByDepartmentNameAsync(departmentName);

            foreach (var student in allStudents)
            {
                List<DateTime> ciDates = new List<DateTime>(5);
                foreach (var checkin in student.StudentCheckIns)
                {
                    checkin.Student = null;
                    ciDates.Add(checkin.Date);
                }
                foreach (var date in selectedWeek)
                {
                    if (!ciDates.Contains(date))
                    {
                        student.StudentCheckIns.Add(
                            new StudentCheckIn
                            {
                                Date = date,
                                StudentName = student.FullName,
                                Attendance = Core.Model.Enums.AttendanceStatus.NoShow
                            });
                    }
                }
            }

            return Ok(allStudents);
        }

        [HttpGet("{id}" ,Name = "GetStudentcheckin")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var foundStudent = await _studentCheckInRepository.GetFirstByExpressionAsync(x => x.Id == id);

            if (foundStudent == null)
            {
                return NotFound();
            }

            return Ok(foundStudent);
        }

        [HttpDelete("{id}", Name = "DeleteStudentCheckin")]
        public async Task<IActionResult> DeleteOne(Guid id)
        {
            var foundStudent = await _studentCheckInRepository.GetFirstByExpressionAsync(x => x.Id == id);
            if (foundStudent == null)
            {
                return NotFound();
            }

            _studentCheckInRepository.Delete(foundStudent);

            if (!await _studentCheckInRepository.SaveAsync())
            {
                _logger.LogError("Failed to delete student checkin");
            }

            return Ok(foundStudent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOne([FromBody] CheckInOutDto checkInOut)
        {
            // Find student by FullName
            var student = await _studentRepository.GetByFullName(checkInOut.FullName);

            // Return if student can't be matched with existing students
            // This creates a new student in the database. This part is hardcoded for EL and needs changed to work in another scenario.
            if (student == null)
            {
                //checkInOut.FirstName = checkInOut.FirstName.Substring(0, 1).ToUpper() + checkInOut.FirstName.Substring(1).ToLower();
                checkInOut.FirstName = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(checkInOut.FirstName.ToLower());
                checkInOut.LastName = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(checkInOut.LastName.ToLower());
                Student newstudent = new Student();               
                newstudent.Id = Guid.NewGuid();
                newstudent.FirstName = checkInOut.FirstName;
                newstudent.LastName = checkInOut.LastName;
                // this is hard coded to "Ingen" og El som department
                newstudent.InstructorId = new Guid("144D14BD-9889-4D02-A363-55DA5B8D79B6");
                newstudent.DepartmentId = new Guid("3B097E5E-AF52-48A6-8D19-764C20D84F3B");

                _studentRepository.Create(newstudent);

                if (!await _studentRepository.SaveAsync())
                {
                    return Ok(new { Color = "Red", Message = $"{checkInOut.FirstName} kunne ikke oprettes, kontakt din instruktør. Tidspunkt {checkInOut.TimeStamp:HH:mm:ss}" });
                }
                else
                {
                    return Ok(new { Color = "MediumOrchid", Message = $"{checkInOut.FirstName} er blevet oprettet, \n Kør venligst kortet igennem igen for at tjekke ind. \n Tidspunkt {checkInOut.TimeStamp:HH:mm:ss}" });
                }            
            }

            // If student is SOFT DELETED, remove it // NOT
            if (student.IsDeleted)
            {
                /*_studentRepository.RemoveSoftDelete(student);
                if (!await _studentRepository.SaveAsync())
                {
                    _logger.LogError("Failed to remove soft deleted in studentcheckin");
                }*/
                return Ok(new { Color = "Red", Message = $"Brugeren er slettet, kontakt instruktør.\n Tidspunkt {checkInOut.TimeStamp:HH:mm:ss}" });
            }

            // Get dailySettings for today for department
            var settingsForToday = await GetSettingsForToday(student.DepartmentId, checkInOut.Date);
            // If date is a weekend, return error message
            // Will also fail if no defaultdailysettings are set for department
            if (settingsForToday == null)
            {
                return Ok(new { Color = "Yellow", Message = $"Det var en fejl med datoen {checkInOut.Date:dd/MM/yy}, kontakt din instruktør. Tidspunkt {checkInOut.TimeStamp:HH:mm:ss}" });
            }

            // Check for existing checkIn for today by student
            var checkInForToday = await _studentCheckInRepository.GetStudentCheckInByStudentIdAndDate(student.Id, checkInOut.Date);
            if (checkInForToday != null)
            {
                // TO DO: need to check if checkout is too early, not implemented in system yet

                if (checkInForToday.CheckInTimeStamp + TimeSpan.FromMinutes(1) > DateTime.Now)
                {
                    return Ok(new { Color = "Yellow", Message = $"{student.FirstName} er allerede tjekket ind kl. {checkInForToday.CheckInTimeStamp:HH:mm:ss}. Vent 1 minut for at tjekke ud." });
                }

                // if student is checked in but hasnt check out yet
                if (checkInForToday.CheckOutTimeStamp == null)
                {
                    checkInForToday.CheckOutTimeStamp = checkInOut.TimeStamp;
                    // update studentcheckin before saving.. maybe not?
                    if (!await _studentCheckInRepository.SaveAsync())
                    {
                        _logger.LogError("Failed to update studentcheckin");
                    }
                    return Ok(new { Color = "Green", Message = $"{student.FirstName} er nu tjekket ud kl. {checkInForToday.CheckOutTimeStamp:HH:mm:ss}." });
                }
                // if student already has checked out for today
                else
                {
                    return Ok(new { Color = "Yellow", Message = $"{student.FirstName} er allerede tjekket ud kl. {checkInForToday.CheckOutTimeStamp:HH:mm:ss} i dag." });
                }
            }

            StudentCheckIn checkInToAdd = new StudentCheckIn()
            {
                Id = Guid.NewGuid(),
                StudentId = student.Id,
                StudentName = student.FullName,
                Date = checkInOut.Date,
                CheckInTimeStamp = checkInOut.TimeStamp,
                Attendance = SetAttendanceStatus(settingsForToday, checkInOut.TimeStamp)
            }; 

            _studentCheckInRepository.Create(checkInToAdd);

            if (!await _studentCheckInRepository.SaveAsync())
            {
                _logger.LogError("Failed to create student checkin");
            }

            if (checkInToAdd.Attendance == AttendanceStatus.OnTime)
            {
                return Ok(new { Color = "Green", Message = $"{student.FirstName} er tjekket ind til tiden kl. {checkInToAdd.CheckInTimeStamp:HH:mm:ss}." });

            }
            else
            {
                return Ok(new { Color = "Yellow", Message = $"{student.FirstName} er tjekket ind for sent kl. {checkInToAdd.CheckInTimeStamp:HH:mm:ss}." });

            }
        }

        private async Task<DailySettings> GetSettingsForToday(Guid departmentId, DateTime date)
        {
            var settingsForToday = await _dailySettingsRepository.GetFirstByExpressionAsync(ds => ds.DepartmentId == departmentId && ds.Date == date);
            if (settingsForToday == null)
            {
                settingsForToday = await _dailySettingsRepository.CreateSettingsForToday(departmentId, date);
                if (settingsForToday == null)
                {
                    return null;
                }
                _dailySettingsRepository.Create(settingsForToday);
                if (!await _dailySettingsRepository.SaveAsync())
                {
                    _logger.LogError("Failed to create setting for today");
                }
            }

            return settingsForToday;
        }

        private AttendanceStatus SetAttendanceStatus(DailySettings settingsToday, DateTimeOffset checkInTime)
        {
            if (settingsToday.LastestCheckInTimeStamp >= checkInTime)
            {
                return AttendanceStatus.OnTime;
            } 
            else
            {
                return AttendanceStatus.Late;
            }
        }

        [HttpPut("{id}", Name = "UpdateStudentcheckin")]
        public async Task<IActionResult> UpdateOne([FromBody] StudentCheckInDto studentCheckIn, [FromRoute] Guid id)
        {
            var studentCheckInFromDb = await _studentCheckInRepository.GetFirstByExpressionAsync(x => x.Id == id);
            
            if (studentCheckInFromDb == null)
            {
                return NotFound();
            }

            var bod = _mapper.Map(studentCheckIn, studentCheckInFromDb);
            _studentCheckInRepository.Update(studentCheckInFromDb);

            if (!await _studentCheckInRepository.SaveAsync())
            {
                _logger.LogError("Failed to update studentcheckin");
            }

            return Ok(studentCheckInFromDb);
        }

        [HttpPost("ManuelStudenLateTooOnTime", Name = "ManuelStudenLateTooOnTime")]
        public async Task<IActionResult> LateTooOnTime(StudentCheckIn checkinstudent)
        {
            var studentCheckInFromDb = await _studentCheckInRepository.GetFirstByExpressionAsync(x => x.Id == checkinstudent.Id);

            if (studentCheckInFromDb == null)
            {
                return NotFound();
            }

            studentCheckInFromDb.Attendance = 0;

            if (!await _studentCheckInRepository.SaveAsync())
            {
                _logger.LogError("Failed to update studentcheckin");
            }

            return Ok(studentCheckInFromDb);
        }


    }
}