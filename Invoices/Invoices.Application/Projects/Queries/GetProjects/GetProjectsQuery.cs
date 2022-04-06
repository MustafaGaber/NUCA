using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Application.Projects.Commands;
using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Projects;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Application.Projects.Queries.GetProjects
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
                DepartmentId = project.Department.Id,
                DepartmentName = project.Department.Name,
                OrderNumber = project.OrderNumber,
                OrderDate = project.OrderDate,
                ModifiedEndDates = project.ModifiedEndDates.Select(d => d.Date).ToList(),
                CompanyId = project.Company?.Id,
                CompanyName = project.Company?.Name,
                Notes = project.Notes,
                PrePaymentPercentage = project.PrePaymentPercentage,
            }).ToList();
        }
    }
}


