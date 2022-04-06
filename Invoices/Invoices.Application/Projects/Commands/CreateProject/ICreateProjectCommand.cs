using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Projects;

namespace NUCA.Invoices.Application.Projects.Commands.CreateProject
{
    public interface ICreateProjectCommand
    {
        Project Execute(ProjectModel model);
    }
}
