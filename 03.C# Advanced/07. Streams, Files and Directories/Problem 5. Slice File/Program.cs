using System;
using System.IO;

namespace Problem_5._Slice_File
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = 4;


            using (var streamReadFile = new FileStream(@"Resources/05. Slice File/sliceMe.txt", FileMode.Open))
            {

                long pieceSize = (long) Math.Ceiling((double) streamReadFile.Length / parts);

                for (int i = 1; i <= parts; i++)
                {

                    long currentPieceSize = 0;
                    string currentFileName = $"{i}. Part.txt";

                    using (var streamCreateFile = new FileStream($@"Resources/05. Slice File/{currentFileName}",
                        FileMode.Create))
                    {

                        byte[] buffer = new byte[4096];

                        while ((streamReadFile.Read(buffer, 0, buffer.Length)) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;
                            streamCreateFile.Write(buffer, 0, buffer.Length);

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }


        }
    }
}
