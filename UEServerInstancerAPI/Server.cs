namespace UEServerInstancerAPI
{
    public class Server
    {
        public bool isRunning = false;

        public bool Run()
        {
            isRunning = true;
            return true;
        }

        public bool ShutDown()
        {
            isRunning = false;
            return true;
        }
    }
}
