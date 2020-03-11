using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models
{
    public class SQLGuarantorRepository : IGuarantor
    {
        private readonly AppDbContext context;

        public SQLGuarantorRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Guarantor AddGuarantor(Guarantor guarantor)
        {
            context.Guarantors.Add(guarantor);
            context.SaveChanges();
            return guarantor;
        }

        public Guarantor DeleteGuarantor(int id)
        {
            Guarantor guarantor = context.Guarantors.Find(id);
            if (guarantor != null)
            {
                context.Guarantors.Remove(guarantor);
                context.SaveChanges();
            }
            return guarantor;
        }

        public IEnumerable<Guarantor> GetAllGuarantor()
        {
            return context.Guarantors;
        }
        public IEnumerable<Guarantor> StudentGuarantor(int id)
        {
            return context.Guarantors.Where(p => p._student_id == id);
            //return context.studentGuarantors.Where(p => p.StudentId == id);
        }

        public Guarantor GetGuarantor(int id)
        {
            return context.Guarantors.Find(id);
        }

        public Guarantor UpdateGuarantor(Guarantor Guarantor_changes)
        {
            var guarantor = context.Guarantors.Attach(Guarantor_changes);
            guarantor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Guarantor_changes;
        }
    }
}
