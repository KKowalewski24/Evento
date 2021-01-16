using System;

namespace EventoInfrastructure.Commands.Events {

    public class CreateEventCommand : BaseCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketsCount { get; set; }
        public double Price { get; private set; }

        /*------------------------ METHODS REGION ------------------------*/
        public CreateEventCommand() {
        }

        public CreateEventCommand(Guid id, string name, string description, DateTime startDate,
                                  DateTime endDate, int ticketsCount, double price)
            : base(id) {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TicketsCount = ticketsCount;
            Price = price;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Description)}: {Description}, " +
                   $"{nameof(StartDate)}: {StartDate}, " +
                   $"{nameof(EndDate)}: {EndDate}, " +
                   $"{nameof(TicketsCount)}: {TicketsCount}, " +
                   $"{nameof(Price)}: {Price}";
        }

    }

}
