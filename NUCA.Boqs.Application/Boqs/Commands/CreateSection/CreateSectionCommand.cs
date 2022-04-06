using  NUCA.Boqs.Application.Boqs.Models.GetBoq;
using  NUCA.Boqs.Application.Interfaces.Persistence;
using  NUCA.Boqs.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.CreateSection
{
    public class CreateSectionCommand : ICreateSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateSectionCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public GetBoqModel Execute(long id, long tableId, CreateSectionModel section)
        {
            Boq boq = _boqRepository.Get(id);
            boq.AddSection(tableId, section.SectionName);
            _boqRepository.Update(boq);
            return new GetBoqModel(boq);
        }
    }
}
