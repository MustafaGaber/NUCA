using NUCA.Projects.Application.Projects.Commands;
using System.Collections.Generic;

namespace NUCA.Projects.Application.Projects.Queries.GetProjects
{
    public interface IGetProjectsQuery
    {
        List<GetProjectModel> Execute();
    }
}
