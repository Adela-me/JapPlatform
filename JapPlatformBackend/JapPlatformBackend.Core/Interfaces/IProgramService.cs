using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Program;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IProgramService
    {
        Task<ServiceResponse<List<GetProgramDto>>> List();
    }
}
