using PatchToolService.Enums;
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

        public ReleaseTypeEnum ReleaseType { get; set; }


        public VersionSelectionHelper(IJSONManipulation jSONManipulation, IVersionNumberHelper versionNumberHelper, IFilePathHelper filePathHelper)
        {
            _versionNumberHelper = versionNumberHelper;
            _jSONManipulation = jSONManipulation;
            _filePathHelper = filePathHelper;
        }

        public void InputCheck(string input)
        {
            ReleaseType = ReleaseTypeEnum.None;
            string lowerCaseInput = input.ToLower();

            if (lowerCaseInput == "major") { ReleaseType = ReleaseTypeEnum.Major; } 
            if(lowerCaseInput == "minor") { ReleaseType = ReleaseTypeEnum.Minor; }
            if (lowerCaseInput == "patch") { ReleaseType = ReleaseTypeEnum.Patch; }

        }

        public void FinishRelease()
        {
            var json = _jSONManipulation.DeserializeJSONFile(_filePathHelper.FilePath);

            json.Version = _versionNumberHelper.GetReleaseVersionNumber(ReleaseType, json.Version);

            _jSONManipulation.SerializeJSONToFile(json, _filePathHelper.FilePath);
            Console.WriteLine(ReleaseType.ToString() + " release successful.");
        }

        public void StartVersionSelectionPrompt()
        {
            try
            {

                Console.WriteLine("Please enter Major, Minor or Patch based on what release you intend to do.");
                string input = Console.ReadLine();

                InputCheck(input);

                while (ReleaseType == ReleaseTypeEnum.None)
                {
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine("Please enter Major, Minor or Patch based on what release you intend to do.");

                    InputCheck(input);
                }

                FinishRelease();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
