using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Classes
{
    public class FilePathHelper: IFilePathHelper
    {
        public string FilePath { get; set; }

        public void GetFilePath(bool testmode)
        {
            if (!testmode)
            {
                FilePath = @"C:\Users\lewis\Documents\coding stuff\source\BitBucket\PatchTool\PatchToolService\AppVersion.json";
            }
            else FilePath = @"C:\Users\lewis\Documents\coding stuff\source\BitBucket\PatchTool\PatchToolTests\AppVersion.json";
        }
    }
}
