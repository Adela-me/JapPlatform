using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class Program : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Selection>? Selections { get; set; }
    }
}
