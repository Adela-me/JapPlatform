using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.HasData(
                new Lecture
                {
                    Id = 1,
                    Name = "React Course",
                    Description = "Description of the React Course",
                    Urls = "udemy.com"
                },
                new Lecture
                {
                    Id = 2,
                    Name = ".Net Course",
                    Description = ".Net Course Description",
                    Urls = "udemy.com"
                });
        }
    }
}
