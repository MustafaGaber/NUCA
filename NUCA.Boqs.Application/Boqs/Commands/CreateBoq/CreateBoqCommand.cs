using  NUCA.Boqs.Application.Interfaces.Persistence;
using  NUCA.Boqs.Domain.Entities.Boqs;

namespace  NUCA.Boqs.Application.Boqs.Commands.CreateBoq
{
    public class CreateBoqCommand: ICreateBoqCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateBoqCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public Boq Execute(long id, CreateBoqModel model)
        {
            Boq oldBoq = _boqRepository.Get(id);
            if (oldBoq == null) {
                Boq boq = new Boq(id, model.Addition);
                _boqRepository.Add(boq);
                return boq;
            } else {
                throw new InvalidOperationException();
            }
        }
    }
}
