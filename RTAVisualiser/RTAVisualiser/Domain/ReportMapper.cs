using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.WinForms;

using RTAVisualiser.Interfaces;
using RTAVisualiser.DataModel;

namespace RTAVisualiser.Mapper
{
    public class ReportMapper : IReportMapper
    {
        private IReportRepository Repository { get; set; } = null;

        private ChartValues<ObservableValue> FrameTimeData { get; set; } = new ChartValues<ObservableValue>();
        private Dictionary<string, ChartValues<ObservableValue>> ThreadTimeData { get; set; } = new Dictionary<string, ChartValues<ObservableValue>>(8);

        private ChartValues<ObservableValue> PeakUsage { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> UsedMemory { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> AllocatedMemory { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> NumberOfAllocations { get; set; } = new ChartValues<ObservableValue>();

        public ReportMapper(IReportRepository repo)
        {
            Repository = repo;

            Repository.Fetch();

            UpdateLatestFrameTimeCollection();
            UpdateLatestThreadTimeCollection();
            UpdateLatestMemoryCollection();
        }

        public void Update()
        {
            Repository.Fetch();

            UpdateLatestFrameTimeCollection();
            UpdateLatestThreadTimeCollection();
            UpdateLatestMemoryCollection();
        }

        public SeriesCollection InitialiseAllMethodsCollection()
        {
            SeriesCollection collection = new SeriesCollection();

            LineSeries timing = new LineSeries()
            {
                Title = "Duration of " + Repository.GetLastRender().Name,
                Values = FrameTimeData
            };
            
            collection.Add(timing);

            return collection;
        }
        public SeriesCollection InitialiseFrameTimeCollection()
        {
            SeriesCollection collection = new SeriesCollection();

            LineSeries timing = new LineSeries()
            {
                Title = "Duration of " + Repository.GetLastRender().Name,
                Values = FrameTimeData
            };

            collection.Add(timing);

            return collection;
        }
        public SeriesCollection InitialiseThreadTimeCollection()
        {
            SeriesCollection collection = new SeriesCollection();

            foreach(string s in ThreadTimeData.Keys.ToList())
            {
                collection.Add(new LineSeries()
                {
                    Title = s,
                    Values = ThreadTimeData[s],
                });
            }
            
            return collection;
        }
        public SeriesCollection InitialiseMemoryCollection()
        {
            SeriesCollection collection = new SeriesCollection();

            LineSeries totalMemoryAllocated = new LineSeries()
            {
                Title = "Total Allocated Memory ",
                Values = AllocatedMemory
            };
            LineSeries totalMemoryUsed = new LineSeries()
            {
                Title = "Memory Used",
                Values = UsedMemory,
            };
            LineSeries peakUsed = new LineSeries()
            {
                Title = "Peak Usage",
                Values = PeakUsage,
            };
            LineSeries allocationsMade = new LineSeries()
            {
                Title = "Total Objects Allocated",
                Values = NumberOfAllocations,
            };

            collection.Add(peakUsed);
            collection.Add(allocationsMade);
            collection.Add(totalMemoryUsed);
            collection.Add(totalMemoryAllocated);

            return collection;
        }

        private void UpdateLatestFrameTimeCollection()
        {
            List<TimingsDataModel> tdmList = Repository.GetLastRender().FrameTimes;

            if (tdmList.Count == 0) return;

            if(tdmList.Count != FrameTimeData.Count)
            {
                FrameTimeData.Clear();
                foreach (TimingsDataModel tdm in tdmList)
                {
                    FrameTimeData.Add(new ObservableValue(tdm.Duration));
                }
            }
            else
            {
                for (int i = 0; i < FrameTimeData.Count; i++)
                {
                    FrameTimeData[i].Value = tdmList[i].Duration;
                }
            }
        }
        private void UpdateLatestThreadTimeCollection()
        {
            List<TimingsDataModel> tdmList = Repository.GetLastRender().ThreadTimes;

            int threadCount = ScanForThreadCount(tdmList);

            if ((tdmList.Count / threadCount) != ThreadTimeData.Count)
            {
                foreach (TimingsDataModel tdm in tdmList)
                {
                    if (!ThreadTimeData.ContainsKey(tdm.Name.Split('.')[0]))
                        ThreadTimeData[tdm.Name.Split('.')[0]] = new ChartValues<ObservableValue>();
                    ThreadTimeData[tdm.Name.Split('.')[0]].Clear();
                }

                foreach (TimingsDataModel tdm in tdmList)
                {
                    ThreadTimeData[tdm.Name.Split('.')[0]].Add(new ObservableValue(tdm.Duration));
                }
            }
            else
            {
                for (int i = 0; i < tdmList.Count; i++)
                {
                    ThreadTimeData[tdmList[i].Name.Split('.')[0]][i].Value = tdmList[i].Duration;
                }
            }          
        }
        private int ScanForThreadCount(List<TimingsDataModel> list)
        {
            int threads = 0;
            int currentFrame = 0;
            foreach (TimingsDataModel tdm in list)
            {
                if(tdm.Frame == currentFrame)
                {
                    threads++;
                }
                else
                {
                    return threads;
                }
            }
            return 0;
        }

        private void UpdateLatestMemoryCollection()
        {
            List<MemoryDataModel> mdmList = Repository.GetLastRender().Memory;

            if (mdmList.Count == 0) return;
            
            for(int i = 0; i < mdmList.Count; i++)
            {

            }
        }
    }
}
