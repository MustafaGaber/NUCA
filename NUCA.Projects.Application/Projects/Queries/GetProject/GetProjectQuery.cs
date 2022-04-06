using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Commands;
using NUCA.Projects.Domain.Entities.Projects;
using System.Linq;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public class GetProjectQuery : IGetProjectQuery
    {
        private readonly IProjectRepository _repository;

        public GetProjectQuery(IProjectRepository repository)
        {
            _repository = repository;
        }

        public GetProjectModel Execute(long id)
        {
            var project = _repository.Get(id);

            return project != null ?
                 new GetProjectModel
                 {
                     Id = project.Id,
                     Name = project.Name,
                     DepartmentId = project.Department.Id,
                     DepartmentName = project.Department.Name,
                     OrderNumber = project.OrderNumber,
                     OrderDate = project.OrderDate,
                     ModifiedEndDates = project.ModifiedEndDates.Select(d => d.Date).ToList(),
                     CompanyId = project.Company?.Id,
                     CompanyName = project.Company?.Name,
                     Notes = project.Notes,
                     PrePaymentPercentage = project.PrePaymentPercentage,
                 } : null;
        }

    }
}


