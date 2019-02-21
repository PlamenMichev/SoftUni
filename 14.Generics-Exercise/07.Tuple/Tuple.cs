using System.Text;

namespace _07.Tuple
{
    public class Tuple<T, K>
    {
        public Tuple(T item1, K item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        private T item1;

        private K item2;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.item1} -> {this.item2}");

            return sb.ToString().TrimEnd();
        }
    }
}
