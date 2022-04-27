using NUCA.Projects.Domain.Entities.Invoices;
using NUCA.Projects.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NUCA.Projects.Data.Invoices
{
   public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne<Project>().WithMany().HasForeignKey(i => i.ProjectId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.SuppliesTables).WithOne().HasForeignKey(t => t.InvoiceId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(i => i.WorksTables).WithOne().HasForeignKey(t => t.InvoiceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class InvoiceTableConfiguration : IEntityTypeConfiguration<InvoiceTable>
    {
        public void Configure(EntityTypeBuilder<InvoiceTable> builder)
        {
            builder.HasMany(t => t.Sections).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasDiscriminator<int>("Type")
                .HasValue<WorksTable>((int)InvoiceTableType.Works)
                .HasValue<SuppliesTable>((int)InvoiceTableType.Supplies);
           // builder.HasOne<Invoice>().WithMany().HasForeignKey("InvoiceId");
            // builder.HasOne<Invoice>().WithMany().HasForeignKey("InvoiceId");
        }
    }

    public class InvoiceSectionConfiguration : IEntityTypeConfiguration<InvoiceSection>
    {
        public void Configure(EntityTypeBuilder<InvoiceSection> builder)
        {
            builder.HasMany(s => s.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasMany(s => s.Percentages).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
