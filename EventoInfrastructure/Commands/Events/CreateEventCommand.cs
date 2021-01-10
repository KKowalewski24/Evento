using System;

namespace EventoInfrastructure.Commands.Events {

    public class CreateEventCommand : BaseCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketsCount { get; set; }
        public double Price { get; private set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
