using NUCA.Invoices.Application.Interfaces.Persistence;

namespace NUCA.Invoices.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Execute(long id)
        {
            _userRepository.Delete(id);
        }
    }
}
