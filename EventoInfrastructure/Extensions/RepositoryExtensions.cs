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
                                                            Guid id, string exceptionMessage = "") {
            Event @event = await eventRepository.GetByIdAsync(id);
            if (@event == null) {
                throw new EventNotFoundException(exceptionMessage);
            }

            return @event;
        }

        public static async Task CheckIfEventExists(this IEventRepository eventRepository,
                                                    string name, string exceptionMessage = "") {
            if (await eventRepository.GetByNameAsync(name) != null) {
                throw new EventAlreadyExistsException(exceptionMessage);
            }
        }

        public static async Task<User> GetUserOrFailAsync(this IUserRepository userRepository,
                                                          Guid id, string exceptionMessage = "") {
            User user = await userRepository.GetByIdAsync(id);
            if (user == null) {
                throw new UserNotFoundException(exceptionMessage);
            }

            return user;
        }

        public static async Task<User> GetUserOrFailAsync(this IUserRepository userRepository,
                                                          string email,
                                                          string exceptionMessage = "") {
            User user = await userRepository.GetByEmailAsync(email);
            if (user == null) {
                throw new UserNotFoundException(exceptionMessage);
            }

            return user;
        }

        public static async Task CheckIfUserExists(this IUserRepository userRepository,
                                                   string email, string exceptionMessage = "") {
            if (await userRepository.GetByEmailAsync(email) != null) {
                throw new UserAlreadyExistsException(exceptionMessage);
            }
        }

    }

}
