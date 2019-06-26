using System;
using System.IO;

namespace Ticket_Master
{
    public class WindowsFileWriter
    {
        private static String REPORT_PATH = @"C:\tickets\\reports\report.txt";


        public void Write(String text)
        {
            Console.WriteLine("Saving report to your local disc at path: " + REPORT_PATH);
            try
            {
                using (StreamWriter file =
                    new StreamWriter(REPORT_PATH, false))
                {
                    file.WriteLine(text);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}