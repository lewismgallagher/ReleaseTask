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

            return Major + "." + Minor + "." + Patch;
        }

        public string GetMinorReleaseVersion(string version)
        {
            try
            {
                SplitVersionNumber(version);

                Minor = Minor + 1;
                Patch = 0;

                return Major + "." + Minor + "." + Patch;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public string GetPatchReleaseVersion(string version)
        {
            SplitVersionNumber(version);

            Patch = Patch+ 1;

            return Major + "." + Minor + "." + Patch;
        }

        public void SplitVersionNumber(string versionNumber)
        {

            string[] strings = versionNumber.Split('.');

            try
            {
                Major = int.Parse(strings[0]);
                Minor = int.Parse(strings[1]);
                Patch = int.Parse(strings[2]);
            }
            catch (Exception ex)
            {
                if (ex is InvalidCastException) { Console.WriteLine("ERROR! Version Number is in an incorrect format. " +
                    "Please ensure the version number looks like x.x.x"); }
                throw;
            }
        }


    }
}
