using LOGIC.Models;
using System.Collections.Generic;

namespace LOGIC.Interfaces.Files
{
    public interface IRubricsFileBuilder
    {
        FileResultObject BuildFileCSV(IEnumerable<Rubric> records);
        FileResultObject BuildFileDOCX(IEnumerable<Rubric> records);
        FileResultObject BuildFilePDF(IEnumerable<Rubric> records);

    }
}
