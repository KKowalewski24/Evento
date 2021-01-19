using System;
using System.Threading.Tasks;
using AutoMapper;
using EventoCore.Domain;
using EventoCore.Repositories;
using EventoInfrastructure.DTO.Accounts;
using EventoInfrastructure.Services.Jwt;
using EventoInfrastructure.Services.Users;
using Moq;
using NUnit.Framework;

namespace EventoTests.Services {

    public class UserServiceTest {

        /*------------------------ FIELDS REGION ------------------------*/
        private IUserService _userService;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IJwtService> _jwtServiceMock;
        private Mock<IMapper> _mapperMock;

        /*------------------------ METHODS REGION ------------------------*/
        [SetUp]
        public void Setup() {
            _userRepositoryMock = new Mock<IUserRepository>();
            _jwtServiceMock = new Mock<IJwtService>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(
                _userRepositoryMock.Object, _jwtServiceMock.Object, _mapperMock.Object
            );
        }

        [Test]
        public async Task RegisterAsync_CheckIfUserExists() {
            await _userService.RegisterAsync(
                Guid.NewGuid(), "Default standard user",
                "user@email.com", "secret_password", UserRole.User
            );

            _userRepositoryMock.Verify(
                (userRepository) => userRepository.AddAsync(It.IsAny<User>()),
                Times.Once
            );

        }

        [Test]
        public async Task GetAccountAsync_CheckIfAccountExistsAndGetByIdAsyncCalledOnce() {
            User user = new User(
                Guid.NewGuid(), "user",
                "user@email.com", "secret_password", UserRole.User
            );

            AccountDTO accountDto = new AccountDTO(user.Id, user.Name, user.Email, user.Role);

            _userRepositoryMock
                .Setup((userRepository) => userRepository.GetByIdAsync(user.Id))
                .ReturnsAsync(user);

            _mapperMock
                .Setup((mapper) => mapper.Map<AccountDTO>(user))
                .Returns(accountDto);

            AccountDTO fetchedAccountDto = await _userService.GetAccountAsync(user.Id);
            _userRepositoryMock.Verify(
                (userRepository) => userRepository.GetByIdAsync(user.Id),
                Times.Once
            );
            Assert.NotNull(fetchedAccountDto);
        }

    }

}
