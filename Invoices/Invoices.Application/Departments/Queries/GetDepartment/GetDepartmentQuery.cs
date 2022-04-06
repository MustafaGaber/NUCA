using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Departments;

namespace NUCA.Invoices.Application.Departments.Queries.GetDepartment
{
    public class GetDepartmentQuery : IGetDepartmentQuery
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentQuery(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public GetDepartmentModel Execute(long id)
        {
            var department = _repository.Get(id);
            return department != null ? new GetDepartmentModel
            {
                Id = department.Id,
                Name = department.Name,
            } : null;
        }

    }
}
