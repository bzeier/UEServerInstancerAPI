using System.Diagnostics;
using UEServerInstancerAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
FleetInstancer serverInstancer = new FleetInstancer();


app.MapGet("/bootnewfleet", () => serverInstancer.RunNewFleet());
app.MapGet("/incomingplayer", () => serverInstancer.OnIncomingPlayer(new Player()));

app.Run();
