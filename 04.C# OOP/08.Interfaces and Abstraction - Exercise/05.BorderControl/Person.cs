namespace _05.BorderControl
{
    public class Person : IIdable
    {
        private string name;
        private string id;
        private int age;

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }

        public bool EndsWith(string end)
        {
            return this.id.EndsWith(end);
        }
    }
}
