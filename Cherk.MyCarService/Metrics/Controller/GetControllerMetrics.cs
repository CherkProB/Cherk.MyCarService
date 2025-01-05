using System.Runtime.CompilerServices;
using Prometheus.Client;

namespace Cherk.MyCarService.Metrics.Controller;

public sealed class GetControllerMetrics : BaseMetrics, IGetControllerMetrics
{
    private readonly IMetricFamily<IHistogram, ValueTuple<string, string>> _getController;
    
    public GetControllerMetrics(IMetricFactory factory)
    {
        _getController = factory
            .CreateHistogram(
                ServiceName + "get_controller",
                "Time of calling the GET method of controller",
                new ValueTuple<string, string>("controller", "method"),
                buckets: [1, 3, 7, 15, 25, 50, 100, 200, 500, 1000, 2000, 5000, 7000, 10000, 15000, 20000, 25000, 50000]);
    }
    
    public void ObserveGetController(
        TimeSpan duration,
        string controllerName, 
        [CallerMemberName] string? methodName = null)
    {
        methodName ??= "UnknownMethod";
        
        _getController
            .WithLabels((controllerName, methodName))
            .Observe(duration.TotalMilliseconds);
    }
}