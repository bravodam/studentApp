using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Programs
{
    public interface IProgram
    {
        Programme AddProgramme(Programme Programme);
        Programme UpdateProgramme(Programme ProgrammeChanges);
        Programme GetProgramme(int id);
        IEnumerable<Programme> GetAllProgrammes();
        Programme DeleteProgramme(int id);
    }
}
