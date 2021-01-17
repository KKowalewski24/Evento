using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventoInfrastructure.DTO.Tickets;

namespace EventoInfrastructure.Services.Tickets {

    public interface ITicketService {

        Task<TicketDTO> GetAsync(Guid userId, Guid EventId, Guid ticketId);

        Task<IEnumerable<TicketDetailsDTO>> GetTicketsForUserAsync(Guid userId);

        Task PurchaseAsync(Guid userId, Guid eventId, int amount);

        Task CancelAsync(Guid userId, Guid eventId, int amount);

    }

}
