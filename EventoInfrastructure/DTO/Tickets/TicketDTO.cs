using System;

namespace EventoInfrastructure.DTO.Tickets {

    public class TicketDTO : BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public int SeatNumber { get; set; }
        public double Price { get; set; }
        public Guid EventId { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool IsPurchased { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public TicketDTO() {
        }

        public TicketDTO(Guid id, int seatNumber, double price, Guid eventId, Guid? userId,
                         string userName, DateTime? purchaseDate, bool isPurchased)
            : base(id) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
            UserId = userId;
            UserName = userName;
            PurchaseDate = purchaseDate;
            IsPurchased = isPurchased;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(SeatNumber)}: {SeatNumber}," +
                   $" {nameof(Price)}: {Price}," +
                   $" {nameof(EventId)}: {EventId}, " +
                   $"{nameof(UserId)}: {UserId}, " +
                   $"{nameof(UserName)}: {UserName}, " +
                   $"{nameof(PurchaseDate)}: {PurchaseDate}, " +
                   $"{nameof(IsPurchased)}: {IsPurchased}";
        }

    }

}
