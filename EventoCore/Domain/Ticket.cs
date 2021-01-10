using System;

namespace EventoCore.Domain {

    public class Ticket : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        public int SeatNumber { get; private set; }
        public double Price { get; private set; }
        public Event Event { get; private set; }
        public User User { get; private set; }
        public DateTime? PurchaseData { get; private set; }
        public bool IsPurchased => PurchaseData.HasValue;

        /*------------------------ METHODS REGION ------------------------*/
        protected Ticket() {
        }

        public Ticket(int seatNumber, double price, Event @event) {
            SeatNumber = seatNumber;
            Price = price;
            Event = @event;
        }

        public Ticket(Guid id, int seatNumber, double price, Event @event)
            : base(id) {
            SeatNumber = seatNumber;
            Price = price;
            Event = @event;
        }

        public Ticket(int seatNumber, double price, Event @event, User user) {
            SeatNumber = seatNumber;
            Price = price;
            Event = @event;
            User = user;
            PurchaseData = DateTime.UtcNow;
        }

        public Ticket(Guid id, int seatNumber, double price, Event @event, User user)
            : base(id) {
            SeatNumber = seatNumber;
            Price = price;
            Event = @event;
            User = user;
            PurchaseData = DateTime.UtcNow;
        }

    }

}
