using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Departments;
using NUCA.Invoices.Domain.Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Invoices.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UpdateUserCommand(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }
        public User Execute(long id, UserModel model)
        {
            List<Department> departments = model.DepartmentsIds.Select(id => _departmentRepository.Get(id)).Where(d => d != null).ToList();
            var user = _userRepository.Get(id);
            user.Update(model.Name, departments);
            return _userRepository.Update(user);
        }
    }
}
