using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdateProject
{
    public interface IUpdateProjectCommand
    {
        Project Execute(long id, ProjectModel model);
    }
}
