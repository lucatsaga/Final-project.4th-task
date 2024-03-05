using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project._4th_task
{
    public class ConsoleLogger : ILogger
    {

        public void Log(string message, Customer c) => Console.WriteLine(message);
    }
}
