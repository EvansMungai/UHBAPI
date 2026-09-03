namespace UHB.Extensions.RouteHandlers;

public interface IRouteRegistrar
{
    void MapEndpoints(IEndpointRouteBuilder app);
}
