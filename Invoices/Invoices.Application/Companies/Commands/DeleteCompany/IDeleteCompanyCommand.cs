using NUCA.Invoices.Domain.Common;

namespace NUCA.Invoices.Application.Companies.Commands.DeleteCompany
{
    public interface IDeleteCompanyCommand
    {
        void Execute(long id);
    }
}
