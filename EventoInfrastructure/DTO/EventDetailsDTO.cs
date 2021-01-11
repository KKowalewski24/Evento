using System.Collections.Generic;

namespace EventoInfrastructure.DTO {

    public class EventDetailsDTO : EventDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public IEnumerable<TicketDTO> Tickets { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
