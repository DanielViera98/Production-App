namespace Redo_Management;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
	}
    private void OnCreateSubmissionClicked(object sender, EventArgs e)
    {
        // Handle sign-in logic here
        Navigation.PushAsync(new SubmissionPage());
    }

    private void OnLogOutClicked(object sender, EventArgs e)
    {
        // Handle sign-in logic here
        Navigation.PushAsync(new MainPage());
    }

    private void OnSettingsClicked(object sender, EventArgs e)
    {
        // Handle sign-in logic here
        Navigation.PushAsync(new SettingsPage());
    }
}