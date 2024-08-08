using PatchToolService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatchToolService.Interfaces
{
    public interface IJSONManipulation
    {
        void SerializeJSONToFile(FullVersion fullVersionJsonFile, string filePath);

        FullVersion DeserializeJSONFile(string filePath);

    }
}
