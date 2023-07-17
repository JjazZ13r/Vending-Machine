using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;

namespace Capstone 
{
    public class SaleReportLogger
    {
        //Write to our Sale Report .txt file. The file name has a datestamp so a new one generates daily.
        public static void LogToSaleReport(List<string> salesReport)
        {
            string currentDate = DateAndTime.DateString;
            string directory = Environment.CurrentDirectory;
            string destinationFileName = $"SaleReport{currentDate}.txt";           
            string destinationPath = Path.Combine(directory, destinationFileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(destinationPath))
                {
                    foreach(string line in salesReport)
                    {   
                        //Write each item in the SalesReport list to the file
                        sw.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Sorry there was an error logging to the file");
            }
        }

        

       





      


    }
}

    
