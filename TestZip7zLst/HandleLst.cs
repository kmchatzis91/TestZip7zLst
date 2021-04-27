using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestZip7zLst
{
    class HandleLst
    {
        public static void InitHandleLst(string destinationDirectory)
        {
            string lstDestinationDirectory = "The_LST_Directory";
            var lstFiles = Directory.EnumerateFiles(destinationDirectory, "*.lst");
            int numOfLstFiles = lstFiles.ToList().Count();

            CreateLstDirectoryIfMissing(lstDestinationDirectory);

            if (numOfLstFiles > 0)
            {

                Console.WriteLine("\n -- Total .lst files found: {0} -- \n", numOfLstFiles);
                foreach (var lstFile in lstFiles)
                {
                    string lstFileToMove = FindLstFile(lstDestinationDirectory, lstFile);
                    TryMoveLstFile(lstFile, lstFileToMove);
                }
            }
            else
            {
                Console.WriteLine("\n -- No .lst files were found in the given directory! -- \n");
            }

        } // END public static void InitHandleLst(string destinationDirectory)

        private static string FindLstFile(string lstDestinationDirectory, string lstFile)
        {
            Console.WriteLine(lstFile);
            FileInfo lstInfo = new FileInfo(lstFile);
            string lstFileToMove = Path.Combine(lstDestinationDirectory, lstInfo.Name);
            
            return lstFileToMove;

        } // END private static string FindLstFiles(string lstDestinationDirectory, string lstFile)

        private static bool TryMoveLstFile(string lstFile, string lstFileToMove)
        {
            try
            {
                File.Move(lstFile, lstFileToMove);
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return false;
            }

        } // END  private static void TryMoveLstFile(string lstFile, string lstFileToMove)

        private static void CreateLstDirectoryIfMissing(string lstDestinationDirectory)
        {
            bool directoryExists = Directory.Exists(lstDestinationDirectory);

            if (!directoryExists)
            {
                Directory.CreateDirectory(lstDestinationDirectory);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Directory ' {0} ' created!", lstDestinationDirectory);
                Console.ForegroundColor = ConsoleColor.White;
            }

        } // END private static void CreateLstDirectoryIfMissing(string lstDestinationDirectory)

    } // END class HandleLst

} // END namespace TestZip7zLst
