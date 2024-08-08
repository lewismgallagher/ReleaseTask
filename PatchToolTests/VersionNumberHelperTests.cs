using PatchToolService.Classes;
using PatchToolService.Data;
using PatchToolService.Enums;
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

        [Theory]
        [InlineData(ReleaseTypeEnum.Major,"1.2.5")]
        [InlineData(ReleaseTypeEnum.Minor,"2.7.8")]
        [InlineData(ReleaseTypeEnum.Patch,"4.1.1")]
        public void TestFinishReleaseMultipleParams(ReleaseTypeEnum releaseType, string version)
        {
            _sut.GetReleaseVersionNumber(releaseType, version);
        }

        [Theory]
        [InlineData(ReleaseTypeEnum.Major, "44.25.1")]
        public void TestFinishReleaseMajor(ReleaseTypeEnum releaseType, string version)
        {
           string releaseNumber = _sut.GetReleaseVersionNumber(releaseType, version);

            Assert.Equal(releaseNumber, "45.0.0");

        }

        [Theory]
        [InlineData(ReleaseTypeEnum.Minor, "44.25.1")]
        public void TestFinishReleaseMinor(ReleaseTypeEnum releaseType, string version)
        {
            string releaseNumber = _sut.GetReleaseVersionNumber(releaseType, version);

            Assert.Equal(releaseNumber, "44.26.0");

        }

        [Theory]
        [InlineData(ReleaseTypeEnum.Patch, "44.25.1")]
        public void TestFinishReleasePatch(ReleaseTypeEnum releaseType, string version)
        {
            string releaseNumber = _sut.GetReleaseVersionNumber(releaseType, version);

            Assert.Equal(releaseNumber, "44.25.2");

        }

        [Theory]
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
            _sut.UpdateMajorReleaseVersion("5.2.1");

            Assert.Equal("6.0.0", _sut.UpdateMajorReleaseVersion("5.2.1"));
        }

        [Fact]
        public void TestGetMinorReleaseVersion()
        {
            Assert.Equal("5.3.0", _sut.UpdateMinorReleaseVersion("5.2.1"));
        }

        [Fact]
        public void TestGetPatchReleaseVersion()
        {
            Assert.Equal("5.2.2", _sut.UpdatePatchReleaseVersion("5.2.1"));
        }



    }
}   
