using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Commands;
using NUCA.Common.DDD;
using NUCA.Projects.Domain.Entities.Projects;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public class GetProjectsQuery : IGetProjectsQuery
    {
        private readonly IProjectRepository _repository;

        public GetProjectsQuery(IProjectRepository repository)
        {
            _repository = repository;
        }

        public List<GetProjectModel> Execute()
        {
            return _repository.All()
            .Select(project => new GetProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                DepartmentId = project.DepartmentId,
                DepartmentName = project.DepartmentName,
                OrderNumber = project.OrderNumber,
                OrderDate = project.OrderDate,
                ModifiedEndDates = project.ModifiedEndDates.Select(d => d.Date).ToList(),
                CompanyId = project.CompanyId,
                CompanyName = project.CompanyName,
                Notes = project.Notes,
                PrePaymentPercentage = project.PrePaymentPercentage,
            }).ToList();
        }
    }
}


