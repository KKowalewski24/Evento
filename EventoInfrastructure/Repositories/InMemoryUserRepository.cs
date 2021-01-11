using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;

namespace EventoInfrastructure.Repositories {

    public class InMemoryUserRepository : IUserRepository {

        /*------------------------ FIELDS REGION ------------------------*/
        private static readonly ISet<User> _users = new HashSet<User>();

        /*------------------------ METHODS REGION ------------------------*/
        public async Task<User> GetByIdAsync(Guid id) {
            return await Task.FromResult(
                _users.SingleOrDefault((user) => user.Id == id)
            );
        }

        public async Task<User> GetByEmailAsync(string email) {
            return await Task.FromResult(
                _users.SingleOrDefault((user) => {
                    return user.Email.ToLowerInvariant() == email.ToLowerInvariant();
                })
            );
        }

        public async Task AddAsync(User user) {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user) {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(User user) {
            _users.Remove(user);
            await Task.CompletedTask;
        }

    }

}
