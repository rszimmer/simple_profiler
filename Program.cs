//Programa de teste para o Profiler
//id 1: Conta desde que o profiler foi instanciado
//id 2: Conta desde um início determinado
//id 3: Conta desde um início determinado (aninhado com id 2)

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
            Thread.Sleep(10300);
            profiler.End("1", 100.2900);
            Thread.Sleep(1000);
            profiler.Start("2");
            Thread.Sleep(103);
            profiler.Start("3");
            profiler.End("2", 200);
            Thread.Sleep(1036);
            profiler.End("3", 300);
            profiler.toCSV();
        }
    }
}
