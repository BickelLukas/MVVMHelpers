using System.Windows;
using System.Windows.Input;
using MVVMHelpers.Commands;
using MVVMHelpers.ViewModels;

namespace Examples.ViewModels
{
    public class CommandsExampleViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand LoginCommand => new RelayCommand(
            Login,
            () => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            .Observes(() => this.Username)
            .Observes(() => this.Password);

        private void Login()
        {
            // TODO: Make Call to Server
            MessageBox.Show("Login Successfull");
        }
    }
}
