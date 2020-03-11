using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Guarantors
{
    public interface IGuarantor
    {
        Guarantor AddGuarantor(Guarantor guarantor);
        Guarantor GetGuarantor(int id);
        IEnumerable<Guarantor> GetAllGuarantor();
        IEnumerable<Guarantor> StudentGuarantor(int id);
        Guarantor DeleteGuarantor(int id);
        Guarantor UpdateGuarantor(Guarantor Guarantor_changes);
    }
}
