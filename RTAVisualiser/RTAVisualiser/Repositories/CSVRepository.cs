using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTAVisualiser.Interfaces;
using RTAVisualiser.DataModel;

namespace RTAVisualiser.Repositories
{
    public class CSVRepository : IRepository
    {
        private IAppSettings Settings { get; set; } = null;
        private Dictionary<string, List<TimingsDataModel>> TimingsData { get; set; } = new Dictionary<string, List<TimingsDataModel>>();
        private Dictionary<string, List<MemoryDataModel>> MemoryData { get; set; } = new Dictionary<string, List<MemoryDataModel>>();

        public CSVRepository(IAppSettings settings)
        {
            Settings = settings;

            Fetch();
        }
        public void Fetch()
        {
            try
            {
                FetchSequentialDurationData();
                FetchParallelDurationData();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"CSVRepository FAILED: {ex.Message} \n {ex.StackTrace}");
                return;
            }
        }
        private void FetchSequentialDurationData()
        {
            TimingsData["Sequential"] = new List<TimingsDataModel>();
            TimingsData["SequentialBV"] = new List<TimingsDataModel>();
            TimingsData["SequentialOctree"] = new List<TimingsDataModel>();

            using(System.IO.FileStream fs = new System.IO.FileStream(Settings.SequentialReportDirectory + "Timings.csv", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fs))
            {
                reader.ReadLine();  // Remove File Header

                string line = reader.ReadLine();
                while (line != null)
                {
                    //Console.WriteLine(line);

                    string[] columns = line.Split('\t');
                    TimingsData["Sequential"].Add(new TimingsDataModel()
                    {
                        Name = columns[0],
                        Duration = Convert.ToDouble(columns[1]),
                    });

                    line = reader.ReadLine();
                }

                reader.Close();
            }
        }
        private void FetchParallelDurationData()
        {
            TimingsData["Parallel"] = new List<TimingsDataModel>();
            TimingsData["ParallelBV"] = new List<TimingsDataModel>();
            TimingsData["ParallelOctree"] = new List<TimingsDataModel>();

            using (System.IO.FileStream fs = new System.IO.FileStream(Settings.ParallelReportDirectory + "Timings.csv", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fs))
            {
                reader.ReadLine();  // Remove File Header

                string line = reader.ReadLine();
                while (line != null)
                {
                    //Console.WriteLine(line);

                    string[] columns = line.Split('\t');
                    TimingsData["Parallel"].Add(new TimingsDataModel()
                    {
                        Name = columns[0],
                        Duration = Convert.ToDouble(columns[1]),
                    });

                    line = reader.ReadLine();
                }

                reader.Close();
            }
        }
        
        public List<MemoryDataModel> GetSequentialMemoryData()
        {
            return MemoryData["Sequential"];
        }
        public List<MemoryDataModel> GetSequentialBVMemoryData()
        {
            return MemoryData["SequentialBV"];
        }
        public List<MemoryDataModel> GetSequentialOctreeMemoryData()
        {
            return MemoryData["SequentialOctree"];
        }
        public List<MemoryDataModel> GetParallelMemoryData()
        {
            return MemoryData["Parallel"];
        }
        public List<MemoryDataModel> GetParallelBVMemoryData()
        {
            return MemoryData["ParallelBV"];
        }
        public List<MemoryDataModel> GetParallelOctreeMemoryData()
        {
            return MemoryData["ParallelOctree"];
        }

        public List<TimingsDataModel> GetSequentialDurationData()
        {
            return TimingsData["Sequential"];
        }
        public List<TimingsDataModel> GetSequentialBVDurationData()
        {
            return TimingsData["SequentialBV"];
        }
        public List<TimingsDataModel> GetSequentialOctreeDurationData()
        {
            return TimingsData["SequentialOctree"];
        }
        public List<TimingsDataModel> GetParallelDurationData()
        {
            return TimingsData["Parallel"];
        }
        public List<TimingsDataModel> GetParallelBVDurationData()
        {
            return TimingsData["ParallelBV"];
        }
        public List<TimingsDataModel> GetParallelOctreeDurationData()
        {
            return TimingsData["ParallelOctree"];
        }
    }
}
