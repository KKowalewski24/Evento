using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.DTO;

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

        public async Task CreateAsync(string name, string description,
                                      DateTime startDate, DateTime endDate) {

        }

        public async Task AddTicketAsync(Event @event, int amount, double price) {

        }

        public async Task UpdateAsync(Guid id, string name, string description) {

        }

        public async Task DeleteByIdAsync(Guid id) {

        }

    }

}
