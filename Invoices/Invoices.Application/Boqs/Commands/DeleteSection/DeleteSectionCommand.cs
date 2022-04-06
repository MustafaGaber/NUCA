﻿using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Boqs;


namespace NUCA.Invoices.Application.Boqs.Commands.DeleteSection
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
