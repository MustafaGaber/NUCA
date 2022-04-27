using NUCA.Projects.Application.Boqs.Commands;
using NUCA.Projects.Application.Boqs.Queries.GetBoq;
using NUCA.Projects.Application.Boqs.Commands.CreateBoq;
using NUCA.Projects.Application.Boqs.Commands.CreateItem;
using NUCA.Projects.Application.Boqs.Commands.CreateSection;
using NUCA.Projects.Application.Boqs.Commands.CreateTable;
using NUCA.Projects.Application.Boqs.Commands.DeleteItem;
using NUCA.Projects.Application.Boqs.Commands.DeleteSection;
using NUCA.Projects.Application.Boqs.Commands.DeleteTable;
using NUCA.Projects.Application.Boqs.Commands.UpdateBoq;
using NUCA.Projects.Application.Boqs.Commands.UpdateItem;
using NUCA.Projects.Application.Boqs.Commands.UpdateSection;
using NUCA.Projects.Application.Boqs.Commands.UpdateTable;
using NUCA.Projects.Api.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Application.Boqs.Models.GetBoq;

namespace NUCA.Projects.Api.Boqs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoqsController: BaseController
    {
        private readonly IGetBoqQuery _getBoqQuery;
        private readonly ICreateBoqCommand _createBoqCommand;
        private readonly IUpdateBoqCommand _updateBoqCommand;
        private readonly ICreateTableCommand _createTableCommand;
        private readonly IUpdateTableCommand _updateTableCommand;
        private readonly IDeleteTableCommand _deleteTableCommand;
        private readonly ICreateSectionCommand _createSectionCommand;
        private readonly IUpdateSectionCommand _updateSectionCommand;
        private readonly IDeleteSectionCommand _deleteSectionCommand;
        private readonly ICreateItemCommand _createItemCommand;
        private readonly IUpdateItemCommand _updateeItemCommand;
        private readonly IDeleteItemCommand _deleteItemCommand;

        public BoqsController(IGetBoqQuery getBoqQuery, ICreateBoqCommand createBoqCommand, IUpdateBoqCommand updateBoqCommand, 
            ICreateTableCommand createTableCommand, IUpdateTableCommand updateTableCommand, IDeleteTableCommand deleteTableCommand,
            ICreateSectionCommand createSectionCommand, IUpdateSectionCommand updateSectionCommand, IDeleteSectionCommand deleteSectionCommand,
            ICreateItemCommand createItemCommand, IUpdateItemCommand updateItemCommand, IDeleteItemCommand deleteItemCommand)
        {
            _getBoqQuery = getBoqQuery; 
            _createBoqCommand = createBoqCommand;
            _updateBoqCommand = updateBoqCommand;
            _createTableCommand = createTableCommand;
            _updateTableCommand = updateTableCommand;
            _deleteTableCommand = deleteTableCommand;
            _createSectionCommand = createSectionCommand;
            _updateSectionCommand = updateSectionCommand;
            _deleteSectionCommand = deleteSectionCommand;
            _createItemCommand = createItemCommand;
            _updateeItemCommand = updateItemCommand;
            _deleteItemCommand = deleteItemCommand;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            GetBoqModel boq = _getBoqQuery.Execute(id);
            return Ok(boq);
        }

        [HttpPost("{id}")]
        public IActionResult CreateBoq(long id, [FromBody] CreateBoqModel model)
        {
            Boq boq = _createBoqCommand.Execute(id, model);
            return Ok(boq);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBoq(long id, [FromBody] UpdateBoqModel model)
        {
          _updateBoqCommand.Execute(id, model);
            return Ok();
        }

        [HttpPost("Table/{id}")]
        public IActionResult CreateTable(long id, [FromBody] CreateTableModel table)
        {
            GetBoqModel boq  = _createTableCommand.Execute(id, table);
            return Ok(boq);
        }

        [HttpPut("Table/{id}/{tableId}")]
        public IActionResult UpdateTable(long id, long tableId, [FromBody]  UpdateTableModel table)
        {
            _updateTableCommand.Execute(id, tableId, table);
            return Ok();
        }

        [HttpDelete("Table/{id}/{tableId}")]
        public IActionResult DeleteTable(long id, long tableId)
        {
            _deleteTableCommand.Execute(id, tableId);
            return Ok();
        }

        [HttpPost("Section/{id}/{tableId}")]
        public IActionResult createSection(long id, long tableId, [FromBody] CreateSectionModel section)
        {
            GetBoqModel boq = _createSectionCommand.Execute(id, tableId, section);
            return Ok(boq);
        }

        [HttpPut("Section/{id}/{tableId}/{sectionId}")]
        public IActionResult UpdateSection(long id, long tableId, long sectionId, [FromBody] UpdateSectionModel section)
        {
            _updateSectionCommand.Execute(id, tableId, sectionId, section);
            return Ok();
        }

        [HttpDelete("Section/{id}/{tableId}/{sectionId}")]
        public IActionResult DeleteSection(long id, long tableId, long sectionId)
        {
            _deleteSectionCommand.Execute(id, tableId, sectionId);
            return Ok();
        }

        [HttpPost("Item/{id}/{tableId}/{sectionId}")]
        public IActionResult CreateItem(long id, long tableId, long sectionId, [FromBody] CreateItemModel item)
        {
            GetBoqModel boq = _createItemCommand.Execute(id, tableId, sectionId, item);
            return Ok(boq);
        }

        [HttpPut("Item/{id}/{tableId}/{sectionId}/{itemId}")]
        public IActionResult UpdateItem(long id, long tableId, long sectionId, long itemId, [FromBody] UpdateItemModel item)
        {
            _updateeItemCommand.Execute(id, tableId, sectionId, itemId, item);
            return Ok();
        }

        [HttpDelete("Item/{id}/{tableId}/{sectionId}/{itemId}")]
        public IActionResult DeleteItem(long id, long tableId, long sectionId, long itemId)
        {
            _deleteItemCommand.Execute(id, tableId, sectionId, itemId);
            return Ok();
        }
    }
}
