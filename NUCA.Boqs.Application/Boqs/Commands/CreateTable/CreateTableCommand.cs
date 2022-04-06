using  NUCA.Boqs.Application.Boqs.Models.GetBoq;
using  NUCA.Boqs.Application.Boqs.Queries.GetBoq;
using  NUCA.Boqs.Application.Interfaces.Persistence;
using  NUCA.Boqs.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NUCA.Boqs.Application.Boqs.Commands.CreateTable
{
    public class CreateTableCommand : ICreateTableCommand
    {
        private readonly IBoqRepository _boqRepository;
        public CreateTableCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }
        public GetBoqModel Execute(long boqId, CreateTableModel table)
        {
            Boq boq = _boqRepository.Get(boqId);
            boq.AddTable(table.TableName, table.Count, table.Addition);
            _boqRepository.Update(boq);
            return new GetBoqModel(boq);

        }
    }
}
