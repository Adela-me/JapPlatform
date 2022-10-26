using AutoMapper;
using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;

namespace JapPlatformBackend.Repositories
{
    public class LectureRepository : BaseRepository<Lecture, CreateLectureDto, UpdateLectureDto, GetLectureDto>, ILectureRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public LectureRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //public override async Task<GetLectureDto> Update(int id, UpdateLectureDto updatedLecture)
        //{
        //    var lecture = await context.Lectures
        //        .FirstOrDefaultAsync(s => s.Id == id)
        //       ?? throw new ResourceNotFound("Lecture");

        //    if (lecture.WorkHours != updatedLecture.WorkHours)
        //    {
        //        //recalculate ips za sve ips koji sadrze itemId == id
        //    }

        //    lecture = mapper.Map<Lecture>(updatedLecture);

        //    lecture.ModifiedAt = DateTime.Now;

        //    await context.SaveChangesAsync();

        //    return mapper.Map<GetLectureDto>(lecture);
        //}

        //public override async Task<List<GetLectureDto>> Delete(int id, string includes = "")
        //{
        //     delete and recalculate ips koji sadrze itemId == id
        //}


    }
}
