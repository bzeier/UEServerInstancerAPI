using System.Diagnostics;
using System.IO;

namespace UEServerInstancerAPI
{
    public class Server
    {
        public Process process;
        public Player[] players = new Player[] { };

        public bool Run()
        {

            //Debug.WriteLine(
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Debug.WriteLine(path);
            string[] files = Directory.GetFiles(path);

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
            players.Append(player);
        }

        public bool ShutDown()
        {
            process.Kill();
            return true;
        }
    }
}
