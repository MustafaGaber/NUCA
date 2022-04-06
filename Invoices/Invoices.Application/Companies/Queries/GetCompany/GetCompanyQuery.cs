using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Companies;

namespace NUCA.Invoices.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQuery : IGetCompanyQuery
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyQuery(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public GetCompanyModel Execute(long id)
        {
            var company = _repository.Get(id);
            return company != null ? new GetCompanyModel
            {
                Id = company.Id,
                Name = company.Name,
            }: null;
        }

    }
}
