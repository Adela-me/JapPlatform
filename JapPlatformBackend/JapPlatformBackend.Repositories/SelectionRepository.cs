using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class SelectionRepository : BaseRepository<Selection, CreateSelectionDto,
        UpdateSelectionDto, GetSelectionDto>, ISelectionRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public SelectionRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override async Task<GetSelectionDto> Create(CreateSelectionDto newSelection)
        {
            var program = await context.Programs
               .FirstOrDefaultAsync(p => p.Id == newSelection.ProgramId)
               ?? throw new ResourceNotFound("Program");

            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == newSelection.StudentId)
                ?? throw new ResourceNotFound("Student");

            var selection = mapper.Map<Selection>(newSelection);

            selection.Students.Add(student);

            context.Selections.Add(selection);
            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
        public override async Task<GetSelectionDto> Update(int id, UpdateSelectionDto updatedSelection)
        {
            var selection = await context.Selections
               .FirstOrDefaultAsync(s => s.Id == id)
               ?? throw new ResourceNotFound("Selection");

            if (updatedSelection.ProgramId.HasValue && updatedSelection.ProgramId != selection.ProgramId)
            {
                Program? program = await context.Programs
                    .FirstOrDefaultAsync(p => p.Id == updatedSelection.ProgramId)
                    ?? throw new ResourceNotFound("Program");
            }

            selection = mapper.Map(updatedSelection, selection);

            selection.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
        public async Task<GetSelectionDto> AddStudent(int studentId, int slectionId)
        {
            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ResourceNotFound("Student");

            var selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId)
                ?? throw new ResourceNotFound("Selection");

            // Allowing students to be added even if they are already in some other selection
            // There is no warning if student is already in this selection

            selection.ModifiedAt = DateTime.Now;
            student.ModifiedAt = DateTime.Now;

            selection.Students.Add(student);
            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
        public async Task<GetSelectionDto> RemoveStudent(int studentId, int slectionId)
        {

            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId && s.Selection.Id == slectionId)
                ?? throw new ResourceNotFound("Student");

            var selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId)
                ?? throw new ResourceNotFound("Selection");

            // Allows to delete last student, leaving selection with no students

            selection.ModifiedAt = DateTime.Now;
            student.ModifiedAt = DateTime.Now;

            selection.Students.Remove(student);
            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
    }
}
