using System.Collections.Generic;
using EventoInfrastructure.DTO.Tickets;

namespace EventoInfrastructure.DTO.Events {

    public class EventDetailsDTO : EventDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public IEnumerable<TicketDTO> Tickets { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
