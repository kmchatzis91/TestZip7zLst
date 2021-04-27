using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestZip7zLst
{
    class HandleZip
    {
        public static void InitHandleZip(string sourceDirectory, string destinationDirectory, string corruptedDirectory)
        {
            var zipFiles = Directory.EnumerateFiles(sourceDirectory, "*.zip");
            InitZipHandler(zipFiles, destinationDirectory, corruptedDirectory);

        } // END public static void InitHandleZip(string sourceDirectory, string destinationDirectory, string corruptedDirectory)

        private static void InitZipHandler(IEnumerable<string> zipFiles, string destinationDirectory, string corruptedDirectory)
        {
            foreach (string zip in zipFiles)
            {
                try
                {
                    ExtractZipFiles(destinationDirectory, zip);
                }
                catch (ZipException zipException)
                {
                    //Console.WriteLine(zipException);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Corrupted File:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string corruptedFile = FindCorruptedZipFiles(corruptedDirectory, zip);
                    TryMoveCorruptedZipFile(zip, corruptedFile);
                }
            }

        } // END private static void InitZipHandle(IEnumerable<string> zipFiles, string destinationDirectory, string corruptedDirectory)

        private static void ExtractZipFiles(string destinationDirectory, string zip)
        {
            ZipFile zipFile = ZipFile.Read(zip);
            foreach (ZipEntry zipEntry in zipFile)
            {
                zipEntry.Extract(destinationDirectory, ExtractExistingFileAction.OverwriteSilently);
            }

        } // END private static void ExtractZipFiles(string destinationDirectory, string zip)

        private static string FindCorruptedZipFiles(string corruptedDirectory, string zip)
        {
            Console.WriteLine(zip);
            FileInfo info = new FileInfo(zip);
            string corruptedFile = Path.Combine(corruptedDirectory, info.Name);
            return corruptedFile;

        } // END private static string FindCorruptedZipFiles(string corruptedDirectory, string zip)

        private static bool TryMoveCorruptedZipFile(string zipFile, string corruptedFile)
        {
            try
            {
                File.Move(zipFile, corruptedFile);
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return false;
            }

        } // END private static bool TryMoveCorruptedZipFile(string zipFile, string corruptedFile)

    } // END class HandleZip

} // END namespace TestZip7zLst
