using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static EventoApi.Constants.Constants;

namespace EventoApi {

    public class Program {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static void Main(string[] args) {
            DisplayEndpoints();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }

        private static void DisplayEndpoints() {
            const string separator = "\n------------------------------------------------";
            Console.WriteLine(separator);
            Console.WriteLine("Endpoints List");
            foreach (string endpoint in Endpoints) {
                Console.WriteLine(endpoint);
            }

            Console.WriteLine($"{separator}");
        }

    }

}
