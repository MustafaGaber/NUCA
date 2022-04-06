using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Users;
using System.Linq;

namespace NUCA.Invoices.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IUserRepository _repository;

        public GetUserQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        public GetUserModel Execute(long id)
        {
            var user = _repository.Get(id);
            return user != null ? new GetUserModel
            {
                Id = user.Id,
                Name = user.Name,
                Departments = user.Departments.Select(u =>
                new DepartmentModel { Id = u.Department.Id, Name = u.Department.Name })
                .ToList()
            } : null;
        }

    }
}
