using System;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.Exceptions.Events;
using EventoInfrastructure.Exceptions.Users;

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

        public static async Task<User> GetUserOrFailAsync(this IUserRepository userRepository,
                                                          Guid id) {
            User user = await userRepository.GetByIdAsync(id);
            if (user == null) {
                throw new UserNotFoundException();
            }

            return user;
        }

        public static async Task CheckIfUserExists(this IUserRepository userRepository,
                                                   string email) {
            if (await userRepository.GetByEmailAsync(email) != null) {
                throw new UserAlreadyExistsException();
            }
        }

    }

}
