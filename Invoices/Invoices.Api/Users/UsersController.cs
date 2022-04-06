﻿using NUCA.Invoices.Application.Users;
using NUCA.Invoices.Application.Users.Commands;
using NUCA.Invoices.Application.Users.Commands.CreateUser;
using NUCA.Invoices.Application.Users.Commands.DeleteUser;
using NUCA.Invoices.Application.Users.Commands.UpdateUser;
using NUCA.Invoices.Application.Users.Queries;
using NUCA.Invoices.Application.Users.Queries.GetUser;
using NUCA.Invoices.Application.Users.Queries.GetUsers;
using NUCA.Invoices.Domain.Entities.Users;
using NUCA.Invoices.Api.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace NUCA.Invoices.Api.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IGetUsersQuery _listQuery;
        private readonly IGetUserQuery _detailQuery;
        private readonly ICreateUserCommand _createCommand;
        private readonly IUpdateUserCommand _updateCommand;
        private readonly IDeleteUserCommand _deleteCommand;

        public UsersController(IGetUsersQuery listQuery, IGetUserQuery detailQuery, ICreateUserCommand createCommand, IUpdateUserCommand updateCommand, IDeleteUserCommand deleteCommand)
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
            List<GetUserModel> users = _listQuery.Execute();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            GetUserModel user = _detailQuery.Execute(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserModel user)
        {
           User result =  _createCommand.Execute(user);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UserModel user)
        {
            _updateCommand.Execute(id, user);
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
