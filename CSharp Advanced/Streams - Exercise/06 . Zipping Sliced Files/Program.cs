using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06_._Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinationDirectory = "../Resource/";
            string sourceFile = "../Resource/sliceMe.mp4";
            int parts = 5;
            List<string> files = new List<string> { "Part-0.mp4.gz", "Part-1.mp4.gz", "Part-2.mp4.gz", "Part-3.mp4.gz", "Part-4.mp4.gz" };

            Zip(sourceFile, destinationDirectory, parts);
            Assemble(files, destinationDirectory);


        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string takeFirstExtansion = files[0].Substring(0, files[0].LastIndexOf("."));
            string assembledSourceFile = "../Resource/assembled." + takeFirstExtansion.Substring(takeFirstExtansion.LastIndexOf(".") + 1);
            using (var streamWriter = new FileStream(assembledSourceFile, FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string sourceFile = destinationDirectory + files[i];


                    using (var streamReader = new GZipStream(new FileStream(sourceFile, FileMode.Open), CompressionMode.Decompress))
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



        private static void Zip(string sourceFile, string destinationDirectory, int parts)
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
                    string currentPath = destinationDirectory + $"Part-{i}.{extension}.gz";

                    using (var streamCreateFile = new GZipStream( new FileStream(currentPath, FileMode.Create), CompressionLevel.Optimal))
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
