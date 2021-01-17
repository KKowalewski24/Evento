using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.DTO.Events;
using EventoInfrastructure.Exceptions.Events;
using EventoInfrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace EventoInfrastructure.Services.Events {

    public class EventService : IEventService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<EventService> _logger;

        /*------------------------ METHODS REGION ------------------------*/
        public EventService(IEventRepository eventRepository, IMapper mapper,
                            ILogger<EventService> logger) {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EventDetailsDTO> GetByIdAsync(Guid id) {
            return _mapper.Map<EventDetailsDTO>(await _eventRepository.GetByIdAsync(id));
        }

        public async Task<EventDetailsDTO> GetByNameAsync(string name) {
            return _mapper.Map<EventDetailsDTO>(await _eventRepository.GetByNameAsync(name));
        }

        public async Task<IEnumerable<EventDTO>> SearchByNameAsync(string name = null) {
            _logger.LogInformation("Fetching Events");
            return _mapper.Map<IEnumerable<EventDTO>>(
                await _eventRepository.SearchByNameAsync(name)
            );
        }

        public async Task CreateAsync(Guid eventId, string name, string description,
                                      DateTime startDate, DateTime endDate) {
            if (await _eventRepository.GetByNameAsync(name) != null) {
                throw new EventAlreadyExistsException();
            }

            await _eventRepository.AddAsync(
                new Event(eventId, name, description, startDate, endDate)
            );
        }

        public async Task AddTicketAsync(Guid eventId, int amount, double price) {
            Event @event = await _eventRepository.GetEventOrFailAsync(eventId);
            @event.AddTickets(amount, price);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task UpdateAsync(Guid eventId, string name, string description) {
            await _eventRepository.CheckIfEventExists(name);
            Event @event = await _eventRepository.GetEventOrFailAsync(eventId);
            @event.Name = name;
            @event.Description = description;
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task DeleteByIdAsync(Guid eventId) {
            await _eventRepository.DeleteAsync(await _eventRepository.GetEventOrFailAsync(eventId));
        }

    }

}
