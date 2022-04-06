using System.Collections.Generic;

namespace NUCA.Invoices.Application.Users.Queries.GetUsers
{
    public interface IGetUsersQuery
    {
        List<GetUserModel> Execute();
    }
}
