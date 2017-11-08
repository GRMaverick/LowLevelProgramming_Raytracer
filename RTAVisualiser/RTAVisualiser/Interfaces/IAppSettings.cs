using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTAVisualiser.Interfaces
{
    public interface IAppSettings
    {
        string SequentialReportDirectory { get; set; }
        string SequentialBVReportDirectory { get; set; }
        string SequentialOctreeReportDirectory { get; set; }
        string ParallelReportDirectory { get; set; }
        string ParallelBVReportDirectory { get; set; }
        string ParallelOctreeReportDirectory { get; set; }
    }
}
