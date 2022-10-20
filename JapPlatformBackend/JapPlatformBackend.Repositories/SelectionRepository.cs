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

            selection.ModifiedAt = DateTime.Now;
            student.ModifiedAt = DateTime.Now;

            selection.Students.Add(student);

            var itemPrograms = await context.ItemPrograms
                .Include(ip => ip.Item)
                .Include(ip => ip.ItemProgramStudents)
                .Where(ip => ip.ProgramId == selection.ProgramId)
                .OrderBy(ip => ip.OrderNumber)
                .ToListAsync();

            for (int i = 0; i < itemPrograms.Count; i++)
            {
                var duration = Math.Ceiling((double)itemPrograms[i].Item.WorkHours / 8);
                var startDate = i == 0 ? selection.StartDate : itemPrograms[i - 1].ItemProgramStudents[i - 1].EndDate;
                var endDate = i == 0 ? selection.StartDate.AddDays(duration) : startDate.AddDays(duration);

                context.ItemProgramStudents.Add(new ItemProgramStudent
                {
                    ItemProgramId = itemPrograms[i].Id,
                    StudentId = studentId,
                    StartDate = startDate,
                    EndDate = endDate,

                });
            }

            //itemPrograms.ForEach((item, index) =>

            //    context.ItemProgramStudents.Add(new ItemProgramStudent
            //    {
            //        ItemProgramId = item.Id,
            //        StudentId = studentId,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now,

            //    });
            //);
            //foreach (ItemProgram ip in itemPrograms)
            //{

            //}

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
