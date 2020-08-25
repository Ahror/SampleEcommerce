using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using System;
using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.Data;
using SampleEcommerce.Mobile.Data.Dto;
using SampleEcommerce.Mobile.Helper;
using SampleEcommerce.Mobile.Services.Navigation;
using SampleEcommerce.Mobile.Services.Authentication;
using SampleEcommerce.Mobile.Services.Dialog;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        public string Username
        {
            get => username;
            set => this.RaiseAndSetIfChanged(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }
        public ReactiveCommand<Unit, Unit> LoginWithFacebookCommand { get; }
        public ReactiveCommand<Unit, Unit> SignUpCommand { get; }

        protected IAuthenticationService AuthenticationService;


        public LoginViewModel(
            INavigationService navigationService,
            IAuthenticationService authentication,
            IDialogService dialogService) : base(navigationService, dialogService)
        {
            AuthenticationService = authentication;

            var canLogin = this.WhenAnyValue(x => x.Username, y => y.Password, (Username, Password) => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password));
            LoginCommand = ReactiveCommand.CreateFromTask(Login, canLogin);
            LoginCommand.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);

            LoginWithFacebookCommand = ReactiveCommand.Create(LoginWithFacebook);
            LoginWithFacebookCommand.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);

            SignUpCommand = ReactiveCommand.CreateFromTask(SignUp);
            SignUpCommand.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);

            CatchObservableExceptions(LoginCommand, LoginWithFacebookCommand, SignUpCommand);
        }

        private Task SignUp()
        {
            return Task.CompletedTask;//Sign up here
        }

        private async Task Login()
        {
            AuthenticationResult result = await AuthenticationService.LoginAsync(new AuthenticationDto { Username = Username, Password = Password.EncryptString() });
            if (result.IsSuccess)
            {
                NavigationService.SetHomePage();
            }
            else
            {
                await DialogService.ShowMessage("Login in problem", result.Message);
            }
        }

        private void LoginWithFacebook()
        {
            //Login with Facebook
        }
    }
}
