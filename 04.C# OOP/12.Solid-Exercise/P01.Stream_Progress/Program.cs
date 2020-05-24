using System;
using P01.Stream_Progress;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music music = new Music("Az", "Vecherq", 32, 10);
            File file = new File("Kenef", 12, 3);

            StreamProgressInfo stream = new StreamProgressInfo(file);

            Console.WriteLine(stream.CalculateCurrentPercent());
            
        }
    }
}
