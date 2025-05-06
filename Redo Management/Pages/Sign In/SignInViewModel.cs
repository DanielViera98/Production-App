using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace Redo_Management.Pages.Sign_In
{
    public partial class SignInViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

        public SignInViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }
        [RelayCommand]
        private async Task SignIn()
        {
            await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);
        }

        [RelayCommand]
        private async Task NavigateSignUp()
        {

        }
    }
}