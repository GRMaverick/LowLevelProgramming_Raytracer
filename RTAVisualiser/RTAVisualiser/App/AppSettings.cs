using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTAVisualiser.Interfaces;

namespace RTAVisualiser.App
{
    public class AppSettings : IAppSettings
    {
        public string SequentialReportDirectory { get; set; } = null;
        public string SequentialBVReportDirectory { get; set; } = null;
        public string SequentialOctreeReportDirectory { get; set; } = null;
        public string ParallelReportDirectory { get; set; } = null;
        public string ParallelBVReportDirectory { get; set; } = null;
        public string ParallelOctreeReportDirectory { get; set; } = null;
    }
}
