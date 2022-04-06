using Microsoft.AspNetCore.Mvc;
using NUCA.Invoices.Application.Departments.Commands.CreateDepartment;
using NUCA.Invoices.Application.Departments;
using NUCA.Invoices.Api.Core;
using System.Collections.Generic;
using NUCA.Invoices.Application.Departments.Queries.GetDepartments;
using NUCA.Invoices.Application.Departments.Queries.GetDepartment;
using NUCA.Invoices.Application.Departments.Commands.UpdateDepartment;
using NUCA.Invoices.Application.Departments.Commands.DeleteDepartment;
using NUCA.Invoices.Domain.Entities.Departments;
using NUCA.Invoices.Application.Departments.Queries;
using NUCA.Invoices.Application.Departments.Queries.CanDeleteDepartment;

namespace NUCA.Invoices.Api.Departments
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController: BaseController
    {
        private readonly IGetDepartmentsQuery _listQuery;
        private readonly IGetDepartmentQuery _detailQuery;
        private readonly ICanDeleteDepartmentQuery _canDeleteQuery;
        private readonly ICreateDepartmentCommand _createCommand;
        private readonly IUpdateDepartmentCommand _updateCommand;
        private readonly IDeleteDepartmentCommand _deleteCommand;

        public DepartmentsController(IGetDepartmentsQuery listQuery, IGetDepartmentQuery detailQuery, ICreateDepartmentCommand createCommand, IUpdateDepartmentCommand updateCommand, IDeleteDepartmentCommand deleteCommand ,ICanDeleteDepartmentQuery canDeleteQuery)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _canDeleteQuery = canDeleteQuery;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<GetDepartmentModel> departments = _listQuery.Execute();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            GetDepartmentModel department = _detailQuery.Execute(id);
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DepartmentModel department)
        {
            Department result = _createCommand.Execute(department);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] DepartmentModel department)
        {
            _updateCommand.Execute(id, department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _deleteCommand.Execute(id);
            return Ok();
        }

        [HttpGet("canDelete/{id}")]
        public IActionResult CanDelete(long id)
        {
            return Ok(_canDeleteQuery.Execute(id));
        }
    }
}