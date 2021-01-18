using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventoCore.Domain;
using EventoInfrastructure.Services.Events;
using EventoInfrastructure.Services.Users;
using Microsoft.Extensions.Logging;

namespace EventoInfrastructure.Services.Initializers {

    public class DataInitializer : IDataInitializer {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly ILogger<DataInitializer> _logger;

        /*------------------------ METHODS REGION ------------------------*/
        public DataInitializer(IUserService userService, IEventService eventService,
                               ILogger<DataInitializer> logger) {
            _userService = userService;
            _eventService = eventService;
            _logger = logger;
        }

        public async Task SeedDataAsync() {
            IList<Task> tasks = new List<Task>();
            SeedUsers(tasks);
            SeedEvents(tasks, 10, 1000);
            await Task.WhenAll(tasks);
            _logger.LogInformation("Data has been initialized.");
        }

        private void SeedUsers(IList<Task> tasks) {
            tasks.Add(_userService.RegisterAsync(
                          Guid.NewGuid(), "Default standard user",
                          "user@email.com", "secret_password", UserRole.User
                      )
            );
            tasks.Add(_userService.RegisterAsync(
                          Guid.NewGuid(), "Default admin user",
                          "admin@email.com", "secret_admin_password", UserRole.Admin
                      )
            );
        }

        private void SeedEvents(IList<Task> tasks, int numberOfEvents, int numberOfTicketsInEvent) {
            for (int i = 0; i < numberOfEvents; i++) {
                Guid eventId = Guid.NewGuid();
                string eventName = $"Event {i}";
                string eventDescription = $"{eventName} description.";
                DateTime startDate = DateTime.UtcNow.AddHours(3);
                tasks.Add(_eventService.CreateAsync(
                              eventId, eventName, eventDescription,
                              startDate, startDate.AddHours(2)
                          )
                );
                tasks.Add(_eventService.AddTicketAsync(eventId, numberOfTicketsInEvent, 100));
            }
        }

    }

}
