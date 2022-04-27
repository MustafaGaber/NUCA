using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateTable
{
    public class UpdateTableCommand : IUpdateTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        public UpdateTableCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public void Execute(long id, long tableId, UpdateTableModel table)
        {
            Boq boq = _boqRepository.Get(id);
            boq.UpdateTable(tableId, table.TableName, table.Count, table.Addition);
            _boqRepository.Update(boq);
        }
    }
}
