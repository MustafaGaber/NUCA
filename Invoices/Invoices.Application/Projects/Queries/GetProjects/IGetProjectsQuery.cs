using NUCA.Invoices.Application.Projects.Commands;
using System.Collections.Generic;

namespace NUCA.Invoices.Application.Projects.Queries.GetProjects
{
    public interface IGetProjectsQuery
    {
        List<GetProjectModel> Execute();
    }
}
