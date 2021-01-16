using System;
using System.Collections.Generic;
using EventoInfrastructure.DTO.Tickets;

namespace EventoInfrastructure.DTO.Events {

    public class EventDetailsDTO : EventDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public IEnumerable<TicketDTO> Tickets { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public EventDetailsDTO() {
        }

        public EventDetailsDTO(Guid id, string name, string description, DateTime startDate,
                               DateTime updateDate, DateTime endDate, int ticketsCount,
                               IEnumerable<TicketDTO> tickets)
            : base(id, name, description, startDate, updateDate, endDate, ticketsCount) {
            Tickets = tickets;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Tickets)}: {Tickets}";
        }

    }

}
