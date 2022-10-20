using JapPlatformBackend.Core.Dtos.Lecture;

namespace JapPlatformBackend.Core.Dtos.ItemPrograms
{
    public class GetItemProgramDto
    {
        public int OrderNumber { get; set; }
        public GetLectureDto Item { get; set; }
    }
}
