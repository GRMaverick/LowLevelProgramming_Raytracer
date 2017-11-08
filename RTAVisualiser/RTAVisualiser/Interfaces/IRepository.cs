using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTAVisualiser.DataModel;

namespace RTAVisualiser.Interfaces
{
    public interface IRepository
    {
        void Fetch();

        List<MemoryDataModel> GetSequentialMemoryData();
        List<MemoryDataModel> GetSequentialBVMemoryData();
        List<MemoryDataModel> GetSequentialOctreeMemoryData();
        List<MemoryDataModel> GetParallelMemoryData();
        List<MemoryDataModel> GetParallelBVMemoryData();
        List<MemoryDataModel> GetParallelOctreeMemoryData();

        List<TimingsDataModel> GetSequentialDurationData();
        List<TimingsDataModel> GetSequentialBVDurationData();
        List<TimingsDataModel> GetSequentialOctreeDurationData();
        List<TimingsDataModel> GetParallelDurationData();
        List<TimingsDataModel> GetParallelBVDurationData();
        List<TimingsDataModel> GetParallelOctreeDurationData();
    }
}
