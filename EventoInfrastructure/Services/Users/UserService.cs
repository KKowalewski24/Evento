using System;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.Exceptions.Users;
using EventoInfrastructure.Extensions;

namespace EventoInfrastructure.Services.Users {

    public class UserService : IUserService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IUserRepository _userRepository;

        /*------------------------ METHODS REGION ------------------------*/
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(Guid id, string name, string email,
                                        string password, UserRole role) {
            await _userRepository.CheckIfUserExists(email);
            await _userRepository.AddAsync(new User(id, name, email, password, role));
        }

        public async Task LoginAsync(string email, string password) {
            const string invalidCredentials = "Invalid Credentials";
            User user = await _userRepository.GetUserOrFailAsync(email, invalidCredentials);

            if (user.Password != password) {
                throw new UserNotFoundException(invalidCredentials);
            }
        }

    }

}
