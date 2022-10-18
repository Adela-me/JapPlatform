using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface IProgramRepository : IBaseRepository<Program, CreateProgramDto, UpdateProgramDto, GetProgramDto>
    {
    }
}
