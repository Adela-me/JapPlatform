using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class ItemProgramConfiguration : IEntityTypeConfiguration<ItemProgram>
    {
        public void Configure(EntityTypeBuilder<ItemProgram> builder)
        {
            //builder.HasKey(ip => new { ip.ItemId, ip.ProgramId });

            //builder.HasOne(ip => ip.Item)
            //    .WithMany(i => i.ItemPrograms)
            //    .HasForeignKey(ip => ip.ProgramId);

            //builder.HasOne(ip => ip.Program)
            //    .WithMany(p => p.ItemPrograms)
            //    .HasForeignKey(ip => ip.ProgramId);

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
                }
                );

        }
    }
}
