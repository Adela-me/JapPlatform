using AutoMapper;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;

namespace JapPlatformBackend.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IMapper mapper;
        private readonly IProgramRepository programRepository;

        public ProgramService(IMapper mapper, IProgramRepository programRepository)
        {
            this.mapper = mapper;
            this.programRepository = programRepository;
        }

        public async Task<ServiceResponse<List<GetProgramDto>>> List()
        {
            var includes = "Selections";

            var response = new ServiceResponse<List<GetProgramDto>>
            {
                Data = await programRepository.GetAll(includes)
            };
            return response;
        }
    }
}
