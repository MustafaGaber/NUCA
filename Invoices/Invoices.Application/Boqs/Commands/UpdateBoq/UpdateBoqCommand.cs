using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.UpdateBoq
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
