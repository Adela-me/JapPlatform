using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class ProgramRepository : BaseRepository<Program, CreateProgramDto, UpdateProgramDto, GetProgramDto>, IProgramRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProgramRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override async Task<GetProgramDto> Create(CreateProgramDto newProgram)
        {
            var lecture = await context.Items
                .FirstOrDefaultAsync(l => l.Id == newProgram.ItemId)
                ?? throw new ResourceNotFound("Item");

            var program = mapper.Map<Program>(newProgram);

            program.Items.Add(lecture);

            context.Programs.Add(program);

            await context.SaveChangesAsync();
            return mapper.Map<GetProgramDto>(program);
        }

        public async Task<GetProgramDto> AddItem(int programId, AddItemPrograms itemProgram)
        {
            var program = await context.Programs
                .FirstOrDefaultAsync(s => s.Id == programId)
                ?? throw new ResourceNotFound("Program");

            var item = await context.Items
                .FirstOrDefaultAsync(s => s.Id == itemProgram.ItemId)
                ?? throw new ResourceNotFound("Item");

            program.ModifiedAt = DateTime.Now;
            var newItemProgram = new ItemProgram
            {
                Program = program,
                Item = item,
                OrderNumber = itemProgram.OrderNumber,
            };

            program.ItemPrograms.Add(newItemProgram);
            await context.SaveChangesAsync();

            return mapper.Map<GetProgramDto>(program);
        }

        public async Task<GetProgramDto> RemoveItem(int programId, int itemId)
        {
            var program = await context.Programs
                .FindAsync(programId)
                ?? throw new ResourceNotFound("Program");

            var itemProgram = context.ItemPrograms.FirstOrDefault(ip => ip.ItemId == itemId && ip.ProgramId == programId);

            context.ItemPrograms.Remove(itemProgram);

            await context.SaveChangesAsync();

            return mapper.Map<GetProgramDto>(program);
        }
    }
}
