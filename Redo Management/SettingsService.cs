using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections;
//using PassKit;
//using AuthenticationServices;

namespace Redo_Management.Services;

public class Department
{
    public required string Name { get; set; }
    public DateTime LastOrganized { get; set; }
    public Employee OrganizedBy { get; set; } = new Employee
    {
        Name = "",
        Position = "",
    };
}
public class Employee
{
    public required string Name { get; set; }
    public required string Position { get; set; }
}
public class Role
{
    public required string Name { get; set; }
}
public class SettingsModel
{
    public ObservableCollection<string> Roles { get; set; } = new();
    public ObservableCollection<Department> Departments { get; set; } = new();
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
        Departments = new ObservableCollection<Department>
        {
            new Department
            {
                Name = "Aisle 1",
                LastOrganized = DateTime.Now,
                OrganizedBy = new Employee
                {
                    Name = "John Doe",
                    Position = "Manager"
                }
            },
            new Department
            {
                Name = "Aisle 2",
                LastOrganized = DateTime.Now,
                OrganizedBy = new Employee
                {
                    Name = "Jane Smith",
                    Position = "Assistant Manager"
                }
            },
        }
    };
}
