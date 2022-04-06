using NUCA.Common.DDD;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Data.Projects;
using Microsoft.EntityFrameworkCore;

namespace NUCA.Projects.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
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

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());         
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
