using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                        Regex r = new Regex(@"^([0-9]+)\. (.*?) - (.*?) - Winamp", RegexOptions.IgnoreCase);
                        Match m = r.Match(process.MainWindowTitle);
                        string trackNumber = m.Groups[1].ToString();
                        string trackArtist = m.Groups[2].ToString();
                        string trackName = m.Groups[3].ToString();
                        string returnData = "Now playing: \"" + trackName + "\" by " + trackArtist;
                        Console.WriteLine(returnData);
                    }
                }
            }
        }
    }
}
