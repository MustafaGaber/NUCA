using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Companies;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Domain.Entities.Projects;
using System.Linq;

namespace NUCA.Projects.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IUpdateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateProjectCommand(IProjectRepository projectRepository, ICompanyRepository companyRepository, IDepartmentRepository departmentRepository)
        {
            _projectRepository = projectRepository;
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
        }
        public Project Execute(long id, ProjectModel model)
        {
            Project project = _projectRepository.Get(id);
            Department department = _departmentRepository.Get(model.DepartmentId);
            Company company = _companyRepository.Get(model.CompanyId);
            project.Update(
                model.Name,
                department,
                model.OrderNumber,
                model.OrderDate,
                model.EndDate,
                model.ModifiedEndDates.Select(d => new ModifiedEndDate(d)).ToList(),
                company,
                model.Notes,
                model.PrePaymentPercentage);
            return _projectRepository.Update(project);
        }
    }
}
