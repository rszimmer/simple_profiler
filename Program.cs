using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using static Simple.SimpleProfiler;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vetor = new int[] {5, 7, 12,1, 2, 5, 16, 17, 13, 14, 10, 13, 14, 15, 18, 3, 4, 7, 15, 18,7,
                                    9, 11, 14, 17,2, 3, 7, 11, 19,9, 10, 12, 17, 20, 6, 10, 12, 14, 17};
            SimpleProfiler profile = bubbleSort(vetor);
            foreach (var item in profile.list[0].inout)
            {
                Console.WriteLine(item);
            }


        }

        public static SimpleProfiler bubbleSort(int[] vetor)
        {
            int tamanho = vetor.Length;
            int comparacoes = 0;
            int trocas = 0;

            SimpleProfiler profile = new SimpleProfiler();
            for (int i = tamanho - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    comparacoes++;
                    if (vetor[j] > vetor[j + 1])
                    {
                        int aux = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = aux;
                        trocas++;
                    }
                }
            }

            profile.Add("Bubble Sort", vetor);
            return profile;
        }
        
    }
}

// class SimpleProfiler {

//             public Stopwatch time;
//             public List<ProfilerInfo> listinha;
//             public SimpleProfiler() {
//                 this.time = new Stopwatch();
//                 this.listinha = new List<ProfilerInfo>();
//                 this.time.Start();
//             }
// }

// struct ProfilerInfo {
//     public TimeSpan time;
//     public string id;
//     public int inout;

//     public ProfilerInfo(TimeSpan time, string id, int inout) {
//         this.time = time;
//         this.id = id;
//         this.inout = inout;

//     }
// }