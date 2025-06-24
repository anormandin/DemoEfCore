using Api.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Api.Tests.Application.Services;

public class ApiTestFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; }

    public ApiTestFixture()
    {
        var services = new ServiceCollection();
        services.AddApiServices();
        ServiceProvider = services.BuildServiceProvider();
    }

    public IEmployeService GetEmployeService()
    {
        return ServiceProvider.GetRequiredService<IEmployeService>();
    }

    public void Dispose()
    {
        ServiceProvider.Dispose();
    }
}