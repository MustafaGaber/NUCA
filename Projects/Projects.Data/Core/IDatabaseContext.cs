using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Users;
using NUCA.Projects.Domain.Entities.Invoices;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Data.Core
{
    public interface IDatabaseContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Boq> Boqs { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<T> Set<T>() where T : Entity;
        void Save();
    }
}
