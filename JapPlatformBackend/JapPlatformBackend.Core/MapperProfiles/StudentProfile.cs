using AutoMapper;
using JapPlatformBackend.Common;
using JapPlatformBackend.Core.Dtos.Student;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();

            CreateMap<StudentSearchDto, BaseSearch>()
                .ForMember(dest => dest.Filter, opt =>
                {
                    opt.MapFrom(src =>
                        src.Filter == "selection" ? "selection.name" :
                        src.Filter == "program" ? "program.selection.name" :
                        src.Filter);
                })
                .ForMember(dest => dest.Sort, opt =>
                {
                    opt.MapFrom(src =>
                        src.Sort == "selection" ? "selection.name" :
                        src.Sort == "selection desc" ? "selection.name desc" :
                        src.Sort == "program" ? "selection.program.name" :
                        src.Sort == "program desc" ? "selection.program.name desc" :
                        src.Sort);
                });
        }
    }
}
