﻿using System;
using System.Collections.Generic;

namespace EventoCore.Domain {

    public class Event : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly ISet<Ticket> _tickets = new HashSet<Ticket>();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public IEnumerable<Ticket> Tickets => _tickets;

        /*------------------------ METHODS REGION ------------------------*/
        protected Event() {
        }

        public Event(string name, string description, DateTime startDate, DateTime endDate) {
            Name = name;
            Description = description;
            CreateDate = DateTime.UtcNow;
            StartDate = startDate;
            UpdateDate = DateTime.UtcNow;
            EndDate = endDate;
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
                _tickets.Add(new Ticket(seatNumber, price, this));
                seatNumber++;
            }
        }

        protected bool Equals(Event other) {
            return base.Equals(other) && Equals(_tickets, other._tickets) && Name == other.Name &&
                   Description == other.Description && CreateDate.Equals(other.CreateDate) &&
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
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
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
                   $"{nameof(Tickets)}: {Tickets}";
        }

    }

}