using NUCA.Invoices.Domain.Entities.Users;

namespace NUCA.Invoices.Application.Users.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        User Execute(long id, UserModel model);
    }
}
