using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Interfaces
{
    public interface IVersionNumberHelper
    {
        int Major { get; set; }
        int Minor { get; set; }
        int Patch { get; set; }

        string GetMajorReleaseVersion(string version);

        string GetMinorReleaseVersion(string version);

        string GetPatchReleaseVersion(string version);

        void SplitVersionNumber(string versionNumber);
    }
}
