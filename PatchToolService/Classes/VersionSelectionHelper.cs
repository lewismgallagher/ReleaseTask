using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Classes
{
    public class VersionSelectionHelper : IVersionSelectionHelper
    {
        private readonly IJSONManipulation _jSONManipulation;

        private readonly IVersionNumberHelper _versionNumberHelper;

        private readonly IFilePathHelper _filePathHelper;

        public bool TestMode { get; set; }

        public string input { get; set; }
        public string FilePath { get; set; }
        public bool ValidChoiceAccepted { get; set; }

        public VersionSelectionHelper(IJSONManipulation jSONManipulation, IVersionNumberHelper versionNumberHelper, IFilePathHelper filePathHelper)
        {
            _versionNumberHelper = versionNumberHelper;
            _jSONManipulation = jSONManipulation;
            _filePathHelper = filePathHelper;
        }


        public void VersionSelectionPrompt()
        {
            try
            {               


                if (TestMode) {
                    FilePath = @"C:\Users\lewis\Documents\coding stuff\source\BitBucket\PatchTool\PatchToolTests\AppVersion.json;"; }
                else {

                    FilePath = @"C:\Users\lewis\Documents\coding stuff\source\BitBucket\PatchTool\PatchToolService\AppVersion.json";
                    Console.WriteLine("Please enter Major, Minor or Patch based on what release you intend to do.");
                }


                while (ValidChoiceAccepted == false)
                {
                    if (!TestMode) { input = Console.ReadLine().ToLower(); }

                    switch (input)
                    {
                        case "major":
                            {
                                ValidChoiceAccepted = true;

                                var json = _jSONManipulation.DeserializeJSONFile(FilePath);

                                json.Version = _versionNumberHelper.GetMajorReleaseVersion(json.Version);

                                _jSONManipulation.SerializeJSONToFile(json, FilePath);

                                Console.WriteLine("Major release successful.");
                            }
                            break;
                        case "minor":
                            {
                                ValidChoiceAccepted = true;
                                var json = _jSONManipulation.DeserializeJSONFile(FilePath);

                                json.Version = _versionNumberHelper.GetMinorReleaseVersion(json.Version);

                                _jSONManipulation.SerializeJSONToFile(json, FilePath);

                                Console.WriteLine("Minor release successful.");
                            }
                            break;
                        case "patch":
                            {
                                ValidChoiceAccepted = true;

                                var json = _jSONManipulation.DeserializeJSONFile(FilePath);
                                json.Version = _versionNumberHelper.GetPatchReleaseVersion(json.Version);

                                _jSONManipulation.SerializeJSONToFile(json, FilePath);

                                Console.WriteLine("Patch successful.");

                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            Console.WriteLine("Please enter Major, Minor or Patch based on what release you intend to do.");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
