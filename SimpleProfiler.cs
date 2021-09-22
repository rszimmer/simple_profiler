using System;
using System.Collections;
using System.Collections.Generic;
using static timeTracker.TimeTracker;
using System.IO;
using CsvHelper;
using System.Globalization;
using static timeTracker.ProfilerInfo;

namespace timeTracker {
    class SimpleProfiler {
                public TimeTracker time;
                public List<ProfilerInfo> list;
                
                public SimpleProfiler() {
                    this.time = new TimeTracker("start");
                    this.list = new List<ProfilerInfo>();
                }

                //Adiciona os elementos na lista
                public void Add(string id, int inout, TimeFormat format = TimeFormat.Milliseconds) {
                    this.time.AddLap(id);
                    var profiler = new ProfilerInfo {id = id, time = this.time.GetLapTimeDiff("start", id, format), inout = inout};
                    this.list.Add(profiler);
                }
                
                //Retorna um valor de tempo que está na pilha
                public decimal getTime(int pos) {
                    return list[pos].time;
                }

                //Retorna um valor de Id que está na pilha
                public string getId(int pos) {
                    return list[pos].id;
                }

                //Retorna um valor de Input/Output que está na pilha
                public int getInOut(int pos) {
                    return list[pos].inout;
                }

                //Retorna as informações pelo Id
                public string SearchById(string id) {
                    foreach(var item in this.list) {
                        if(id.Equals(item.id)) {
                            return "Tempo: "+ item.time + " " + "Valor: " + item.inout;
                        }
                    }
                    return "Id Inválido";
                }

                //Retorna as Informações pela posição
                public string SearchByPos(int pos) {
                    foreach(var item in this.list) {
                        if(pos < this.list.Count) {
                            return "Tempo: " + this.list[pos].time + "\n" + "Valor: " + this.list[pos].inout + '\n' + "ID: " + this.list[pos].id;
                        }
                    }
                    return "Posição Inválida";
                }

                //Retorna o tamanho da lista no profiler
                public int Size {
                    get {return this.list.Count;}
                }

                public void toCSV () {
                    var records = this.list;
                    var csvPath = Path.Combine(Environment.CurrentDirectory, $"profiler-{DateTime.Now.ToFileTime()}.csv");
                    using (var writer = new StreamWriter(csvPath)){
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(records);
                        }
                    }
                }
    }

    // struct ProfilerInfo {
    //     public decimal time;
    //     public string id;
    //     public int inout;

    //     public ProfilerInfo(decimal time, string id, int inout) {
    //         this.time = time;
    //         this.id = id;
    //         this.inout = inout;

    //     }
    // }
}
