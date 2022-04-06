using NUCA.Invoices.Domain.Common;

namespace NUCA.Invoices.Application.Departments.Commands.DeleteDepartment
{
    public interface IDeleteDepartmentCommand
    {
        void Execute(long id);
    }
}
