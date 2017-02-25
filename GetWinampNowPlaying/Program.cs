using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace GetWinampNowPlaying
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if(process.ProcessName == "winamp")
                    {
                        string returnData = "Now playing: " + process.MainWindowTitle.Replace(" - Winamp", "");
                        Console.WriteLine(returnData);
                    }
                }
            }
        }
    }
}
