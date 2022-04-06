﻿using NUCA.Invoices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Domain.Entities.Projects
{
    public class ModifiedEndDate : Entity
    {
        public virtual DateTime Date { get; }
        protected ModifiedEndDate() { }
        public ModifiedEndDate(DateTime date)
        {
            Date = date;
        }

    }
}
