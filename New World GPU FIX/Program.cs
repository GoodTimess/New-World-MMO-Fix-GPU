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
            // Loading the main configuration (path folder ect..)
            string newworldpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Roaming\AGS\New World\user_preload_settings.cfg";
            Console.WriteLine("Loading necessary resources...");
            Debug.WriteLine($">>> New World path: {newworldpath}");
            Thread.Sleep(1);

            // Looking for the existing file
            Console.WriteLine("Loading game configuration...");
            if (!File.Exists(newworldpath))
            {
                Console.WriteLine("Open the game once first!");
                return;
            }
            else
            {
                Console.WriteLine("Injecting correct configuration...");
                Thread.Sleep(1);
                try
                {
                    // Try to find the user preload settings file
                    string text = File.ReadAllText(newworldpath);

                    // Looking for a specific declaration and perform some changes
                    var start = text.IndexOf("m_maxFps") + 9;
                    var finish = text.IndexOf("m_maxFps") + 11;
                    var correctconfig = text.Substring(0, start) + "60" + text.Substring(finish);

                    // Write down the changes and save the new configuration
                    File.WriteAllText(newworldpath, correctconfig);
                    Console.WriteLine("All done! Await for exit...");
                    Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    // If there are any errors, they should be captured by this catch and reported in the console
                    Console.WriteLine($"Error: {ex}");
                }
            }
        }
    }
}