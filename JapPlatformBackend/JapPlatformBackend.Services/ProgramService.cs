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

        public async Task<ServiceResponse<GetProgramDto>> GetById(int id)
        {
            var includes = "Selections, ItemPrograms.Item";

            var response = new ServiceResponse<GetProgramDto>
            {
                Data = await programRepository.GetById(id, includes)
            };

            return response;
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

        public async Task<ServiceResponse<GetProgramDto>> Create(CreateProgramDto newProgram)
        {
            var response = new ServiceResponse<GetProgramDto>
            {
                Data = await programRepository.Create(newProgram)
            };
            return response;
        }

        public async Task<ServiceResponse<GetProgramDto>> Update(int id, UpdateProgramDto updatedProgram)
        {
            var response = new ServiceResponse<GetProgramDto>
            {
                Data = await programRepository.Update(id, updatedProgram)
            };
            return response;
        }

        public async Task<ServiceResponse<List<GetProgramDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetProgramDto>>
            {
                Data = await programRepository.Delete(id)
            };
            return response;
        }

        public async Task<ServiceResponse<GetProgramDto>> AddItem(int programId, AddItemPrograms itemPrograms)
        {
            var response = new ServiceResponse<GetProgramDto>
            {
                Data = await programRepository.AddItem(programId, itemPrograms)
            };

            return response;
        }

        public async Task<ServiceResponse<GetProgramDto>> RemoveItem(int programId, int ItemId)
        {
            var response = new ServiceResponse<GetProgramDto>
            {
                Data = await programRepository.RemoveItem(programId, ItemId)
            };

            return response;
        }
    }
}
