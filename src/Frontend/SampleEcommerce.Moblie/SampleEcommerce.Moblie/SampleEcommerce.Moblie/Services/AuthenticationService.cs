using Refit;
using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.Abstractions.Api;
using SampleEcommerce.Mobile.Data;
using SampleEcommerce.Mobile.Data.Dto;
using SampleEcommerce.Mobile.Helper;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        protected readonly IAuthenticationApi httpClient;
        private readonly IAppSettings appSettings;

        public AuthenticationService(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
            httpClient = RestService.For<IAuthenticationApi>(Constants.BaseUri);
        }

        protected void SaveAuthenticationData(AuthenticationResult authenticationResult)
        {
            if (authenticationResult.Customer != null)
                appSettings.Customer = authenticationResult.Customer;
        }

        protected void DeleteAuthenticationData()
        {
            appSettings.Customer = null;
        }

        public bool IsAuthenticated()
        {
            return appSettings.Customer != null;
        }

        public async Task<bool> CheckLoginAsync(string login, bool isUser)
        {
            return await httpClient.CheckCustomerLogin(login);
        }

        public async Task<AuthenticationResult> LoginAsync(AuthenticationDto authenticationDto)
        {
            AuthenticationResult result = await httpClient.LoginAsync(authenticationDto);

            SaveAuthenticationData(result);
            return result;
        }

        public async Task<AuthenticationResult> SignUp(CustomerToAdd customerToAdd)
        {
            var result = await httpClient.SignUp(customerToAdd);
            SaveAuthenticationData(result);
            return result;
        }

        public void SignOut()
        {
            DeleteAuthenticationData();
        }
    }
}
