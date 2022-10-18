namespace JapPlatformBackend.Core.Dtos.Program
{
    public class GetProgramDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
