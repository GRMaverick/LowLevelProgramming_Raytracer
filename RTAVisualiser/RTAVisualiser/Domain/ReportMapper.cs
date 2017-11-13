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

        private ChartValues<ObservableValue> DurationData { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> PeakUsage { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> UsedMemory { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> AllocatedMemory { get; set; } = new ChartValues<ObservableValue>();
        private ChartValues<ObservableValue> NumberOfAllocations { get; set; } = new ChartValues<ObservableValue>();

        public ReportMapper(IReportRepository repo)
        {
            Repository = repo;            
        }

        public void Update()
        {
            Repository.Fetch();

            UpdateLatestDurationCollection();
            UpdateLatestMemoryCollection();
        }

        public SeriesCollection InitialiseAllMethodsCollection()
        {
            SeriesCollection collection = new SeriesCollection();

            LineSeries timing = new LineSeries()
            {
                Title = "Duration of " + Repository.GetLastRender().Name,
                Values = DurationData
            };
            
            collection.Add(timing);

            return collection;
        }
        public SeriesCollection InitialiseTimingCollection()
        {
            SeriesCollection collection = new SeriesCollection();

            LineSeries timing = new LineSeries()
            {
                Title = "Duration of " + Repository.GetLastRender().Name,
                Values = DurationData
            };

            collection.Add(timing);

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

        private void UpdateLatestDurationCollection()
        {
            List<TimingsDataModel> tdmList = Repository.GetLastRender().Timings;

            if (tdmList.Count == 0) return;

            if(tdmList.Count != DurationData.Count)
            {
                DurationData.Clear();
                foreach (TimingsDataModel tdm in tdmList)
                {
                    DurationData.Add(new ObservableValue(tdm.Duration));
                }
            }
            else
            {
                for (int i = 0; i < DurationData.Count; i++)
                {
                    DurationData[i].Value = tdmList[i].Duration;
                }
            }
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
