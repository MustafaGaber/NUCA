using NUCA.Invoices.Application.Projects;
using NUCA.Invoices.Application.Projects.Commands;
using NUCA.Invoices.Application.Projects.Commands.CreateProject;
using NUCA.Invoices.Application.Projects.Commands.DeleteProject;
using NUCA.Invoices.Application.Projects.Commands.UpdateProject;
using NUCA.Invoices.Application.Projects.Queries.GetProjects;
using NUCA.Invoices.Domain.Entities.Projects;
using NUCA.Invoices.Api.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace NUCA.Invoices.Api.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly IGetProjectsQuery _listQuery;
        private readonly IGetProjectQuery _detailQuery;
        private readonly ICreateProjectCommand _createCommand;
        private readonly IUpdateProjectCommand _updateCommand;
        private readonly IDeleteProjectCommand _deleteCommand;

        public ProjectsController(IGetProjectsQuery listQuery, IGetProjectQuery detailQuery, ICreateProjectCommand createCommand, IUpdateProjectCommand updateCommand, IDeleteProjectCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }
         
        [HttpGet]
        public IActionResult Index()
        {
            List<GetProjectModel> projects = _listQuery.Execute();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            GetProjectModel project = _detailQuery.Execute(id);
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProjectModel project)
        {
           Project result =  _createCommand.Execute(project);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ProjectModel project)
        {
            _updateCommand.Execute(id, project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _deleteCommand.Execute(id);
            return Ok();
        }
    }
}
