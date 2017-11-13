﻿using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTAVisualiser.Interfaces;
using RTAVisualiser.DataModel;

namespace RTAVisualiser.Repositories
{
    public class ReportRepositoryCSV : IReportRepository
    {
        private IAppSettings Settings { get; set; } = null;
        private DateTime LastRenderCheck { get; set; } = DateTime.Now;
        private CoreDataModel CoreData { get; set; } = new CoreDataModel();
        private List<CoreDataModel> HistoricalData { get; set; } = new List<CoreDataModel>();


        public ReportRepositoryCSV(IAppSettings settings)
        {
            Settings = settings;
            LastRenderCheck = DateTime.ParseExact(Settings.RepositoryLastAccess, "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture);

            Fetch();
        }
        public void Fetch()
        {
            string[] directories = Directory.GetDirectories(Settings.RootReportDirectory);

            foreach (string s in directories)
            {
                string[] splitDir = s.Split('\\');
                try
                {
                    DateTime currentDirectory = DateTime.ParseExact(splitDir.Last(), "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture);
                    if (DateTime.Compare(currentDirectory, LastRenderCheck) > 0)
                    {
                        Console.WriteLine($"{currentDirectory.ToString()} latest compared to {LastRenderCheck}");

                        CoreData = new CoreDataModel();
                        CoreData.Name = "Render_" + splitDir.Last();

                        FetchLatestDurationData(Settings.RootReportDirectory + splitDir.Last() + "\\Reports\\Timings.csv");
                        FetchLatestMemoryData(Settings.RootReportDirectory + splitDir.Last() + "\\Reports\\Memory\\");

                        HistoricalData.Add(CoreData);
                        LastRenderCheck = currentDirectory;
                    }
                }
                catch
                {
                    Console.WriteLine(s + ": is not valid as a DateTime object..");
                }
            }
        }
        private void FetchLatestDurationData(string path)
        {
            try
            {
                List<TimingsDataModel> tdmList = new List<TimingsDataModel>();
                using (System.IO.FileStream fs = new System.IO.FileStream(path, FileMode.Open))
                using (System.IO.StreamReader reader = new System.IO.StreamReader(fs))
                {
                    reader.ReadLine();
                    string line = reader.ReadLine();
                    while(line != null)
                    {
                        string[] split = line.Split('\t');
                        CoreData.Timings.Add(new TimingsDataModel()
                        {
                            Name = split[0],

                            Duration = Convert.ToDouble(split[1]),
                        });
                        line = reader.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }
        private void FetchLatestMemoryData(string path)
        {
            try
            {
                List<MemoryDataModel> mdmList = new List<MemoryDataModel>();

                string[] files = Directory.GetFiles(path);

                foreach (string s in files)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(s, FileMode.Open))
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(fs))
                    {
                        reader.ReadLine();
                        string line = reader.ReadLine();
                        MemoryDataModel mdm = new MemoryDataModel();
                        while (line != null)
                        {
                            string[] split = line.Split('\t');

                            mdm.Name = s.Split('\\').Last();
                            mdm.Frame = Convert.ToInt32(s.Split('\\').Last().Split('_').Last());
                            mdm.SizeAllocated += Convert.ToInt32(split[1]);
                            mdm.SizeUtilised += Convert.ToInt32(split[2]);
                            mdm.PeakSizeUtilised += Convert.ToInt32(split[3]);
                            mdm.NumberOfAllocations += Convert.ToInt32(split[4]);

                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public CoreDataModel GetLastRender()
        {
            return CoreData;
        }
        public List<CoreDataModel> GetHistoricalData()
        {
            return HistoricalData;
        }
    }
}