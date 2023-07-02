using System.Diagnostics;
using UEServerInstancerAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
ServerInstancer serverInstancer = new ServerInstancer();


app.MapGet("/bootnewserver", () => serverInstancer.RunNewServer());

app.Run();
