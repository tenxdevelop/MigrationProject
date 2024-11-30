﻿using Microsoft.AspNetCore.Mvc;
using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICommandProcessor _commandProcessor;

        public UserController(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddUser(string name, string surname, string patronymic, string email, string password)
        {
            // Создаём команду на основе входящих параметров
            var command = new CreateUserStatementCommand(name, surname, patronymic, email, password);
            var result = await _commandProcessor.Process<bool>(command);
            return View("DeleteUser");
        }

        public async Task<IActionResult> DeleteUser(int Id)
        {
            var command = new DeleteUserCommand(Id);
            var result = await _commandProcessor.Process<bool>(command);
            return View("UserDeleted");

        }
    }
    
}
