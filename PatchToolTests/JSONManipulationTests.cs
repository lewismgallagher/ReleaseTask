using PatchToolService.Classes;
using PatchToolService.Data;
using PatchToolService.Interfaces;

namespace PatchToolTests
{
    public class JSONManipulationTests
    {
        private readonly JSONManipulation _sut;
        public JSONManipulationTests()
        {
            _sut = new JSONManipulation();
        }

        [Fact]
        public void TestDeserializeJSONFile()
        {
            FullVersion fullVersion = new FullVersion();

            _sut.DeserializeJSONFile(@"C:\\Users\\lewis\\source\\repos\\PatchTool\\PatchToolTests\\AppVersion.json");
        }


        [Fact]
        public void TestDeserializeJSONFileWithEmptyFilePath()
        {
            FullVersion fullVersion = new FullVersion();

            Assert.ThrowsAny<FileNotFoundException>(() => _sut.DeserializeJSONFile(""));
        }

        [Fact]
        public void TestDeserializeJSONFileWithWhiteSpaceFilePath()
        {
            FullVersion fullVersion = new FullVersion();

            Assert.ThrowsAny<FileNotFoundException>(() => _sut.DeserializeJSONFile("   "));
        }

        [Fact]
        public void TestDeserializeJSONFileWithNullValuesInFile()
        {
            FullVersion fullVersion = new FullVersion();

            Assert.ThrowsAny<InvalidDataException>(() => _sut.DeserializeJSONFile(
                @"C:\Users\lewis\source\repos\PatchTool\PatchToolTests\AppVersionWithNulls.json"));
        }

        [Fact]
        public void TestDeserializeJSONFileWithIncorrectAttributes()
        {
            FullVersion fullVersion = new FullVersion();

            Assert.ThrowsAny<InvalidDataException>(() =>
            {
                _sut.DeserializeJSONFile(
                @"C:\Users\lewis\source\repos\PatchTool\PatchToolTests\AppVersionWithIncorrectAttributes.json");

                _sut.SerializeJSONToFile(fullVersion,
                @"C:\Users\lewis\source\repos\PatchTool\PatchToolTests\AppVersionWithIncorrectAttributes.json");
            }
            );
        }

        [Fact]
        public void TestSerializationToFile()
        {
            FullVersion fullVersion = new FullVersion();

            fullVersion = _sut.DeserializeJSONFile(@"C:\\Users\\lewis\\source\\repos\\PatchTool\\PatchToolTests\\AppVersion.json");

            _sut.SerializeJSONToFile(fullVersion,
                @"C:\\Users\\lewis\\source\\repos\\PatchTool\\PatchToolTests\\AppVersion.json");
        }

        [Fact]
        public void TestSerializationToFileWithEmptyFilePath()
        {
            FullVersion fullVersion = new FullVersion();

            fullVersion = _sut.DeserializeJSONFile(@"C:\\Users\\lewis\\source\\repos\\PatchTool\\PatchToolTests\\AppVersion.json");

            Assert.ThrowsAny<InvalidDataException>(() => _sut.SerializeJSONToFile(fullVersion, ""));
        }

        [Fact]
        public void TestSerializationToFileWithWhiteSpaceFilePath()
        {
            FullVersion fullVersion = new FullVersion();

            fullVersion = _sut.DeserializeJSONFile(@"C:\\Users\\lewis\\source\\repos\\PatchTool\\PatchToolTests\\AppVersion.json");

            Assert.ThrowsAny<InvalidDataException>(() => _sut.SerializeJSONToFile(fullVersion, "   "));
        }


    }
}