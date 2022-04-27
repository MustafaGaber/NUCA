using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Projects.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IGetUsersQuery
    {

        private readonly IUserRepository _repository;

        public GetUsersQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<GetUserModel> Execute()
        {
            return _repository.All().Select(user => new GetUserModel
            {
                Id = user.Id,
                Name = user.Name,
                Departments = user.Departments.Select(u =>
                new DepartmentModel { Id = u.Department.Id, Name = u.Department.Name })
                .ToList()
            }).ToList();
        }
    }
}
