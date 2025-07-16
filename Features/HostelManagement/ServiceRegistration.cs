﻿namespace UHB.Features.HostelManagement.Services;

public static class ServiceRegistration
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHostelRepository, HostelRepository>();
        services.AddScoped<IHostelService, HostelService>();
        services.AddScoped<IRoomService, RoomService>();
    }
}
