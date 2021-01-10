using System;

namespace EventoInfrastructure.DTO {

    public class BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public Guid Id { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public BaseDTO() {
        }

        public BaseDTO(Guid id) {
            Id = id;
        }

    }

}
