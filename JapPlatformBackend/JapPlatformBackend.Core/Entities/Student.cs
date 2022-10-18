using JapPlatformBackend.Common.Enums;

namespace JapPlatformBackend.Core.Entities;

public class Student : User
{
    public StudentStatus Status { get; set; }

    public int? SelectionId { get; set; }
    public Selection? Selection { get; set; }

    public virtual List<Comment> Comments { get; set; } = new List<Comment>();

}
