using System.Text.Json;
using System.Text.Json.Nodes;
using PatchToolService.Data;
using PatchToolService.Interfaces;

namespace PatchToolService.Classes
{
    public class JSONManipulation : IJSONManipulation
    {

        public FullVersion DeserializeJSONFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath) == false)
                {
                   throw new FileNotFoundException("Error, File Not Found, Please check the file path and your file / folder permissions.");
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    var jsonFile = reader.ReadToEnd();

                    var deserializedJson = JsonSerializer.Deserialize<FullVersion>(jsonFile);

                    if (deserializedJson == null || string.IsNullOrWhiteSpace(deserializedJson.Version))
                    {
                        throw new InvalidDataException(
                        "Error, could not increment version, the version was invalid empty. Please check the file.");
                    }
                    return deserializedJson;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SerializeJSONToFile(FullVersion fullVersionJsonFile, string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    throw new InvalidDataException("Error, no filepath provided, please provide a filepath.");
                }

                var options = new JsonSerializerOptions();

                options.WriteIndented = true;

                string json = JsonSerializer.Serialize<FullVersion>(fullVersionJsonFile, options);

                File.WriteAllText(filePath, json);

            }
            catch (Exception)
            {
                throw;
            }
        }





        



    }
}
