using System;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.Exceptions.Events;

namespace EventoInfrastructure.Extensions {

    public static class RepositoryExtensions {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static async Task<Event> GetEventOrFailAsync(this IEventRepository eventRepository,
                                                            Guid id) {
            Event @event = await eventRepository.GetByIdAsync(id);
            if (@event == null) {
                throw new EventNotFoundException();
            }

            return @event;
        }

        public static async Task CheckIfEventExists(this IEventRepository eventRepository,
                                                    string name) {
            if (await eventRepository.GetByNameAsync(name) != null) {
                throw new EventAlreadyExistsException();
            }
        }

    }

}
