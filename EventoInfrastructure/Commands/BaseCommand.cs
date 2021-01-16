using System;

namespace EventoInfrastructure.Commands {

    public abstract class BaseCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public Guid Id { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        protected BaseCommand() {
        }

        protected BaseCommand(Guid id) {
            Id = id;
        }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}";
        }

    }

}
