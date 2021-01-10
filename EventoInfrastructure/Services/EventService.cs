using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.DTO;
using EventoInfrastructure.Exceptions.Events;

namespace EventoInfrastructure.Services {

    public class EventService : IEventService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        /*------------------------ METHODS REGION ------------------------*/
        public EventService(IEventRepository eventRepository, IMapper mapper) {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventDTO> GetByIdAsync(Guid id) {
            return _mapper.Map<EventDTO>(await _eventRepository.GetByIdAsync(id));
        }

        public async Task<EventDTO> GetByNameAsync(string name) {
            return _mapper.Map<EventDTO>(await _eventRepository.GetByNameAsync(name));
        }

        public async Task<IEnumerable<EventDTO>> SearchByNameAsync(string name = null) {
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
            Event @event = await _eventRepository.GetByIdAsync(eventId);

            if (@event == null) {
                throw new EventNotFoundException();
            }

            @event.AddTickets(amount, price);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task UpdateAsync(Guid eventId, string name, string description) {
            Event @event = await _eventRepository.GetByIdAsync(eventId);
            if (@event == null) {
                throw new EventNotFoundException();
            }

            @event = await _eventRepository.GetByNameAsync(name);
            if (@event != null) {
                throw new EventAlreadyExistsException();
            }

            @event.Name = name;
            @event.Description = description;
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task DeleteByIdAsync(Guid eventId) {

        }

    }

}
