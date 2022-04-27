using NUCA.Projects.Domain.Entities.Users;

namespace NUCA.Projects.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        User Execute(UserModel model);
    }
}
