using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Invoices;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Users;
using NUCA.Projects.Data.Boqs;
using NUCA.Projects.Data.Companies;
using NUCA.Projects.Data.Core;
using NUCA.Projects.Data.Departments;
using NUCA.Projects.Data.Invoices;
using NUCA.Projects.Data.Projects;
using NUCA.Projects.Data.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Boq> Boqs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceTable> InvoiceTables { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //TODO initialize database
        }

        public new DbSet<T> Set<T>() where T : Entity
        {
            return base.Set<T>();
        }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
            }
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new BoqConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
                        
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentGroupConfiguration());
            
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceTableConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceSectionConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceItemConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserDepartmentConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;
            foreach(var entry in ChangeTracker.Entries().Where(e=>
            e.State == EntityState.Added || e.State == EntityState.Modified)) {
                entry.Property("LastModified").CurrentValue = timestamp;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timestamp;
                }
            }

            List<AggregateRoot> aggregateRoots = ChangeTracker
               .Entries()
               .Where(x => x.Entity is AggregateRoot)
               .Select(x => (AggregateRoot)x.Entity)
               .ToList();

            foreach (AggregateRoot aggregateRoot in aggregateRoots)
            {
                foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
                {
                    DomainEvents.Dispatch(domainEvent);
                }
                aggregateRoot.ClearEvents();
            }
            return base.SaveChanges();
        }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }*/
    }
}
