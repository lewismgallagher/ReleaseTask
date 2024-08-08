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

        public bool TestMode { get; set; }

        public void GetFilePath()
        {
            if (TestMode)
            {
                FilePath = @"C:\Users\lewis\Documents\coding stuff\source\BitBucket\PatchTool\PatchToolTests\AppVersion.json";
            }
            else FilePath = @"C:\Users\lewis\Documents\coding stuff\source\BitBucket\PatchTool\PatchToolTests\AppVersion.json";
        }
    }
}
