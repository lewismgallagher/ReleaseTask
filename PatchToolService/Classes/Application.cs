using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Classes
{
    public class Application :IApplication
    {
        private readonly IJSONManipulation _jSONManipulation;

        private readonly IVersionNumberHelper _versionNumberHelper;
        private readonly IVersionSelectionHelper _versionSelectionHelper;
        private readonly IFilePathHelper _filePathHelper;

        public bool TestMode { get; set; }
        public Application(IVersionSelectionHelper versionSelectionHelper, IFilePathHelper filePathHelper, IVersionNumberHelper versionNumberHelper, IJSONManipulation jSONManipulation)
        {
            _versionSelectionHelper = versionSelectionHelper;
            _versionNumberHelper = versionNumberHelper;
            _jSONManipulation = jSONManipulation;
            _filePathHelper = filePathHelper;
        }
        public void Start(bool testmode)
        {
            _filePathHelper.GetFilePath(testmode);

            _versionSelectionHelper.StartVersionSelectionPrompt();
        }
    }
}
