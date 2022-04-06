using  NUCA.Boqs.Application.Interfaces.Persistence;
using  NUCA.Boqs.Domain.Entities.Boqs;


namespace  NUCA.Boqs.Application.Boqs.Commands.DeleteSection
{
    public class DeleteSectionCommand : IDeleteSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        public DeleteSectionCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long projectId, long tableId, long sectionId)
        {
            Boq boq = _boqRepository.Get(projectId);
            boq.DeleteSection(tableId, sectionId);
            _boqRepository.Update(boq);
        }
    }
}
