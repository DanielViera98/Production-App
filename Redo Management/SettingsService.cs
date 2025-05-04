using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections;

namespace Redo_Management.Services;

public class SettingsModel
{
    public ObservableCollection<string> Roles { get; set; } = new();
    public ObservableCollection<string> Departments { get; set; } = new();
    // Add more settings fields as needed
}

public static class SettingsService
{
    //Create folder for app in AppData, create settings.json
    private static readonly string AppFolder = Path.Combine(FileSystem.AppDataDirectory, "Redo_Management");
    private static readonly string FilePath = Path.Combine(AppFolder, "settings.json");

    public static SettingsModel Settings { get; private set; } = new();

    public static async Task InitializeAsync()
    {
        if (!File.Exists(FilePath))
        {
            // Create default settings file
            Settings = GetDefaultSettings();
            await SaveAsync();
        }
        else
        {
            var json = await File.ReadAllTextAsync(FilePath);
            var loaded = JsonSerializer.Deserialize<SettingsModel>(json);
            Settings = loaded ?? GetDefaultSettings();
        }
    }

    public static async Task SaveAsync()
    {
        var json = JsonSerializer.Serialize(Settings, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(FilePath, json);
    }

    public static ArrayList GetDepartments()
    {
        //Open settings file
        FileStream fs = File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

        ArrayList departments = [];


        return departments;
    }

    private static SettingsModel GetDefaultSettings() => new()
    {
        Roles = new ObservableCollection<string> { "Manager", "Assistant Manager", "Employee" },
        Departments = new ObservableCollection<string> { "Freezers", "Aisle 1", "Aisle 2" }
    };
}
