using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Batchs
{
    public class SQLBatchRepo : IBatch
    {
        private readonly AppDbContext db;

        public SQLBatchRepo(AppDbContext db)
        {
            this.db = db;
        }

        public Batch AddBatch(Batch Batch)
        {
            db.Batches.Add(Batch);
            db.SaveChanges();
            return Batch;
        }

        public Batch DeleteBatch(int id)
        {
            Batch batch = db.Batches.Find(id);
            if (batch != null)
            {
                db.Batches.Remove(batch);
                db.SaveChanges();
            }
            return batch;
        }

        public IEnumerable<Batch> GetAllBatch()
        {
            return db.Batches;
        }

        public Batch GetBatch(int id)
        {
            return db.Batches.Find(id);
        }

        public Batch UpdateBatch(Batch BatchChanges)
        {
            var bat = db.Batches.Attach(BatchChanges);
            bat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return BatchChanges;
        }
    }
}
