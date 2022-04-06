﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Commands.UpdateTable
{
    public interface IUpdateTableCommand
    {
        void Execute(long projectId, long tableId, UpdateTableModel table);
    }
}
