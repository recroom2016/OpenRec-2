namespace OpenRec_2.Database;

using System.IO;
using System.Threading.Tasks;

public static class DatabaseManager
{
    private static readonly string BaseDirectory = "Storage";

    public static async Task SaveAsync(string identifier, string key, string data)
    {
        string userDirectory = Path.Combine(BaseDirectory, identifier);
        
        if (!Directory.Exists(userDirectory))
        {
            Directory.CreateDirectory(userDirectory);
        }

        string filePath = Path.Combine(userDirectory, $"{key}.json");
        
        await File.WriteAllTextAsync(filePath, data);
    }

    public static async Task<string> LoadAsync(string identifier, string key)
    {
        string filePath = Path.Combine(BaseDirectory, identifier, $"{key}.json");

        if (File.Exists(filePath))
        {
            return await File.ReadAllTextAsync(filePath);
        }

        return string.Empty;
    }
}