using System;
using System.Threading.Tasks;
using EventoCore.Exceptions;
using EventoInfrastructure.Exceptions;
using EventoInfrastructure.Services.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EventoApi.Constants.Constants;

namespace EventoApi.Controllers {

    [ApiController]
    [Authorize]
    [Route(BASE_PATH_TICKET_CONTROLLER)]
    public class TicketController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly ITicketService _ticketService;

        private Guid UserId => User?.Identity?.IsAuthenticated == true
            ? Guid.Parse(User.Identity.Name)
            : Guid.Empty;

        /*------------------------ METHODS REGION ------------------------*/
        public TicketController(ITicketService ticketService) {
            _ticketService = ticketService;
        }

        [HttpGet(TICKET_CONTROLLER_PARAM_TICKET_ID)]
        public async Task<IActionResult> Get(Guid eventId, Guid ticketId) {
            try {
                return Json(await _ticketService.GetAsync(UserId, eventId, ticketId));
            } catch (NotFoundException) {
                return NotFound();
            }
        }

        [HttpPost(TICKET_CONTROLLER_PURCHASE_AMOUNT)]
        public async Task<IActionResult> Post(Guid eventId, int amount) {
            try {
                await _ticketService.PurchaseAsync(UserId, eventId, amount);
                return NoContent();
            } catch (NotFoundException) {
                return NotFound();
            } catch (OutOfAmountException) {
                return BadRequest();
            }
        }

        [HttpDelete(TICKET_CONTROLLER_CANCEL_AMOUNT)]
        public async Task<IActionResult> Delete(Guid eventId, int amount) {
            try {
                await _ticketService.CancelAsync(UserId, eventId, amount);
                return NoContent();
            } catch (NotFoundException) {
                return NotFound();
            } catch (NotEnoughException) {
                return BadRequest();
            }
        }

    }

}
