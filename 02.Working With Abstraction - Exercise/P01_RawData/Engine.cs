namespace P01_RawData
{
    public class Engine
    {
        private int speed;

        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.Power = power;
        }

        public int Power { get; private set; }
    }
}
