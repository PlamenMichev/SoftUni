namespace _05.BorderControl
{
    public interface IIdable
    {
        string Id { get; }

        bool EndsWith(string end);
    }
}
