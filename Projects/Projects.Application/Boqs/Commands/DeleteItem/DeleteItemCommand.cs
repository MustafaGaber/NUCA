using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;


namespace NUCA.Projects.Application.Boqs.Commands.DeleteItem
{
    public class DeleteItemCommand : IDeleteItemCommand
    {
        private readonly IBoqRepository _boqRepository;
        public DeleteItemCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long projectId, long tableId, long sectionId, long itemId)
        {
            Boq boq = _boqRepository.Get(projectId);
            boq.DeleteItem(tableId, sectionId, itemId);
            _boqRepository.Update(boq);
        }
    }
}
