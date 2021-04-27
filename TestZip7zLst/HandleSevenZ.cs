using SevenZipNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestZip7zLst
{
    class HandleSevenZ
    {
        public static void InitHandleSevenZ(string sourceDirectory, string destinationDirectory, string corruptedDirectory)
        {
            var sevenZFiles = Directory.EnumerateFiles(sourceDirectory, "*.7z");

            foreach (var sevenZFile in sevenZFiles)
            {
                FileInfo infoSevenZFile = new FileInfo(sevenZFile);
                string fileSourcePath = Path.Combine(sourceDirectory, infoSevenZFile.Name);

                SevenZipExtractor sze = new SevenZipExtractor(fileSourcePath);
                bool isSevenZFileValid = sze.TestArchive();

                if (isSevenZFileValid == true)
                {
                    sze.ExtractAll(destinationDirectory, false, true);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Corrupted File:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string corruptedFile = FindCorruptedFile(corruptedDirectory, fileSourcePath);
                    TryMoveCorruptedSevenZipFile(fileSourcePath, corruptedFile);
                }
            }

        } // END public static void InitHandleSevenZ(string sourceDirectory, string destinationDirectory, string corruptedDirectory)

        private static string FindCorruptedFile(string corruptedDirectory, string sevenZFile)
        {
            Console.WriteLine(sevenZFile);
            FileInfo info = new FileInfo(sevenZFile);
            string corruptedFile = Path.Combine(corruptedDirectory, info.Name);
            return corruptedFile;

        } // END private static string FindCorruptedFile(string corruptedDirectory, string sevenZFile)

        private static bool TryMoveCorruptedSevenZipFile(string seven7File, string corruptedFile)
        {
            try
            {
                File.Move(seven7File, corruptedFile);
                return true;
            }
            catch (Exception)
            {
                //Console.WriteLine(ex);
                return false;
            }

        } // END private static bool TryMoveCorruptedSevenZipFile(string seven7File, string corruptedFile)

    } // END class HandleSevenZ

} // END namespace TestZip7zLst
