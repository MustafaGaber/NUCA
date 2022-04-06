﻿using NUCA.Invoices.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NUCA.Invoices.Data.Departments
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(d => d.Groups).WithOne(g => g.Department)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("DGroup");
            builder.HasMany(g => g.Departments).WithOne(d => d.Group)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class DepartmentGroupConfiguration : IEntityTypeConfiguration<DepartmentGroup>
    {
        public void Configure(EntityTypeBuilder<DepartmentGroup> builder)
        {
            builder.HasKey(d => new {  d.DepartmentId, d.GroupId });
        }
    }
}
