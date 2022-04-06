using NUCA.Invoices.Application.Boqs.Models.GetBoq;
using NUCA.Invoices.Application.Boqs.Queries.GetBoq;
using NUCA.Invoices.Application.Interfaces.Persistence;
using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.CreateTable
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
