using System;
using System.Threading.Tasks;
using AutoMapper;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoCore.Security;
using EventoInfrastructure.DTO.Accounts;
using EventoInfrastructure.DTO.Jwt;
using EventoInfrastructure.Exceptions.Users;
using EventoInfrastructure.Extensions;
using EventoInfrastructure.Services.Jwt;

namespace EventoInfrastructure.Services.Users {

    public class UserService : IUserService {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        /*------------------------ METHODS REGION ------------------------*/
        public UserService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper) {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<AccountDTO> GetAccountAsync(Guid userId) {
            return _mapper.Map<AccountDTO>(await _userRepository.GetUserOrFailAsync(userId));
        }

        public async Task RegisterAsync(Guid id, string name, string email,
                                        string password, UserRole role) {
            await _userRepository.CheckIfUserExists(email);
            await _userRepository.AddAsync(new User(id, name, email, password, role));
        }

        public async Task<TokenDTO> LoginAsync(string email, string password) {
            const string invalidCredentials = "Invalid Credentials";
            User user = await _userRepository.GetUserOrFailAsync(email, invalidCredentials);

            if (user.Password != new HashingProvider().ComputeHashFromStringToString(password)) {
                throw new UserNotFoundException(invalidCredentials);
            }

            JwtDTO jwtDto = _jwtService.CreateToken(user.Id, user.Role);

            return new TokenDTO(jwtDto.Token, jwtDto.ExpiryTime, user.Role);
        }

    }

}
