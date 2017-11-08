using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using RTAVisualiser.Interfaces;
using RTAVisualiser.Threading;
using RTAVisualiser.DataModel;

using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Windows.Threading;

namespace RTAVisualiser.Forms
{
    public partial class MainForm : Form
    {
        private IAppSettings Settings { get; set; } = null;
        private IRepository Repository { get; set; } = null;
        private WorkerClass RepoUpdater { get; set; } = new WorkerClass(1);
        private WorkerClass GUIUpdater { get; set; } = new WorkerClass(2);

        SeriesCollection collection { get; set; } = new SeriesCollection();
        ChartValues<double> ParallelDurationData { get; set; } = new ChartValues<double>();
        ChartValues<double> SequentialDurationData { get; set; } = new ChartValues<double>();

        public MainForm(IAppSettings settings, IRepository repository)
        {
            InitializeComponent();

            Settings = settings;
            Repository = repository;

            RepoUpdater.WorkToComplete += UpdateRepository;

            if (Repository.GetSequentialDurationData() != null && Repository.GetSequentialDurationData().Count != 0)
            {
                foreach (TimingsDataModel tdm in Repository.GetSequentialDurationData())
                {
                    SequentialDurationData.Add(tdm.Duration);
                }
            }

            if (Repository.GetParallelDurationData() != null && Repository.GetParallelDurationData().Count != 0)
            {
                foreach (TimingsDataModel tdm in Repository.GetParallelDurationData())
                {
                    ParallelDurationData.Add(tdm.Duration);
                }
            }

            collection.Add(new LineSeries()
            {
                Title = "Sequential",
                Values = SequentialDurationData,
            });
            collection.Add(new LineSeries()
            {
                Title = "Parallel",
                Values = ParallelDurationData,
            });

            DurationCartesian.Series.Clear();
            DurationCartesian.Series = collection;
            DurationCartesian.AxisX.Add(new Axis
            {
                Title = "Frame",
            });
            DurationCartesian.AxisY.Add(new Axis
            {
                Title = "Time Taken (Milliseconds)",
            });
            DurationCartesian.LegendLocation = LegendLocation.Right;

            DurationCartesian.Invalidate();
            DurationCartesian.Update();

            Console.WriteLine("Update Complete!");
        }

        private void UpdateRepository()
        {
            //while (true)
            //{
                Repository.Fetch();
                Console.WriteLine("Updated Repo");
                Thread.Sleep(20000);
            //}
        }
        private void UpdateGraphData()
        {

        }
    }
}
