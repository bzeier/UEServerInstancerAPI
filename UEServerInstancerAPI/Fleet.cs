using System.Diagnostics;
using System.IO;

namespace UEServerInstancerAPI
{
    public class Fleet
    {
        public Process process;
        public List<Player> players = new List<Player> ();

        public bool Run()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            //string[] files = Directory.GetFiles(path);

            process = Process.Start(path + "/FL64.exe");

            return true;
        }

        public bool GetIsRunning()
        {
            return process.HasExited;
        }

        public void AddPlayer(Player player)
        {
            player.isActive = true;
            players.Add(player);
        }

        public bool ShutDown()
        {
            process.Kill();
            return true;
        }
    }
}
