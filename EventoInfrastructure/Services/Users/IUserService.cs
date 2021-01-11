using System;
using System.Threading.Tasks;
using EventoCore.Domain;

namespace EventoInfrastructure.Services.Users {

    public interface IUserService {

        Task RegisterAsync(Guid id, string name, string email, string password, UserRole role);

        Task LoginAsync(string email, string password);

    }

}
