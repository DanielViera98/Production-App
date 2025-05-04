using System.Collections.ObjectModel;
using System.ComponentModel;
using Redo_Management.Services;

namespace Redo_Management;

public partial class SubmissionPage : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<Department> Departments => SettingsService.Settings.Departments;
    private Department selectedDepartment;

    public SubmissionPage()
	{
		InitializeComponent();
		BindingContext = this;

        //Add department names to picker
        foreach (var dept in SettingsService.Settings.Departments)
            DepartmentOptions.Add(dept.Name); 
    }

    public ObservableCollection<string> DepartmentOptions { get; } = new(){};

    public Department SelectedDepartment
    {
        get => selectedDepartment;
        set
        {
            if (selectedDepartment != value)
            {
                selectedDepartment = value;
                OnPropertyChanged(nameof(selectedDepartment));
            }
        }
    }
}