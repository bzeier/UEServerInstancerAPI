namespace UEServerInstancerAPI
{
    public class FleetInstancer
    {
        public int MAX_SERVERS_ALLOWED = 10;
        public int MAX_PLAYERS_PER_FLEET = 4;
        public Fleet[] ServerInstances = new Fleet[] { };

        public Fleet FindAvailableFleet()
        {
            foreach (Fleet fleet in ServerInstances)
            {
                if (fleet.players.Length < MAX_PLAYERS_PER_FLEET)
                    return fleet;
            }
            return null;
        }

        public void RunNewFleet()
        {
            if (ServerInstances.Length + 1 > MAX_SERVERS_ALLOWED)
                return;

            System.Diagnostics.Debug.WriteLine("Starting new server instance...");

            Fleet instance = new Fleet();
            ServerInstances.Append(instance);

            if(!instance.Run())
            {
                System.Diagnostics.Debug.WriteLine("Failed to boot up new server instance");
            }
        }

        public void OnIncomingPlayer(Player player)
        {
            Fleet availableFleet = FindAvailableFleet();
            if (availableFleet == null)
            {
                RunNewFleet();
            }
        }
    }
}
