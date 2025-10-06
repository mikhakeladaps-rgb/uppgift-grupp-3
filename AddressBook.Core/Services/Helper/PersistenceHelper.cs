using System.Text.Json;

// en helper för att spara/läsa kontakter till en JSON-fil. Kommer tas bort och bytas ut mot FileService.  
public static class PersistenceHelper
{
    private static readonly string DataDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AddressBook"
    );

    private static readonly string DataFilePath = Path.Combine(DataDirectory, "contacts.json");

    // TODO: När FileService finns: ersätt med FileService.Save(contacts)
    public static void SaveContacts(List<ContactList> contacts)
    {
        try
        {
            if (!Directory.Exists(DataDirectory))
                Directory.CreateDirectory(DataDirectory);

            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[WARNING] could not save contacts: {ex.Message}");
        }
    }

     // TODO: När FileService finns: ersätt med contacts = FileService.Load()
    public static List<ContactList> LoadContacts()
    {
        try
        {
            if (!File.Exists(DataFilePath))
                return new List<ContactList>();

            var json = File.ReadAllText(DataFilePath);
            var loaded = JsonSerializer.Deserialize<List<ContactList>>(json);
            return loaded ?? new List<ContactList>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[WARNING] could not read contacts: {ex.Message}");
            return new List<ContactList>();
        }
    }
}
