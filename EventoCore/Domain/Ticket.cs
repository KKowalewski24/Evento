using System;

namespace EventoCore.Domain {

    public class Ticket : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        public int SeatNumber { get; private set; }
        public double Price { get; private set; }
        public Guid EventId { get; private set; }
        public Guid? UserId { get; private set; }
        public string UserName { get; private set; }
        public DateTime? PurchaseData { get; private set; }
        public bool IsPurchased => PurchaseData.HasValue;

        /*------------------------ METHODS REGION ------------------------*/
        protected Ticket() {
        }

        public Ticket(int seatNumber, double price, Guid eventId) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
        }

        public Ticket(Guid id, int seatNumber, double price, Guid eventId)
            : base(id) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
        }

        public Ticket(int seatNumber, double price, Guid eventId, Guid userId) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
            UserId = userId;
            PurchaseData = DateTime.UtcNow;
        }

        public Ticket(Guid id, int seatNumber, double price, Guid eventId, Guid userId)
            : base(id) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
            UserId = userId;
            PurchaseData = DateTime.UtcNow;
        }

    }

}
