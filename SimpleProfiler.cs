using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Simple {
    class SimpleProfiler {

                public Stopwatch time;
                public List<ProfilerInfo> list;
                public SimpleProfiler() {
                    this.time = new Stopwatch();
                    this.list = new List<ProfilerInfo>();
                    this.time.Start();
                }

                public void Add(string id, int [] inout) {
                    this.list.Add(new ProfilerInfo(this.time.Elapsed, id, inout));
                }
    }

    struct ProfilerInfo {
        public TimeSpan time;
        public string id;
        public int [] inout;

        public ProfilerInfo(TimeSpan time, string id, int [] inout) {
            this.time = time;
            this.id = id;
            this.inout = inout;

        }
    }
}