using System;
using EventoCore.Exceptions.Tickets;

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

        public Ticket(int seatNumber, double price, Guid eventId, Guid userId, string userName) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
            UserId = userId;
            UserName = userName;
            PurchaseData = DateTime.UtcNow;
        }

        public Ticket(Guid id, int seatNumber, double price, Guid eventId,
                      Guid userId, string userName)
            : base(id) {
            SeatNumber = seatNumber;
            Price = price;
            EventId = eventId;
            UserId = userId;
            UserName = userName;
            PurchaseData = DateTime.UtcNow;
        }

        public void Purchase(User user) {
            if (IsPurchased) {
                throw new TicketAlreadyPurchased();
            }

            UserId = user.Id;
            UserName = user.Name;
            PurchaseData = DateTime.UtcNow;
        }

        public void Cancel() {
            if (!IsPurchased) {
                throw new TicketNotPurchased();
            }

            UserId = null;
            UserName = null;
            PurchaseData = null;
        }

        protected bool Equals(Ticket other) {
            return base.Equals(other) && SeatNumber == other.SeatNumber &&
                   Price.Equals(other.Price) && EventId.Equals(other.EventId) &&
                   Nullable.Equals(UserId, other.UserId) && UserName == other.UserName &&
                   Nullable.Equals(PurchaseData, other.PurchaseData);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }

            if (ReferenceEquals(this, obj)) {
                return true;
            }

            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((Ticket)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ SeatNumber;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ EventId.GetHashCode();
                hashCode = (hashCode * 397) ^ UserId.GetHashCode();
                hashCode = (hashCode * 397) ^ (UserName != null ? UserName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PurchaseData.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(SeatNumber)}: {SeatNumber}, " +
                   $"{nameof(Price)}: {Price}, " +
                   $"{nameof(EventId)}: {EventId}, " +
                   $"{nameof(UserId)}: {UserId}, " +
                   $"{nameof(UserName)}: {UserName}, " +
                   $"{nameof(PurchaseData)}: {PurchaseData}, " +
                   $"{nameof(IsPurchased)}: {IsPurchased}";
        }

    }

}
