using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Invoices;
using NUCA.Projects.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(p => p.Company).WithMany();
            builder.HasOne(p => p.Department).WithMany();
            builder.HasMany(p => p.ModifiedEndDates).WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
