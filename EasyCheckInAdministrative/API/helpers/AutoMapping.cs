using AutoMapper;
using API.dto;
using Core.Model;

namespace API.helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<StudentCheckInDto, StudentCheckIn>();
            CreateMap<DailySettingsDto, DailySettings>();
            CreateMap<GeneralSettingsDto, GeneralSettings>();
            CreateMap<UserDto, Admin>();
            CreateMap<StudentDto, Student>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<InstructorDto, Instructor>();

        }
    }
}
