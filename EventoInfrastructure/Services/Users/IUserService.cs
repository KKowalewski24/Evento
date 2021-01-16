using System;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoInfrastructure.DTO.Accounts;
using EventoInfrastructure.DTO.Jwt;

namespace EventoInfrastructure.Services.Users {

    public interface IUserService {

        Task<AccountDTO> GetAccountAsync(Guid userId);

        Task RegisterAsync(Guid id, string name, string email, string password, UserRole role);

        Task<TokenDTO> LoginAsync(string email, string password);

    }

}
