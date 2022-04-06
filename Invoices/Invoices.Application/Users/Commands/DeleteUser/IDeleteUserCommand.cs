using NUCA.Invoices.Domain.Common;

namespace NUCA.Invoices.Application.Users.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        void Execute(long id);
    }
}
