using System;
using System.Threading.Tasks;
using EventoCore.Domain;

namespace EventoCore.Repositories {

    public interface IUserRepository {

        Task<User> GetByIdAsync(Guid id);

        Task<User> GetByEmailAsync(string email);

        Task<User> AddAsync(User user);

        Task<User> UpdateAsync(User user);

        Task<User> DeleteAsync(User user);

    }

}
