using Data.Repositories;
using Service.DataServices;

namespace API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAppUsersRepository, AppUsersRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAppUsersService, AppUsersService>();
        return serviceCollection;
    }
}
