namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get => this.driver;
            private set
            {
                this.driver = value;
            }
        }

        public string Model { get; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{model}/{this.Brakes()}/{this.Gas()}/{this.driver}";
        }
    }
}
