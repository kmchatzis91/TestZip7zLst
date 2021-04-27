using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestZip7zLst
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Paths
            string sourceDirectory = "The_Source_Directory";
            string destinationDirectory = "The_Destination_Directory";
            string corruptedDirectory = "The_Destination_Directory";
            #endregion

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n *** .zip Files *** ");
            Console.ForegroundColor = ConsoleColor.White;
            HandleZip.InitHandleZip(sourceDirectory, destinationDirectory, corruptedDirectory);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n *** .7z Files *** ");
            Console.ForegroundColor = ConsoleColor.White;
            HandleSevenZ.InitHandleSevenZ(sourceDirectory, destinationDirectory, corruptedDirectory);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n *** .lst Files *** ");
            Console.ForegroundColor = ConsoleColor.White;
            HandleLst.InitHandleLst(destinationDirectory);

        } // END static void Main(string[] args)

    } // END class Program

} // END namespace TestZip7zLst
