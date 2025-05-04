using Redo_Management.Services;

namespace Redo_Management
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            Task.Run(async () => await SettingsService.InitializeAsync());

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}