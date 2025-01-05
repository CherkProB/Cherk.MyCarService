using System.Diagnostics;

namespace Cherk.MyCarService.Common;

public sealed class PerformanceTracker(Action<TimeSpan> action) : IDisposable
{
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    
    public void Dispose()
    {
        _stopwatch.Stop();
        action(_stopwatch.Elapsed);
    }
}