using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Interfaces
{
    public interface IFilePathHelper
    {
        public string FilePath { get; set; }

        public void GetFilePath(bool testmode);
 
    }
}
