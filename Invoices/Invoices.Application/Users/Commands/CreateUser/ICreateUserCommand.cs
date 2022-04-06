using NUCA.Invoices.Domain.Entities.Users;

namespace NUCA.Invoices.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        User Execute(UserModel model);
    }
}
