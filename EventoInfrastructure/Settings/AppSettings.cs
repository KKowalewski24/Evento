namespace EventoInfrastructure.Settings {

    public class AppSettings {

        /*------------------------ FIELDS REGION ------------------------*/
        public bool SeedData { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public AppSettings() {
        }

        public AppSettings(bool seedData) {
            SeedData = seedData;
        }

        public override string ToString() {
            return $"{nameof(SeedData)}: {SeedData}";
        }

    }

}
