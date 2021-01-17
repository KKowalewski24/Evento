using System;

namespace EventoInfrastructure.DTO.Events {

    public class EventDTO : BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketsCount { get; set; }
        public int PurchasedTicketsCount { get; set; }
        public int AvailableTicketsCount { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public EventDTO() {
        }

        public EventDTO(Guid id, string name, string description, DateTime startDate,
                        DateTime updateDate, DateTime endDate, int ticketsCount,
                        int purchasedTicketsCount, int availableTicketsCount)
            : base(id) {
            Name = name;
            Description = description;
            StartDate = startDate;
            UpdateDate = updateDate;
            EndDate = endDate;
            TicketsCount = ticketsCount;
            PurchasedTicketsCount = purchasedTicketsCount;
            AvailableTicketsCount = availableTicketsCount;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Description)}: {Description}, " +
                   $"{nameof(StartDate)}: {StartDate}, " +
                   $"{nameof(UpdateDate)}: {UpdateDate}, " +
                   $"{nameof(EndDate)}: {EndDate}, " +
                   $"{nameof(TicketsCount)}: {TicketsCount}, " +
                   $"{nameof(PurchasedTicketsCount)}: {PurchasedTicketsCount}, " +
                   $"{nameof(AvailableTicketsCount)}: {AvailableTicketsCount}, ";
        }

    }

}
