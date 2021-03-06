﻿using System;
using System.Threading.Tasks;
using EventoCore.Domain;

namespace EventoCore.Repositories {

    public interface IUserRepository {

        Task<User> GetByIdAsync(Guid id);

        Task<User> GetByEmailAsync(string email);

        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);

    }

}
