using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Projects;
using NUCA.Invoices.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NUCA.Invoices.Data.Projects
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext database)
         : base(database) { }

        public override IEnumerable<Project> All()
        {
            return database.Projects
                .Include(p => p.Company)
                .Include(p => p.Department)
                .Include(p => p.ModifiedEndDates)
                .ToList();
        }

        public override IEnumerable<Project> Find(Expression<Func<Project, bool>> predicate)
        {
            return database.Projects
                .Include(p => p.Company)
                .Include(p => p.Department)
                .Include(p => p.ModifiedEndDates)
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }
        public override Project Get(long id)
        {
            return database.Projects
                .Include(p => p.Company)
                .Include(p => p.Department)
                .Include(p => p.ModifiedEndDates)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
