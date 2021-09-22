using System;
using System.Collections.Generic;
using System.Threading;
using static timeTracker.TimeTracker;
using static timeTracker.SimpleProfiler;

namespace timeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleProfiler profiler = new SimpleProfiler();
            //TimeTracker tt = new TimeTracker("start");
            Thread.Sleep(10300);
            //tt.AddLap("myLap1");
            //Console.WriteLine(tt.GetLapTimeDiff("start", "myLap1"));
            profiler.Add("1", 100, TimeFormat.Seconds);
            Thread.Sleep(1000);
            profiler.Add("2", 200, TimeFormat.Seconds);
            Thread.Sleep(200);
            profiler.Add("3", 300, TimeFormat.Seconds);
            Console.WriteLine(profiler.Size);
            profiler.toCSV();
        }
    }
}
