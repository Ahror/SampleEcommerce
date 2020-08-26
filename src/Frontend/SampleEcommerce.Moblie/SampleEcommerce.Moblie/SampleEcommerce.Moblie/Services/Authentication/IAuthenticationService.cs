using SampleEcommerce.Mobile.Data;
using SampleEcommerce.Mobile.Data.Dto;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Services.Authentication
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated();
        Task<bool> CheckLoginAsync(string login);

        Task<AuthenticationResult> LoginAsync(AuthenticationDto authenticationDto);
        Task<AuthenticationResult> SignUp(CustomerToAdd userToAdd);

        void SignOut();
    }
}
