using System;
using System.IO;

namespace New_World_GPU_FIX
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var newworldpath = appdatapath + @"\Roaming\AGS\New World\user_preload_settings.cfg";
            if (!File.Exists(newworldpath))
            {
                Console.WriteLine("Open the game once first!");
            }
            else
            {
                var text = File.ReadAllText(newworldpath);
                var start = text.IndexOf("m_maxFps") + 9;
                var finish = text.IndexOf("m_maxFps") + 11;
                var correctconfig = text.Substring(0, start) + "60" + text.Substring(finish);
                File.WriteAllText(newworldpath, correctconfig);
            }
        }
    }
}