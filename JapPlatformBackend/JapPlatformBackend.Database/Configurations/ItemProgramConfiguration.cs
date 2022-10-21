using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class ItemProgramConfiguration : IEntityTypeConfiguration<ItemProgram>
    {
        public void Configure(EntityTypeBuilder<ItemProgram> builder)
        {
            builder
                .HasData(
                new ItemProgram
                {
                    Id = 1,
                    ItemId = 1,
                    ProgramId = 1,
                    OrderNumber = 1,
                },
                new ItemProgram
                {
                    Id = 2,
                    ItemId = 2,
                    ProgramId = 1,
                    OrderNumber = 2,
                },
                new ItemProgram
                {
                    Id = 3,
                    ItemId = 3,
                    ProgramId = 2,
                    OrderNumber = 2,
                },
                new ItemProgram
                {
                    Id = 4,
                    ItemId = 4,
                    ProgramId = 2,
                    OrderNumber = 1,
                },
                new ItemProgram
                {
                    Id = 5,
                    ItemId = 5,
                    ProgramId = 3,
                    OrderNumber = 1,
                }
                );

        }
    }
}
