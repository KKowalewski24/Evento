using System.Linq;
using AutoMapper;
using EventoCore.Domain;
using EventoInfrastructure.DTO.Accounts;
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
            config.CreateMap<Event, EventDTO>()
                .ForMember(
                    (eventDto) => eventDto.TicketsCount,
                    (memberConfig) => memberConfig.MapFrom((@event) => @event.Tickets.Count())
                ).ForMember(
                    (eventDto) => eventDto.PurchasedTicketsCount,
                    (memberConfig) => {
                        memberConfig.MapFrom((@event) => @event.PurchasedTickets.Count());
                    }
                ).ForMember(
                    (eventDto) => eventDto.AvailableTicketsCount,
                    (memberConfig) => {
                        memberConfig.MapFrom((@event) => @event.AvailableTickets.Count());
                    }
                );

            config.CreateMap<Event, EventDetailsDTO>();
        }

        private static void ConfigureUserMapping(IMapperConfigurationExpression config) {
            config.CreateMap<User, AccountDTO>();
        }

        private static void ConfigureTicketMapping(IMapperConfigurationExpression config) {
            config.CreateMap<Ticket, TicketDTO>();
        }

    }

}
