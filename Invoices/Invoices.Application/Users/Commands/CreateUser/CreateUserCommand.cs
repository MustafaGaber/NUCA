using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Departments;
using NUCA.Invoices.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public CreateUserCommand(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }
        public User Execute(UserModel model)
        {
            List<Department> departments = model.DepartmentsIds.Select(id => _departmentRepository.Get(id)).Where(d => d != null).ToList();
            return _userRepository.Add(new User(model.Name, departments));
        }
    }
}
