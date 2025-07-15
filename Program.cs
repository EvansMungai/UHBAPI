using UHB.Extensions;
using UHB.Helpers;



var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.ConfigureMiddleware();


app.Run();
