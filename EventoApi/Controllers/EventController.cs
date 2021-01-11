using System;
using System.Threading.Tasks;
using EventoInfrastructure.Commands.Events;
using EventoInfrastructure.Exceptions.Events;
using EventoInfrastructure.Services.Events;
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

        [HttpGet(EVENT_CONTROLLER_PARAM_EVENT_ID)]
        public async Task<IActionResult> Get(Guid eventId) {
            try {
                return Json(await _eventService.GetByIdAsync(eventId));
            } catch (Exception e) when (e is NullReferenceException) {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]
                                              CreateEventCommand createEventCommand) {
            try {
                Guid eventId = Guid.NewGuid();
                await _eventService.CreateAsync(
                    eventId, createEventCommand.Name, createEventCommand.Description,
                    createEventCommand.StartDate, createEventCommand.EndDate
                );

                await _eventService.AddTicketAsync(
                    eventId, createEventCommand.TicketsCount, createEventCommand.Price
                );

                return Created($"/event/{eventId}", null);
            } catch (Exception e)
                when (e is EventAlreadyExistsException || e is EventNotFoundException) {
                return NotFound();
            }
        }

        [HttpPut(EVENT_CONTROLLER_PARAM_EVENT_ID)]
        public async Task<IActionResult> Put(Guid eventId,
                                             [FromBody]
                                             UpdateEventCommand updateEventCommand) {
            try {
                await _eventService.UpdateAsync(
                    eventId, updateEventCommand.Name, updateEventCommand.Description
                );

                return NoContent();
            } catch (EventNotFoundException) {
                return NotFound();
            } catch (EventAlreadyExistsException) {
                return Conflict();
            }
        }

        [HttpDelete(EVENT_CONTROLLER_PARAM_EVENT_ID)]
        public async Task<IActionResult> Delete(Guid eventId) {
            try {
                await _eventService.DeleteByIdAsync(eventId);
                return NoContent();
            } catch (EventNotFoundException) {
                return NotFound();
            }
        }

    }

}
