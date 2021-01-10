using System;
using System.Threading.Tasks;
using EventoInfrastructure.Commands.Events;
using EventoInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using static EventoApi.Constants.Constants;

namespace EventoApi.Controllers {

    [ApiController]
    [Route(BASE_PATH_EVENT_CONTROLLER)]
    public class EventController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IEventService _eventService;

        /*------------------------ METHODS REGION ------------------------*/
        public EventController(IEventService eventService) {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name) {
            return Json(await _eventService.SearchByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody]
            CreateEventCommand createEventCommand) {
            Guid eventId = Guid.NewGuid();

            await _eventService.CreateAsync(
                eventId, createEventCommand.Name, createEventCommand.Description,
                createEventCommand.StartDate, createEventCommand.EndDate
            );

            await _eventService.AddTicketAsync(
                eventId, createEventCommand.TicketsCount, createEventCommand.Price
            );

            return Created(BASE_PATH_EVENT_CONTROLLER, null);
        }

    }

}
