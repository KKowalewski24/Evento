using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventoInfrastructure.DTO;

namespace EventoInfrastructure.Services {

    public interface IEventService {

        Task<EventDetailsDTO> GetByIdAsync(Guid id);

        Task<EventDetailsDTO> GetByNameAsync(string name);

        Task<IEnumerable<EventDTO>> SearchByNameAsync(string name = null);

        Task CreateAsync(Guid eventId, string name, string description,
                         DateTime startDate, DateTime endDate);

        Task AddTicketAsync(Guid eventId, int amount, double price);

        Task UpdateAsync(Guid eventId, string name, string description);

        Task DeleteByIdAsync(Guid eventId);

    }

}
