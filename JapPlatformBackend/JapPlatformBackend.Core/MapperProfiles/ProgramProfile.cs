using AutoMapper;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program, GetProgramDto>();
        }
    }
}
