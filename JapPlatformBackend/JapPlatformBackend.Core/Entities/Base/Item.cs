namespace JapPlatformBackend.Core.Entities.Base
{
    public class Item : AuditableEntity
    {
        public string Name { get; set; }
        public int WorkHours { get; set; }
        public ICollection<Program> Programs { get; set; }
        public List<ItemProgram> ItemPrograms { get; set; }

    }
}
