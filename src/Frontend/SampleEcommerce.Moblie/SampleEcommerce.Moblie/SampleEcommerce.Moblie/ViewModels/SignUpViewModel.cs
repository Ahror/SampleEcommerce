using ReactiveUI;
using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.Services.Authentication;
using SampleEcommerce.Mobile.Services.Dialog;
using SampleEcommerce.Mobile.Services.Navigation;
using System.Linq;
using System.Reactive;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private string login;
        public string Login
        {
            get => login;
            set => this.RaiseAndSetIfChanged(ref login, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);
        }

        private string email;
        public string Email
        {
            get => email;
            set => this.RaiseAndSetIfChanged(ref email, value);
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => this.RaiseAndSetIfChanged(ref firstName, value);
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set => this.RaiseAndSetIfChanged(ref lastName, value);
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get => lastName;
            set => this.RaiseAndSetIfChanged(ref phoneNumber, value);
        }

        public ReactiveCommand<Unit, Unit> SignUpCommand { get; }

        protected readonly IAuthenticationService authenticationService;

        public SignUpViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
            this.authenticationService = authenticationService;
            var canSignUp = this.WhenAnyValue(
                l => l.Login,
                p => p.Password,
                e => e.Email,
                f => f.FirstName,
                ln => ln.LastName,
                (login, password, email, firstName, lastName) => ValidateAll(login, password, email, firstName, lastName));
            SignUpCommand = ReactiveCommand.Create(SignUp, canSignUp);
        }

        private bool ValidateAll(string login, string password, string email, string firstName, string lastName)
        {
            return ValidateLogin(login)
                && ValidatePassword(password)
                && ValidateEmail(email)
                && ValidateName(firstName)
                && ValidateName(lastName);
        }
        private bool ValidateLogin(string login)
        {
            if (string.IsNullOrEmpty(login) || login.Length < 4) return false;
            else if (Regex.IsMatch(login, @"\p{IsCyrillic}")) return false;
            return true;
        }

        private async Task<bool> CheckLogin(string login)
        {
            return await authenticationService.CheckLoginAsync(login);
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 5) return false;
            else if (Regex.IsMatch(password, @"\p{IsCyrillic}")) return false;
            else if (!password.Any(char.IsUpper)) return false;
            else if (!password.Any(char.IsDigit)) return false;
            return true;
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        private bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3) return false;
            else if (Regex.IsMatch(name, @"\p{IsCyrillic}")) return false;
            return true;
        }

        private async void SignUp()
        {
            if (await CheckLogin(Login))
            {
                await DialogService.ShowMessage("Invalid login", "This login is already exists");
            }
            else
            {
                var result = await authenticationService.SignUp(
                      new Data.CustomerToAdd
                      {
                          Email = Email,
                          FirstName = FirstName,
                          LastName = LastName,
                          Username = Login,
                          Password = Password,
                          PhoneNumber = PhoneNumber,
                          Role = "Role"
                      }
                      );
                if (result.IsSuccess)
                    await NavigationService.GoToHomePage();
                else
                    await DialogService.ShowMessage("Sign up failed", "Something went wrong. Please try again.");
            }
        }
    }
}
