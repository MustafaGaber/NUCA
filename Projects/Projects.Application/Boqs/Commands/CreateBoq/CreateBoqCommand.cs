using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.CreateBoq
{
    public class CreateBoqCommand: ICreateBoqCommand
    {
        private readonly IBoqRepository _boqRepository;
        private readonly IProjectRepository _projectRepository;
        public CreateBoqCommand(IBoqRepository boqRepository, IProjectRepository projectRepository)
        {
            _boqRepository = boqRepository;
            _projectRepository = projectRepository;
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
