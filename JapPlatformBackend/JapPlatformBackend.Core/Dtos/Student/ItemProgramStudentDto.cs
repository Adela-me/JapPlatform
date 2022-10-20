using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Dtos.ItemPrograms;

namespace JapPlatformBackend.Core.Dtos.Student
{
    public class ItemProgramStudentDto
    {
        public GetItemProgramDto ItemProgram { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Progress { get; set; } = 0;
        public ProgressStatus ProgressStatus { get; set; } = ProgressStatus.NotStarted;
    }
}
