using Cherk.MyCarService.Metrics.Controller;
using Prometheus.Client.DependencyInjection;

namespace Cherk.MyCarService.Extensions;

public static class MetricsExtension
{
    public static IServiceCollection AddServiceMetrics(this IServiceCollection services)
    {
        services.AddMetricFactory();
        
        services.AddSingleton<IGetControllerMetrics, GetControllerMetrics>();

        return services;
    }

}