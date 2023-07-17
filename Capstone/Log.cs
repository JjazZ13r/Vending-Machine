using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public static class  Log
    {

        

        //Method to enter each entry in our Log.txt file. Accepts different entries based on the situation.
        public static void LogToFile(string entry)
        {
            string directory = Environment.CurrentDirectory;
            string destinationFileName = "log.txt";
            string destinationPath = Path.Combine(directory, destinationFileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(destinationPath,true))
                {
                    sw.WriteLine($"{DateTime.Now} {entry}");                   
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Sorry there was an error logging to the file");
            }


        }




    }
}
