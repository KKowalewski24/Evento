using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.DTO.Tickets;
using EventoInfrastructure.Extensions;

namespace EventoInfrastructure.Services.Tickets {

    public class TicketService : ITicketService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        /*------------------------ METHODS REGION ------------------------*/
        public TicketService(IUserRepository userRepository,
                             IEventRepository eventRepository, IMapper mapper) {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<TicketDTO> GetAsync(Guid userId, Guid EventId, Guid ticketId) {
            User user = await _userRepository.GetUserOrFailAsync(userId);
            Ticket ticket = await _eventRepository.GetTicketOrFailAsync(EventId, ticketId);

            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task<IEnumerable<TicketDetailsDTO>> GetTicketsForUserAsync(Guid userId) {
            User user = await _userRepository.GetUserOrFailAsync(userId);
            IEnumerable<Event> events = await _eventRepository.SearchByNameAsync();
            List<TicketDetailsDTO> allTickets = new List<TicketDetailsDTO>();

            foreach (Event @event in events) {
                List<TicketDetailsDTO> ticketDetailsDtos = _mapper
                    .Map<IEnumerable<TicketDetailsDTO>>(@event.GetTicketsPurchasedByUser(user))
                    .ToList();

                foreach (TicketDetailsDTO ticket in ticketDetailsDtos) {
                    ticket.EventId = @event.Id;
                    ticket.EventName = @event.Name;
                }

                allTickets.AddRange(ticketDetailsDtos);
            }

            return allTickets;
        }

        public async Task PurchaseAsync(Guid userId, Guid eventId, int amount) {
            (User user, Event @event) = await FetchUserAndEvent(userId, eventId);
            @event.PurchaseTickets(user, amount);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task CancelAsync(Guid userId, Guid eventId, int amount) {
            (User user, Event @event) = await FetchUserAndEvent(userId, eventId);
            @event.CancelPurchasedTickets(user, amount);
            await _eventRepository.UpdateAsync(@event);
        }

        private async Task<(User, Event)> FetchUserAndEvent(Guid userId, Guid eventId) {
            User user = await _userRepository.GetUserOrFailAsync(userId);
            Event @event = await _eventRepository.GetEventOrFailAsync(eventId);

            return (user, @event);
        }

    }

}
