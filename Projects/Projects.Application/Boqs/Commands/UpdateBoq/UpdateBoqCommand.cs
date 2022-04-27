using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateBoq
{
    public class UpdateBoqCommand: IUpdateBoqCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateBoqCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long id, UpdateBoqModel model)
        {
            Boq boq = _boqRepository.Get(id);
            boq.UpdateBoq(model.Addition);
            _boqRepository.Update(boq);
        }
    }
}
