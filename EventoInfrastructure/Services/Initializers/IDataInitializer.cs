using System.Threading.Tasks;

namespace EventoInfrastructure.Services.Initializers {

    public interface IDataInitializer {

        Task SeedDataAsync();

    }

}
