using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Projects.Commands.DeleteProject
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
