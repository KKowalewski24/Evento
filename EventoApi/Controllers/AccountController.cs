using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static EventoApi.Constants.Constants;

namespace EventoApi.Controllers {

    [ApiController]
    [Route(BASE_PATH_ACCOUNT_CONTROLLER)]
    public class AccountController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        [HttpGet]
        public async Task<IActionResult> Get() {
            throw new NotImplementedException();
        }

        [HttpGet(ACCOUNT_CONTROLLER_TICKET)]
        public async Task<IActionResult> GetTickets() {
            throw new NotImplementedException();
        }

        [HttpPost(ACCOUNT_CONTROLLER_REGISTER)]
        public async Task<IActionResult> Post() {
            throw new NotImplementedException();
        }

        [HttpPost(ACCOUNT_CONTROLLER_LOGIN)]
        public async Task<IActionResult> PostTickets() {
            throw new NotImplementedException();
        }

    }

}
