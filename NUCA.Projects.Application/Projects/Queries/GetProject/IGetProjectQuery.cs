using NUCA.Projects.Application.Projects.Commands;
using NUCA.Common.DDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public interface IGetProjectQuery
    {
        GetProjectModel Execute(long Id);
    }
}
