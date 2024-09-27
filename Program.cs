using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using UHB.Helpers;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UHB API", Description = "Making university hostel booking process a seamless easy process", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UHB API V1");
    });
}

app.MapGet("/", () => "Hello World!");

RouteResolutionHelper.addMappings(app);

app.Run();
