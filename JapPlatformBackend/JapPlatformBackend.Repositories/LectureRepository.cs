using AutoMapper;
using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;

namespace JapPlatformBackend.Repositories
{
    public class LectureRepository : BaseRepository<Lecture, CreateLectureDto, UpdateLectureDto, GetLectureDto>, ILectureRepository
    {
        public LectureRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }


    }
}
