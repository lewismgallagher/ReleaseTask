using PatchToolService.Enums;
using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Classes
{
    public class VersionNumberHelper : IVersionNumberHelper
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }

        public string GetMajorReleaseVersion(string version)
        {
            SplitVersionNumber(version);

            Major = Major + 1;
            Minor = 0;
            Patch = 0;

            return Major + "." + Minor + "." + Patch;
        }

        public string RunRelease(ReleaseTypeEnum releaseType, string version)
        {
            if (releaseType == ReleaseTypeEnum.Major) return GetMajorReleaseVersion(version);

            if (releaseType == ReleaseTypeEnum.Minor)return GetMinorReleaseVersion(version);

            if (releaseType == ReleaseTypeEnum.Patch)return GetPatchReleaseVersion(version);

            return "";
        }

        public string GetMinorReleaseVersion(string version)
        {
            SplitVersionNumber(version);

            Minor = Minor + 1;
            Patch = 0;

            return Major + "." + Minor + "." + Patch;
        }

        public string GetPatchReleaseVersion(string version)
        {
            SplitVersionNumber(version);

            Patch = Patch + 1;

            return Major + "." + Minor + "." + Patch;
        }

        public void SplitVersionNumber(string versionNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(versionNumber))
                {
                    throw new ArgumentNullException("Error, invalid version number, version number cannot be empty.");
                }

                string[] strings = versionNumber.Split('.');

                if (int.TryParse(strings[0], out int major) &&
                  int.TryParse(strings[1], out int minor) &&
                  int.TryParse(strings[2], out int patch))
                {
                    Major = major;
                    Minor = minor;
                    Patch = patch;
                }
                else throw new InvalidCastException("Error, invalid version number," +
                    " version number could not be converted," +
                    " please ensure the version number contains only numbers and 3 decimal places e.g. 1.2.45");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
