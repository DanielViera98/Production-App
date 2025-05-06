using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;

namespace Redo_Management
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Add Firebase Authentication
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyAoKvO7yaFfmLvQ9nIi3Dx20TofOOCVw2E",
                AuthDomain = "productivity-app-8efc0.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
            return builder.Build();
        }
    }
}
