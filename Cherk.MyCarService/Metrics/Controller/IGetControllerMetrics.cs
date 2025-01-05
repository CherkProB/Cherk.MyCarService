namespace Cherk.MyCarService.Metrics.Controller;

public interface IGetControllerMetrics
{
    public void ObserveGetController(
        TimeSpan duration,
        string controllerName, 
        string? methodName = null);
}