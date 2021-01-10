using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventoCore.Domain;

namespace EventoCore.Repositories {

    public interface IEventRepository {

        Task<Event> GetByIdAsync(Guid id);

        Task<Event> GetByNameAsync(string name);

        Task<IEnumerable<Event>> SearchByNameAsync(string name = "");

        Task AddAsync(Event @event);

        Task UpdateAsync(Event @event);

        Task DeleteAsync(Event @event);

    }

}
