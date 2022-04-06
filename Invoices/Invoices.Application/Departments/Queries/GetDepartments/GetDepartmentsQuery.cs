using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Common;
using NUCA.Invoices.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Invoices.Application.Departments.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IGetDepartmentsQuery
    {

        private readonly IDepartmentRepository _repository;

        public GetDepartmentsQuery(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public List<GetDepartmentModel> Execute()
        {
            return _repository.All().Select(department => new GetDepartmentModel
            {
                   Id = department.Id,
                   Name = department.Name,
               }).ToList();
        }
    }
}
