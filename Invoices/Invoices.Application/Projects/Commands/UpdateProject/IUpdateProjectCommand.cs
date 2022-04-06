using NUCA.Invoices.Domain.Entities.Projects;

namespace NUCA.Invoices.Application.Projects.Commands.UpdateProject
{
    public interface IUpdateProjectCommand
    {
        Project Execute(long id, ProjectModel model);
    }
}
