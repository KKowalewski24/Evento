using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventoInfrastructure.Commands.Events;
using EventoInfrastructure.DTO.Events;
using EventoInfrastructure.Exceptions.Events;
using EventoInfrastructure.Services.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static EventoApi.Constants.Constants;

namespace EventoApi.Controllers {

    [ApiController]
    [Route(BASE_PATH_EVENT_CONTROLLER)]
    public class EventController : Controller {

        /*------------------------ FIELDS REGION ------------------------*/
        public const string CacheKeyEvents = "events";

        private readonly IEventService _eventService;
        private readonly IMemoryCache _memoryCache;

        /*------------------------ METHODS REGION ------------------------*/
        public EventController(IEventService eventService, IMemoryCache memoryCache) {
            _eventService = eventService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name) {
            IEnumerable<EventDTO> events = _memoryCache.Get<IEnumerable<EventDTO>>(CacheKeyEvents);

            if (events == null) {
                events = await _eventService.SearchByNameAsync(name);
                _memoryCache.Set(CacheKeyEvents, events, TimeSpan.FromMinutes(1));
            }

            return Json(events);
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
        [Authorize(Policy = POLICY_HAS_ADMIN_ROLE)]
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
        [Authorize(Policy = POLICY_HAS_ADMIN_ROLE)]
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
        [Authorize(Policy = POLICY_HAS_ADMIN_ROLE)]
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
