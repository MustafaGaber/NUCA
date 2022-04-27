using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Invoices.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUCA.Projects.Domain.Entities.Invoices
{
    public class Invoice : AggregateRoot
    {
        private readonly List<WorksTable> _worksTables = new List<WorksTable>();
        private readonly List<SuppliesTable> _suppliesTables = new List<SuppliesTable>();
        public long ProjectId { get; private set; }
        public virtual IReadOnlyList<WorksTable> WorksTables => _worksTables.ToList();
        public virtual IReadOnlyList<SuppliesTable> SuppliesTables => _suppliesTables.ToList();
        public State State { get; private set; }
        public double Addition { get; private set; }
        public DateTime Date { get; private set; }
        public bool Final { get; private set; }
        protected Invoice() { }
        public Invoice(long projectId, Boq boq, bool final)
        {
            Guard.Against.Null(boq, nameof(boq));
            ProjectId = Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            State = State.ExecutionState;
            Final = final;
            Addition = boq.Premium;
            _worksTables = boq.Tables.Select(table => new WorksTable(table)).ToList();
            _suppliesTables = boq.Tables.Select(table => new SuppliesTable(table)).ToList();
        }
        public Invoice(long projectId, Boq boq, bool final, Invoice previousInvoice)
        {
            Guard.Against.Null(boq, nameof(boq));
            ProjectId = Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            State = State.ExecutionState;
            Final = final;
            Addition = boq.Premium;
            _worksTables = boq.Tables.Select(table => new WorksTable(table, previousInvoice.WorksTables.First(t => t.Id == table.Id))).ToList();
            _suppliesTables = boq.Tables.Select(table => new SuppliesTable(table, previousInvoice.SuppliesTables.First(t => t.Id == table.Id))).ToList();
        }
        public void UpdateItem(long tableId, long sectionId, long itemId, InvoiceItemUpdates updates, bool isSupplies)
        {
            List<InvoiceTable> tables = isSupplies ? _suppliesTables.Cast<InvoiceTable>().ToList() :  _worksTables.Cast<InvoiceTable>().ToList();
            InvoiceTable table = tables.First(table => table.Id == tableId);
            table.UpdateItem(sectionId, itemId, updates);
        }
  
        public void Next()
        {
            switch(State)
            {
                case State.ExecutionState:
                    State = State.TechnicalOfficeState;
                    break;
                case State.TechnicalOfficeState:
                    State = State.RevisionState;
                    break;
                case State.RevisionState:
                    State = State.PublishedState;
                    break;
            }
        }

        public void Back()
        {
            switch (State)
            {
                case State.TechnicalOfficeState:
                    State = State.ExecutionState;
                    break;
                case State.RevisionState:
                    State = State.TechnicalOfficeState;
                    break;
            }
        }

        /* public void UpdateCurrentQuantity(InvoiceTableType type, long tableId, long sectionId, long itemId, double quantity, string userId) {
          List<InvoiceTable> tables = type == InvoiceTableType.Works ? _worksTables : _suppliesTables;
          InvoiceTable table = tables.First(table => table.Id == tableId);
          table.UpdateCurrentQuantity(sectionId, itemId, quantity, userId);
      }

      public void UpdatePercentages(InvoiceTableType type, long tableId, long sectionId, long itemId, List<InvoiceItemPercentage> percentages, string userId)
      {
          List<InvoiceTable> tables = type == InvoiceTableType.Works ? _worksTables : _suppliesTables;
          InvoiceTable table = tables.First(table => table.Id == tableId);
          table.UpdatePercentages(sectionId, itemId, percentages, userId);
      }

      public void UpdateNotes(InvoiceTableType type, long tableId, long sectionId, long itemId, string notes, string userId)
      {
          List<InvoiceTable> tables = type == InvoiceTableType.Works ? _worksTables : _suppliesTables;
          InvoiceTable table = tables.First(table => table.Id == tableId);
          table.UpdateNotes(sectionId, itemId, notes, userId);
      }*/

    }
}
