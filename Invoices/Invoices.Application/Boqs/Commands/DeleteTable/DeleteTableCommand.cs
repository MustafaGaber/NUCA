using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Boqs;


namespace NUCA.Invoices.Application.Boqs.Commands.DeleteTable
{
    public class DeleteTableCommand : IDeleteTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        public DeleteTableCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long projectId, long tableId)
        {
            Boq boq = _boqRepository.Get(projectId);
            boq.DeleteTable(tableId);
            _boqRepository.Update(boq);
        }
    }
}
