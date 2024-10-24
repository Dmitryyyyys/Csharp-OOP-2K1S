using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    public class NNDLog
    {
        public static StreamWriter? Logfile;
        public static void WriteToLog(string action, string fileName = "", string path = "")
        {
            using (Logfile = new StreamWriter("C:\\labs\\ооп\\lab 12\\lab 12\\ConsoleApp1\\nndlog.txt", true))
            {
                var time = DateTime.Now;
                Logfile.WriteLine("********************************\n");
                Logfile.WriteLine($"Action: {action}");

                if (fileName.Length != 0)
                    Logfile.WriteLine($"File Name: {fileName}");

                if (path.Length != 0)
                    Logfile.WriteLine($"Path: {path}");

                Logfile.WriteLine($"Date/Time: {time.ToLocalTime()}\n");
            }
        }

        public static void SearchByDate(DateTime date)
        {
            using (var reader = new StringReader(File.ReadAllText("C:\\labs\\ооп\\lab 12\\lab 12\\ConsoleApp1\\nndlog.txt")))
            {
                var lines = reader.ReadToEnd().Split("********************************\n");
                foreach (var line in lines)
                {
                    if (line.Contains(date.ToString()))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
