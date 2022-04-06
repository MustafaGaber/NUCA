using NUCA.Common.DDD;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.CreateProject
{
    public interface ICreateProjectCommand
    {
        Project Execute(ProjectModel model);
    }
}
