namespace _06.BirthdayCelebrations
{
    public interface IIdable
    {
        string Id { get; }

        bool EndsWith(string end);
    }
}
