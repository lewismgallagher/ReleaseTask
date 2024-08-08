using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Classes
{
    public class VersionSelectionHelper : IVersionSelectionHelper
    {
        private readonly JSONManipulation _jSONManipulation;

        private readonly VersionNumberHelper _versionNumberHelper;

        public VersionSelectionHelper(JSONManipulation jSONManipulation, VersionNumberHelper versionNumberHelper)
        {
            _versionNumberHelper = versionNumberHelper;
            _jSONManipulation = jSONManipulation;
        }


        public void VersionSelectionPrompt()
        {
            try
            {
                string filepath = @"C:\Users\lewis\source\repos\PatchTool\PatchToolService\AppVersion.json";

                Console.WriteLine("Please enter Major, Minor or Patch based on what release you intend to do.");

                bool choiceBeenMade = false;

                while (choiceBeenMade == false)
                {

                    string input = Console.ReadLine().ToLower();

                    switch (input)
                    {
                        case "major":
                            {
                                choiceBeenMade = true;

                                var json = _jSONManipulation.DeserializeJSONFile(filepath);

                                json.Version = _versionNumberHelper.GetMajorReleaseVersion(json.Version);

                                _jSONManipulation.SerializeJSONToFile(json, filepath);

                                Console.WriteLine("Major release successful.");
                            }
                            break;
                        case "minor":
                            {
                                choiceBeenMade = true;
                                var json = _jSONManipulation.DeserializeJSONFile(filepath);

                                json.Version = _versionNumberHelper.GetMinorReleaseVersion(json.Version);

                                _jSONManipulation.SerializeJSONToFile(json, filepath);

                                Console.WriteLine("Minor release successful.");
                            }
                            break;
                        case "patch":
                            {
                                choiceBeenMade = true;

                                var json = _jSONManipulation.DeserializeJSONFile(filepath);
                                json.Version = _versionNumberHelper.GetPatchReleaseVersion(json.Version);

                                _jSONManipulation.SerializeJSONToFile(json, filepath);

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
