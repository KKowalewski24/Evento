using System;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;
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

    }

}
