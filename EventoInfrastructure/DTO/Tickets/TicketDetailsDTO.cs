using System;

namespace EventoInfrastructure.DTO.Tickets {

    public class TicketDetailsDTO : TicketDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string EventName { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public TicketDetailsDTO() {
        }

        public TicketDetailsDTO(Guid id, int seatNumber, double price, Guid eventId,
                                Guid? userId, string userName, DateTime? purchaseDate,
                                bool isPurchased, string eventName)
            : base(id, seatNumber, price, eventId, userId, userName, purchaseDate, isPurchased) {
            EventName = eventName;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(EventName)}: {EventName}";
        }

    }

}
