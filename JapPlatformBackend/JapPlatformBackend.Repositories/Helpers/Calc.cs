using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Repositories.Helpers
{
    public static class Calc
    {
        public static List<ItemProgramStudent> SetItemsStartEndDates(List<Student> students)
        {
            var ips = new List<ItemProgramStudent>();

            foreach (var student in students)
            {
                for (int i = 0; i < student.Selection.Program.ItemPrograms.Count; i++)
                {
                    var duration = Math.Ceiling((double)student.Selection.Program.ItemPrograms[i]
                        .Item.WorkHours / 8);

                    var startDate = i == 0
                        ? student.Selection.StartDate
                        : ips[i - 1].EndDate;

                    var endDate = i == 0
                        ? student.Selection.StartDate.AddDays(duration)
                        : startDate?.AddDays(duration);

                    ips.Add(new ItemProgramStudent
                    {
                        ItemId = student.Selection.Program.ItemPrograms[i].ItemId,
                        ProgramId = student.Selection.Program.ItemPrograms[i].ProgramId,
                        StudentId = student.Id,
                        StartDate = startDate,
                        EndDate = endDate,

                    });
                }
            }

            return ips;
        }
    }
}
