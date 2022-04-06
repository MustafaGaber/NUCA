using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommand(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Project Execute(ProjectModel model)
        {
            var project = _projectRepository.Add(new Project
            (
                model.Name,
                model.DepartmentId,
                model.DepartmentName,
                model.OrderNumber,
                model.OrderDate,
                model.EndDate,
                model.ModifiedEndDates.Select(d => new ModifiedEndDate(d)).ToList(),
                model.CompanyId,
                model.CompanyName,
                model.Notes,
                model.PrePaymentPercentage
            ));
            return project;
        }
    }
}
