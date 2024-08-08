using PatchToolService.Classes;
using PatchToolService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolTests
{
    public class VersionNumberHelperTests
    {
        private readonly VersionNumberHelper _sut;
        public VersionNumberHelperTests()
        {
            _sut = new VersionNumberHelper();
        }

        [Theory, ]
        [InlineData("1.2.5")]
        [InlineData("9.0.4")]
        [InlineData("2.3.4")]
        [InlineData("0.4.0")]
        public void TestSplitVersionNumber(string versionNumber)
        {
            _sut.SplitVersionNumber(versionNumber);
        }

        [Fact]
        public void TestSplitWithemptyVersionNumber()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SplitVersionNumber(""));
        }

        [Fact]
        public void TestSplitWithWhiteSpaceVersionNumber()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.SplitVersionNumber("   "));
        }

        [Fact]
        public void TestSplitWithInvalidCharactersSpaceVersionNumber()
        {
            Assert.Throws<InvalidCastException>(() => _sut.SplitVersionNumber(" a.5.e  "));
        }

        [Fact]
        public void TestGetMajorReleaseVersion()
        {
            _sut.GetMajorReleaseVersion("5.2.1");

            Assert.Equal("6.0.0", _sut.GetMajorReleaseVersion("5.2.1"));
        }

        [Fact]
        public void TestGetMinorReleaseVersion()
        {
            Assert.Equal("5.3.0", _sut.GetMinorReleaseVersion("5.2.1"));
        }

        [Fact]
        public void TestGetPatchReleaseVersion()
        {
            Assert.Equal("5.2.2", _sut.GetPatchReleaseVersion("5.2.1"));
        }



    }
}   
