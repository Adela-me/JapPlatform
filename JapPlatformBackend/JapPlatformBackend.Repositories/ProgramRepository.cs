using AutoMapper;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;

namespace JapPlatformBackend.Repositories
{
    public class ProgramRepository : BaseRepository<Program, CreateProgramDto, UpdateProgramDto, GetProgramDto>, IProgramRepository
    {
        public ProgramRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
