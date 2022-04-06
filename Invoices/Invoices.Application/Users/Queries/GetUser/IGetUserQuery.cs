
namespace NUCA.Invoices.Application.Users.Queries.GetUser
{
    public interface IGetUserQuery
    {
        GetUserModel Execute(long id);
    }
}
