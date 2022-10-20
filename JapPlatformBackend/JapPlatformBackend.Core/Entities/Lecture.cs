using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class Lecture : Item
    {
        public string Description { get; set; }
        public string Urls { get; set; }
    }
}
