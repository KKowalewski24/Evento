﻿using System;
using System.Threading.Tasks;
using EventoCore.Exceptions.Enums;
using EventoCore.Extensions;
using EventoInfrastructure.Commands.Users;
using EventoInfrastructure.Exceptions;
using EventoInfrastructure.Exceptions.Users;
using EventoInfrastructure.Services.Tickets;
using EventoInfrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EventoApi.Constants.Constants;

namespace EventoApi.Controllers {

    [ApiController]
    [Route(BASE_PATH_ACCOUNT_CONTROLLER)]
    public class AccountController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;

        private Guid UserId => User?.Identity?.IsAuthenticated == true
            ? Guid.Parse(User.Identity.Name)
            : Guid.Empty;

        /*------------------------ METHODS REGION ------------------------*/
        public AccountController(IUserService userService, ITicketService ticketService) {
            _userService = userService;
            _ticketService = ticketService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get() {
            try {
                return Json(await _userService.GetAccountAsync(UserId));
            } catch (UserNotFoundException) {
                return NotFound();
            }
        }

        [HttpGet(TICKET_CONTROLLER_TICKET)]
        [Authorize]
        public async Task<IActionResult> GetTickets() {
            try {
                return Json(await _ticketService.GetTicketsForUserAsync(UserId));
            } catch (NotFoundException) {
                return NotFound();
            }
        }

        [HttpPost(ACCOUNT_CONTROLLER_REGISTER)]
        public async Task<IActionResult> Post([FromBody]
                                              RegisterCommand registerCommand) {
            try {
                await _userService.RegisterAsync(
                    Guid.NewGuid(), registerCommand.Name, registerCommand.Email,
                    registerCommand.Password, registerCommand.Role.FromStringToUserRole()
                );

                return Created(ACCOUNT_CONTROLLER_ACCOUNT, null);
            } catch (UserAlreadyExistsException) {
                return Conflict();
            } catch (EnumWrongValueException) {
                return BadRequest();
            }
        }

        [HttpPost(ACCOUNT_CONTROLLER_LOGIN)]
        public async Task<IActionResult> PostTickets([FromBody]
                                                     LoginCommand loginCommand) {
            try {
                return Json(await _userService.LoginAsync(loginCommand.Email, loginCommand.Password));
            } catch (UserNotFoundException) {
                return NotFound();
            }
        }

    }

}
