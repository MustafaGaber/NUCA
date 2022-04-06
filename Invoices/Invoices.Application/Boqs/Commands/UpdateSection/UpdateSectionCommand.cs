using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.UpdateSection
{
    public class UpdateSectionCommand : IUpdateSectionCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateSectionCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long projectId, long tableId, long sectionId, UpdateSectionModel section)
        {
            Boq boq = _boqRepository.Get(projectId);
            boq.UpdateSection(tableId, sectionId, section.SectionName);
            _boqRepository.Update(boq);
        }
    }
}
