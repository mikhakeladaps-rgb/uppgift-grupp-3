using System.Text.Json;
using AddressBook.Core.Models;

namespace AddressBook.Core.Services
{
    public class FileService    // hantera läsning och skrivning till textfil
    {
        private readonly string _dataFilePath;
        public FileService(string? customPath = null)
        {
            _dataFilePath = !string.IsNullOrWhiteSpace(customPath)
                ? customPath!
                : Path.Combine(AppContext.BaseDirectory, "Data", "contacts.json");
        }

        // load from file

        public List<Contact> Load()
        {
            try
            {
                if (!File.Exists(_dataFilePath)) return new List<Contact>();
                // läs filen
                var json = File.ReadAllText(_dataFilePath);
                var contacts = JsonSerializer.Deserialize<List<Contact>>(json);
                return contacts ?? new List<Contact>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARNING] Could not read file: {ex.Message}");
                return new List<Contact>();
            }
        }

        // save to file
        public void Save(List<Contact> contacts)
        {
            try
            {
                var dir = Path.GetDirectoryName(_dataFilePath)!;
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_dataFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARNING] Could not save file: {ex.Message}");
            }
        }
    }
}