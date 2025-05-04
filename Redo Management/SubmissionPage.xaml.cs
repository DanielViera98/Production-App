using System.Collections.ObjectModel;
using System.ComponentModel;
using Redo_Management.Services;

namespace Redo_Management;

public partial class SubmissionPage : ContentPage, INotifyPropertyChanged
{
	public SubmissionPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

    public ObservableCollection<string> DepartmentOptions { get; } = new()
	{
		SettingsModel() test = new SettingsModel();
	};

    string selectedOption = "";
    public string SelectedOption
    {
        get => selectedOption;
        set
        {
            if (selectedOption != value)
            {
                selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));
            }
        }
    }
}