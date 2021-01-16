using System;

namespace EventoInfrastructure.Commands.Events {

    public class UpdateEventCommand : BaseCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Description { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public UpdateEventCommand() {
        }

        public UpdateEventCommand(Guid id, string name, string description)
            : base(id) {
            Name = name;
            Description = description;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Description)}: {Description}";
        }

    }

}
