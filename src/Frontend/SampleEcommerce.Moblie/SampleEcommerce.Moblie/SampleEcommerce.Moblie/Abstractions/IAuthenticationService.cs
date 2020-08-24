using SampleEcommerce.Mobile.Data;
using SampleEcommerce.Mobile.Data.Dto;
using System.Threading.Tasks;

namespace SampleEcommerce.Mobile.Abstractions
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated();
        Task<bool> CheckLoginAsync(string login, bool isUser);

        Task<AuthenticationResult> LoginAsync(AuthenticationDto authenticationDto);
        Task<AuthenticationResult> SignUp(CustomerToAdd userToAdd);

        void SignOut();
    }
}
