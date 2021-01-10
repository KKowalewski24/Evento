using System;

namespace EventoInfrastructure.DTO {

    public class EventDTO : BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketsCount { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
