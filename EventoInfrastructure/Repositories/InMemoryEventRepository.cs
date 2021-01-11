using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;

namespace EventoInfrastructure.Repositories {

    public class InMemoryEventRepository : IEventRepository {

        /*------------------------ FIELDS REGION ------------------------*/
        private static readonly ISet<Event> _events = new HashSet<Event>();

        /*------------------------ METHODS REGION ------------------------*/
        public async Task<Event> GetByIdAsync(Guid id) {
            return await Task.FromResult(
                _events.SingleOrDefault((@event) => @event.Id == id)
            );
        }

        public async Task<Event> GetByNameAsync(string name) {
            return await Task.FromResult(
                _events.SingleOrDefault((@event) => {
                    return @event.Name.ToLowerInvariant() == name.ToLowerInvariant();
                })
            );
        }

        public async Task<IEnumerable<Event>> SearchByNameAsync(string name = "") {
            IEnumerable<Event> events = _events.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(name)) {
                events = events.Where((@event) => @event.Name.ToLowerInvariant()
                                          .Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(events);
        }

        public async Task AddAsync(Event @event) {
            _events.Add(@event);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Event @event) {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Event @event) {
            _events.Remove(@event);
            await Task.CompletedTask;
        }

    }

}
