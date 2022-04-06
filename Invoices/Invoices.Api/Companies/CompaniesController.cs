using NUCA.Invoices.Application.Companies;
using NUCA.Invoices.Application.Companies.Commands.CreateCompany;
using NUCA.Invoices.Application.Companies.Commands.DeleteCompany;
using NUCA.Invoices.Application.Companies.Commands.UpdateCompany;
using NUCA.Invoices.Application.Companies.Queries.GetCompanies;
using NUCA.Invoices.Application.Companies.Queries.GetCompany;
using NUCA.Invoices.Api.Core;
using Microsoft.AspNetCore.Mvc;

namespace NUCA.Invoices.Api.Companies
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        private readonly IGetCompaniesQuery _listQuery;
        private readonly IGetCompanyQuery _detailQuery;
        private readonly ICreateCompanyCommand _createCommand;
        private readonly IUpdateCompanyCommand _updateCommand;
        private readonly IDeleteCompanyCommand _deleteCommand;

        public CompaniesController(IGetCompaniesQuery listQuery, IGetCompanyQuery detailQuery, ICreateCompanyCommand createCommand, IUpdateCompanyCommand updateCommand, IDeleteCompanyCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var companies = _listQuery.Execute();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var company = _detailQuery.Execute(id);
            return Ok(company);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CompanyModel company)
        {
            var result = _createCommand.Execute(company);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] CompanyModel company)
        {
            _updateCommand.Execute(id, company);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
             _deleteCommand.Execute(id);
            return Ok();
        }
    }
}
