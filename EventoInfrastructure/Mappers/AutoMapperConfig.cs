using System.Linq;
using AutoMapper;
using EventoCore.Domain;
using EventoInfrastructure.DTO.Events;
using EventoInfrastructure.DTO.Tickets;

namespace EventoInfrastructure.Mappers {

    public static class AutoMapperConfig {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static IMapper Initialize() {
            return new MapperConfiguration((config) => {
                ConfigureEventMapping(config);
                ConfigureUserMapping(config);
                ConfigureTicketMapping(config);
            }).CreateMapper();
        }

        private static void ConfigureEventMapping(IMapperConfigurationExpression config) {
            config.CreateMap<Event, EventDTO>().ForMember(
                (eventDto) => eventDto.TicketsCount,
                (memberConfig) => memberConfig.MapFrom((a) => a.Tickets.Count())
            );

            config.CreateMap<Event, EventDetailsDTO>();
        }

        private static void ConfigureUserMapping(IMapperConfigurationExpression config) {
            /*TODO*/
        }

        private static void ConfigureTicketMapping(IMapperConfigurationExpression config) {
            config.CreateMap<Ticket, TicketDTO>();
        }

    }

}
