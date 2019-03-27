using _01.Logger.Loggers.Contracts;
using System.Linq;

namespace _01.LoggerLibrary.Loggers
{
    class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(x => char.IsLetter(x)).Sum(x => x);
        }
    }
}
