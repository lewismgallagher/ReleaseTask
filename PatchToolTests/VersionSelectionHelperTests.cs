using PatchToolService.Classes;
using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace PatchToolTests
{
    public class VersionSelectionHelperTests
    {

        [Fact]
        public void TestMajorRelease()
        {
            var jSONManipulation = new Mock<IJSONManipulation>();
            var versionNumberHelper = new Mock<IVersionNumberHelper>();

            var sut = new VersionSelectionHelper(jSONManipulation.Object, versionNumberHelper.Object);
            sut.TestMode = true;
            sut.input = "major";
            sut.FilePath = @"C:\\Users\\lewis\\Documents\\coding stuff\\source\\BitBucket\\PatchTool\\PatchToolTests\\AppVersion.json";
            
            sut.VersionSelectionPrompt();
        }
    }
}
