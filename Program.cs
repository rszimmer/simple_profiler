using System;
using System.Collections;
using System.Collections.Generic;

namespace simples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProfilerInfo> listinha = new List<ProfilerInfo>();

            listinha.Add(new ProfilerInfo(1, "um", 1));

            Console.WriteLine(listinha[0].time);
        }
    }
}

struct ProfilerInfo {
    public int time;
    public string id;
    public int inout;

    public ProfilerInfo(int time, string id, int inout) {
        this.time = time;
        this.id = id;
        this.inout = inout;

    }
}
