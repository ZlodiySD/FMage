using System;
using System.Diagnostics;

public class Timer
{
    private Stopwatch stopWatch;

    public void StartTimer()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }

    public TimeSpan StopTimer()
    {
        stopWatch.Stop();
        return stopWatch.Elapsed;
    }
}
