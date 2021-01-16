using System;
using System.Threading.Tasks;
using EventoInfrastructure.Commands.Users;
using EventoInfrastructure.Exceptions.Users;
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

        private Guid UserId => User?.Identity?.IsAuthenticated == true
            ? Guid.Parse(User.Identity.Name)
            : Guid.Empty;

        /*------------------------ METHODS REGION ------------------------*/
        public AccountController(IUserService userService) {
            _userService = userService;
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

        [HttpGet(ACCOUNT_CONTROLLER_TICKET)]
        public async Task<IActionResult> GetTickets() {
            throw new NotImplementedException();
        }

        [HttpPost(ACCOUNT_CONTROLLER_REGISTER)]
        public async Task<IActionResult> Post([FromBody]
                                              RegisterCommand registerCommand) {
            try {
                await _userService.RegisterAsync(
                    Guid.NewGuid(), registerCommand.Name, registerCommand.Email,
                    registerCommand.Password, registerCommand.Role
                );

                return Created(ACCOUNT_CONTROLLER_ACCOUNT, null);
            } catch (UserAlreadyExistsException) {
                return Conflict();
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
