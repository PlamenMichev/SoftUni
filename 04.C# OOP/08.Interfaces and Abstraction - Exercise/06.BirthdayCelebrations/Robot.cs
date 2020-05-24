namespace _06.BirthdayCelebrations
{
    public class Robot : IIdable
    {
        private string id;
        private string model;

        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }


        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }

        public string Model
        {
            get => this.model;
            set
            {
                this.model = value;
            }
        }

        public bool EndsWith(string end)
        {
            return this.id.EndsWith(end);
        }
    }
}
