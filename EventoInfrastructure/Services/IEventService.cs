using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoInfrastructure.DTO;

namespace EventoInfrastructure.Services {

    public interface IEventService {

        Task<EventDTO> GetByIdAsync(Guid id);

        Task<EventDTO> GetByNameAsync(string name);

        Task<IEnumerable<EventDTO>> SearchByNameAsync(string name = null);

        Task CreateAsync(string name, string description, DateTime startDate, DateTime endDate);

        Task AddTicketAsync(Event @event, int amount, double price);

        Task UpdateAsync(Guid id, string name, string description);

        Task DeleteByIdAsync(Guid id);

    }

}
