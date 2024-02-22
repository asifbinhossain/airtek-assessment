interface IJsonReader
{
    string ReadJsonFile(string filePath);
}

class FileJsonReader : IJsonReader
{
    public string ReadJsonFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error reading JSON file: {ex.Message}");
        }
    }
}