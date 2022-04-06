using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext database)
         : base(database) { }

        public override IEnumerable<Project> All()
        {
            return database.Projects
                .Include(p => p.ModifiedEndDates)
                .ToList();
        }

        public override IEnumerable<Project> Find(Expression<Func<Project, bool>> predicate)
        {
            return database.Projects
                .Include(p => p.ModifiedEndDates)
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }
        public override Project Get(long id)
        {
            return database.Projects
                .Include(p => p.ModifiedEndDates)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
