using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Data
{
    public class Patch
    {
        public string Name { get; set; }
        public string Directory { get; set; }
        public string Ordinal { get; set; }
        public string[] Scripts { get; set; }

    }
}
