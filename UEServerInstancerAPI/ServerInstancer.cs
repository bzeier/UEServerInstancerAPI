namespace UEServerInstancerAPI
{
    public class ServerInstancer
    {
        public int MAX_SERVERS_ALLOWED = 10;
        public Server[] ServerInstances = new Server[] { };



        public void RunNewServer()
        {
            if (ServerInstances.Length + 1 > MAX_SERVERS_ALLOWED)
                return;

            System.Diagnostics.Debug.WriteLine("Starting new server instance...");

            Server instance = new Server();
            ServerInstances.Append(instance);

            if(!instance.Run())
            {
                System.Diagnostics.Debug.WriteLine("Failed to boot up new server instance");
            }
        }
    }
}
