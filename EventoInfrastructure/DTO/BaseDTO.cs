﻿using System;

namespace EventoInfrastructure.DTO {

    public abstract class BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public Guid Id { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public BaseDTO() {
        }

        public BaseDTO(Guid id) {
            Id = id;
        }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}";
        }

    }

}
