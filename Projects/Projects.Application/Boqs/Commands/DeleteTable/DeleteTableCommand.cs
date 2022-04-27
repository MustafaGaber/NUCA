using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Application.Boqs.Commands.DeleteTable
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
