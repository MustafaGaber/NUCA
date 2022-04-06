using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Domain.Entities.Invoices.States
{
    public enum State
    {
        ExecutionState,
        TechnicalOfficeState,
        RevisionState,
        PublishedState
    }
}
