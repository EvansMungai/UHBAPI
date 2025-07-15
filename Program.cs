using UHB.Extensions;
using UHB.Helpers;



var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddScoped<IRouteResolutionHelper, RouteResolutionHelper>();



var app = builder.Build();

app.ConfigureMiddleware();

var resolutionHelper = app.Services.CreateScope().ServiceProvider.GetService<IRouteResolutionHelper>();
resolutionHelper.addMappings(app);

app.Run();
