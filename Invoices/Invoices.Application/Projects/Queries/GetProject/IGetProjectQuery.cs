using NUCA.Invoices.Application.Projects.Commands;
using NUCA.Invoices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Invoices.Application.Projects.Queries.GetProjects
{
    public interface IGetProjectQuery
    {
        GetProjectModel Execute(long Id);
    }
}
