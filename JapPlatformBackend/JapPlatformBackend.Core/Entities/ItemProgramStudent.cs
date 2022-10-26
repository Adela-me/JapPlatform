using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class ItemProgramStudent
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
        public ItemProgram ItemProgram { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Progress { get; set; } = 0;
        public ProgressStatus ProgressStatus { get; set; } = ProgressStatus.NotStarted;
    }
}
