using System;
using System.Collections.Generic;
using System.Linq;
using EventoCore.Exceptions.Events;
using EventoCore.Exceptions.Tickets;

namespace EventoCore.Domain {

    public class Event : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly ISet<Ticket> _tickets = new HashSet<Ticket>();
        private string _name;
        private string _description;

        public string Name {
            get => _name;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new NameIsNullOrEmptyValueException();
                }

                _name = value;
                UpdateDate = DateTime.UtcNow;
            }
        }

        public string Description {
            get => _description;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new DescriptionIsNullOrEmptyValueException();
                }

                _description = value;
                UpdateDate = DateTime.UtcNow;
            }
        }

        public DateTime CreateDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public IEnumerable<Ticket> Tickets => _tickets;

        public IEnumerable<Ticket> PurchasedTickets =>
            _tickets.Where((ticket) => ticket.IsPurchased);

        public IEnumerable<Ticket> AvailableTickets =>
            _tickets.Where((ticket) => !ticket.IsPurchased);

        /*------------------------ METHODS REGION ------------------------*/
        protected Event() {
        }

        public Event(Guid id, string name, string description, DateTime startDate, DateTime endDate)
            : base(id) {
            Name = name;
            Description = description;
            CreateDate = DateTime.UtcNow;
            StartDate = startDate;
            UpdateDate = DateTime.UtcNow;
            EndDate = endDate;
        }

        public void AddTickets(int amount, double price) {
            int seatNumber = _tickets.Count + 1;

            for (int i = 0; i < amount; i++) {
                _tickets.Add(new Ticket(seatNumber, price, Id));
                seatNumber++;
            }
        }

        public void PurchaseTickets(User user, int amount) {
            if (AvailableTickets.Count() < amount) {
                throw new TicketsOutOfAmountException();
            }

            foreach (Ticket ticket in AvailableTickets.Take(amount)) {
                ticket.Purchase(user);
            }
        }

        public void CancelPurchasedTickets(User user, int amount) {
            IEnumerable<Ticket> tickets = GetTicketsPurchasedByUser(user);
            if (tickets.Count() < amount) {
                throw new TicketsNotEnoughException();
            }

            foreach (Ticket ticket in tickets.Take(amount)) {
                ticket.Cancel();
            }
        }

        public IEnumerable<Ticket> GetTicketsPurchasedByUser(User user) {
            return PurchasedTickets.Where((ticket) => ticket.UserId == user.Id);
        }

        protected bool Equals(Event other) {
            return base.Equals(other) && Equals(_tickets, other._tickets) && _name == other._name &&
                   _description == other._description && CreateDate.Equals(other.CreateDate) &&
                   StartDate.Equals(other.StartDate) && UpdateDate.Equals(other.UpdateDate) &&
                   EndDate.Equals(other.EndDate);
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

            return Equals((Event)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (_tickets != null ? _tickets.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^
                           (_description != null ? _description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreateDate.GetHashCode();
                hashCode = (hashCode * 397) ^ StartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdateDate.GetHashCode();
                hashCode = (hashCode * 397) ^ EndDate.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Description)}: {Description}, " +
                   $"{nameof(CreateDate)}: {CreateDate}, " +
                   $"{nameof(StartDate)}: {StartDate}, " +
                   $"{nameof(UpdateDate)}: {UpdateDate}, " +
                   $"{nameof(EndDate)}: {EndDate}, " +
                   $"{nameof(Tickets)}: {Tickets}, " +
                   $"{nameof(PurchasedTickets)}: {PurchasedTickets}, " +
                   $"{nameof(AvailableTickets)}: {AvailableTickets}";
        }

    }

}
