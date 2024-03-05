using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project._4th_task
{
    public class FileLogger

    {

        private const string _filePath = @"../../../FileLogger.txt";
        public static void Log(string message, Customer customer)
        {
            string logEntry = $"{DateTime.Now}: {message}\n";

            // Ensure the file is opened in Append mode with the correct encoding
            using (StreamWriter sw = new StreamWriter(_filePath, true, Encoding.UTF8))
            {
                sw.WriteLine(logEntry);
            }
        }

    }
}
