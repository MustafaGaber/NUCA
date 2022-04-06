using NUCA.Invoices.Application.Interfaces.Persistence;

namespace NUCA.Invoices.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IDeleteProjectCommand
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectCommand(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void Execute(long id)
        {
            _projectRepository.Delete(id);
        }
    }
}
