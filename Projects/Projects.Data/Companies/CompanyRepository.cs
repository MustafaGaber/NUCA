using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NUCA.Projects.Data.Companies
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DatabaseContext database)
          : base(database) { }

        public bool CompanyHasProjects(long id)
        {
            return database.Projects.Include(p => p.Company).Where(p => p.Company.Id == id).Count() > 0;
        }
    }
}
