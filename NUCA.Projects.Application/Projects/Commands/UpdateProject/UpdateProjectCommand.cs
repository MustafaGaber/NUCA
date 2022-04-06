using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IUpdateProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectCommand(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Project Execute(long id, ProjectModel model)
        {
            Project project = _projectRepository.Get(id);
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
