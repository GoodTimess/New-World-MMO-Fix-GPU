using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace New_World_GPU_FIX
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string appdatapath = "Not found";
            string newworldpath = "Not found";

            // Loading the main configuration (path folder ect..)
            Console.WriteLine("Loading necessary resources...");
            appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            newworldpath = appdatapath + @"\Roaming\AGS\New World\user_preload_settings.cfg";
            Debug.WriteLine($"Current path: {appdatapath}, \n\n New World path: {newworldpath}");
            Thread.Sleep(1);

            // Looking for the existing file
            Console.WriteLine("Loading game configuration...");
            if (!File.Exists(newworldpath))
            {
                Console.WriteLine("Open the game once first!");
            }
            else
            {
                Console.WriteLine("Injecting correct configuration...");
                try
                {
                    var text = File.ReadAllText(newworldpath);
                    var start = text.IndexOf("m_maxFps") + 9;
                    var finish = text.IndexOf("m_maxFps") + 11;
                    var correctconfig = text.Substring(0, start) + "60" + text.Substring(finish);
                    File.WriteAllText(newworldpath, correctconfig);
                    Console.WriteLine("All done! Await for exit...");
                    Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex}");
                }
            }
        }
    }
}