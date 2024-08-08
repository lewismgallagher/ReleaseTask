using PatchToolService.Enums;
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

        public string GetReleaseVersionNumber(ReleaseTypeEnum releaseType, string version);
        string UpdateMajorReleaseVersion(string version);

        string UpdateMinorReleaseVersion(string version);

        string UpdatePatchReleaseVersion(string version);

        void SplitVersionNumber(string versionNumber);
    }
}
