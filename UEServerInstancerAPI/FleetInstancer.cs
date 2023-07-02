using System.Diagnostics;

namespace UEServerInstancerAPI
{
    public class FleetInstancer
    {
        public int MAX_SERVERS_ALLOWED = 10;
        public int MAX_PLAYERS_PER_FLEET = 4;
        public int FLEETS = 0;
        public List<Fleet> ServerInstances = new List<Fleet> ();

        public Fleet FindAvailableFleet()
        {
            foreach (Fleet fleet in ServerInstances)
            {

                if (fleet.players.Count < MAX_PLAYERS_PER_FLEET)
                    return fleet;
            }

            return null;
        }

        public void RunNewFleet()
        {
            if (ServerInstances.Count + 1 > MAX_SERVERS_ALLOWED)
                return;

            System.Diagnostics.Debug.WriteLine("Starting new server instance...");

            Fleet instance = new Fleet();
            ServerInstances.Add(instance);
            //FLEETS++;
            Debug.WriteLine(ServerInstances.Count);

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
            else
            {
                availableFleet.AddPlayer(player);
            }

            Debug.WriteLine("Available fleets are sufficient");
        }
    }
}
