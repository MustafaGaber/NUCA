using Microsoft.EntityFrameworkCore;
using NUCA.Invoices.Domain.Entities.Projects;
using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Boqs;
using NUCA.Invoices.Domain.Entities.Companies;
using NUCA.Invoices.Domain.Entities.Users;
using NUCA.Invoices.Domain.Entities.Invoices;
using NUCA.Invoices.Domain.Entities.Departments;

namespace NUCA.Invoices.Data.Core
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
