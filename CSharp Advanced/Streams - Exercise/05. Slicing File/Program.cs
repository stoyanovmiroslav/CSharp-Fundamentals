using System;
using System.Collections.Generic;
using System.IO;

namespace _05._Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinationDirectory = "../Resource/";
            string sourceFile = "../Resource/sliceMe.mp4";
            int parts = 5;
            List<string> files = new List<string> { "Part-0.mp4", "Part-1.mp4", "Part-2.mp4", "Part-3.mp4", "Part-4.mp4" };

            Slice(sourceFile, destinationDirectory, parts);
            Assemble(files, destinationDirectory);


        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string assembledSourceFile = "../Resource/assembled." + files[0].Substring(files[0].LastIndexOf(".") + 1);
            using (var streamWriter = new FileStream(assembledSourceFile, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
            {
                string sourceFile = destinationDirectory + files[i];

                
                    using (var streamReader = new FileStream(sourceFile, FileMode.Open))
                    {
                        byte[] buffer = new byte[4096];

                        while (streamReader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            streamWriter.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }



        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var streamReadFile = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);
                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }
                    string currentPath = destinationDirectory + $"Part-{i}.{extension}";

                    using (var streamCreateFile = new FileStream(currentPath, FileMode.Create))
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

