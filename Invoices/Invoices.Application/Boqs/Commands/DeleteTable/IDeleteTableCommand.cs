

namespace NUCA.Invoices.Application.Boqs.Commands.DeleteTable
{
    public interface IDeleteTableCommand
    {
        void Execute(long projectId, long tableId);
    }
}
