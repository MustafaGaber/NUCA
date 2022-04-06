using NUCA.Invoices.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace NUCA.Invoices.Data.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Departments).WithOne(d => d.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class UserDepartmentConfiguration : IEntityTypeConfiguration<UserDepartment>
    {
        public void Configure(EntityTypeBuilder<UserDepartment> builder)
        {
            builder.HasOne(u => u.Department).WithMany();
            builder.HasOne(u => u.User).WithMany(d => d.Departments);
            builder.HasKey(d => new { d.UserId , d.DepartmentId});
        }
    }
}
