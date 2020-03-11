using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Batchs
{
    public interface IBatch
    {
        Batch AddBatch(Batch Batch);
        Batch DeleteBatch(int id);
        Batch GetBatch(int id);
        IEnumerable<Batch> GetAllBatch();
        Batch UpdateBatch(Batch BatchChanges);
    }
}
