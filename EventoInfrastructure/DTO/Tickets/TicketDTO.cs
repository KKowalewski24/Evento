using System;

namespace EventoInfrastructure.DTO.Tickets {

    public class TicketDTO : BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public int SeatNumber { get; set; }
        public double Price { get; set; }
        public Guid EventId { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? PurchaseData { get; set; }
        public bool IsPurchased { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
