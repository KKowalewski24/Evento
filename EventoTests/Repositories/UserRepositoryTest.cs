using System;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.Repositories;
using NUnit.Framework;

namespace EventoTests.Repositories {

    public class UserRepositoryTest {

        /*------------------------ FIELDS REGION ------------------------*/
        private IUserRepository _userRepository;

        /*------------------------ METHODS REGION ------------------------*/
        [OneTimeSetUp]
        public void Init() {
        }

        [SetUp]
        public void Setup() {
            _userRepository = new InMemoryUserRepository();
        }

        [Test]
        public async Task AddNewUser_CheckIfIsOnList() {
            User user = new User(
                Guid.NewGuid(), "user",
                "user@email.com", "secret_password", UserRole.User
            );

            await _userRepository.AddAsync(user);
            User fetchedUser = await _userRepository.GetByIdAsync(user.Id);
            Assert.AreEqual(user, fetchedUser);
        }

    }

}
