using PatchToolService.Classes;
using PatchToolService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PatchToolService.Enums;
namespace PatchToolTests
{
    public class VersionSelectionHelperTests
    {

        [Theory]
        [InlineData(ReleaseTypeEnum.Major)]
        [InlineData(ReleaseTypeEnum.Minor)]
        [InlineData(ReleaseTypeEnum.Patch)]
        public void TestFinishReleaseTestForAllReleases(ReleaseTypeEnum releaseType)
        {
            var _jsonManipulation = new JSONManipulation();
            var _versionNumberHelper = new VersionNumberHelper();
            var _filePathHelper = new FilePathHelper();

            _filePathHelper.GetFilePath(true);

            var _sut = new VersionSelectionHelper(_jsonManipulation, _versionNumberHelper, _filePathHelper);

            _sut.ReleaseType = releaseType;

            _sut.FinishRelease();
        }

        [Theory]
        [InlineData("Major")]
        [InlineData("Minor")]
        [InlineData("Patch")]
        public void TestCamelCaseInputCheck(string inputValue)
        {
            var _jsonManipulation = new Mock<JSONManipulation>();
            var _versionNumberHelper = new Mock<VersionNumberHelper>();
            var _filePathHelper = new Mock<FilePathHelper>();

            var _sut = new VersionSelectionHelper(_jsonManipulation.Object, _versionNumberHelper.Object, _filePathHelper.Object);

            _sut.InputCheck(inputValue);
        }



        [Theory]
        [InlineData("major")]
        [InlineData("minor")]
        [InlineData("patch")]
        public void TestInputCheckAndFinishRelease(string inputValue)
        {
            var _jsonManipulation = new JSONManipulation();
            var _versionNumberHelper = new VersionNumberHelper();
            var _filePathHelper = new FilePathHelper();

            _filePathHelper.GetFilePath(true);

            var _sut = new VersionSelectionHelper(_jsonManipulation, _versionNumberHelper, _filePathHelper);

            _sut.InputCheck(inputValue);

            _sut.FinishRelease();
        }

    }
}
