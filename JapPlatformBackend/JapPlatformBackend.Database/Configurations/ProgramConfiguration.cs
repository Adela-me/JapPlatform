using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder
                .HasMany(p => p.Selections)
                .WithOne(s => s.Program)
                .HasForeignKey(s => s.ProgramId);

            builder.HasData(
                new Program
                {
                    Id = 1,
                    Name = "JAP Dev",
                    Description = "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities."
                },
                new Program
                {
                    Id = 2,
                    Name = "JAP QA",
                    Description = "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities."
                },
                new Program
                {
                    Id = 3,
                    Name = "JAP DevOps",
                    Description = "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities."
                }
            );
        }
    }
}
