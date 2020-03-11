using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Programs
{
    public class SQLProgramRepo : IProgram
    {
        private readonly AppDbContext db;

        public SQLProgramRepo(AppDbContext db)
        {
            this.db = db;
        }

        public Programme AddProgramme(Programme Programme)
        {
            db.Programs.Add(Programme);
            db.SaveChanges();
            return Programme;
        }

        public Programme DeleteProgramme(int id)
        {
            Programme programme = db.Programs.Find(id);
            if (programme != null)
            {
                db.Programs.Remove(programme);
                db.SaveChanges();
            }
            return programme;
        }

        public IEnumerable<Programme> GetAllProgrammes()
        {
            return db.Programs;
        }

        public Programme GetProgramme(int id)
        {
            return db.Programs.Find(id);
        }

        public Programme UpdateProgramme(Programme ProgrammeChanges)
        {
            var programmme = db.Programs.Attach(ProgrammeChanges);
            programmme.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return ProgrammeChanges;
        }
    }
}
