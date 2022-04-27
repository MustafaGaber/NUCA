
namespace NUCA.Projects.Application.Users.Queries.GetUser
{
    public interface IGetUserQuery
    {
        GetUserModel Execute(long id);
    }
}
