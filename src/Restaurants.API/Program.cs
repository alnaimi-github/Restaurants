using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Restaurants.API.Extensions;
using Microsoft.Extensions.Azure;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.AddPresentation();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddInApplication();

    var app = builder.Build();

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();


    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeLoggingMiddleware>();
    app.UseSerilogRequestLogging();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.MapGroup("api/identity")
        .WithTags("Identity")
        .MapIdentityApi<User>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


}
catch (Exception e)
{
    Log.Fatal(e, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program {}