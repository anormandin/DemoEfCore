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

    public IEmployeeService GetEmployeeService()
    {
        return ServiceProvider.GetRequiredService<IEmployeeService>();
    }

    public void Dispose()
    {
        ServiceProvider.Dispose();
    }
}