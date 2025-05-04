namespace Redo_Management
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSignInClicked(object sender, EventArgs e)
        {
            // Handle sign-in logic here
            Navigation.PushAsync(new LandingPage());
        }

        private void OnContinueClicked(object sender, EventArgs e)
        {
            // Handle continue logic here

        }

    }

}
