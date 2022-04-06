using  NUCA.Boqs.Domain.Entities.Boqs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  NUCA.Boqs.Data.Boqs
{
    public class BoqConfiguration : IEntityTypeConfiguration<Boq>
    {
        public void Configure(EntityTypeBuilder<Boq> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property("Id").ValueGeneratedNever();
            // builder.HasOne<Project>().WithOne().HasForeignKey<Boq>(b => b.Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Tables).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.Sections).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
