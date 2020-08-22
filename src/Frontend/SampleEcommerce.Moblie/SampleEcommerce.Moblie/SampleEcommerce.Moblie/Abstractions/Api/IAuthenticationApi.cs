using Refit;
using SampleEcommerce.Moblie.Data;
using SampleEcommerce.Moblie.Data.Dto;
using System.Threading.Tasks;

namespace SampleEcommerce.Moblie.Abstractions.Api
{
    public interface IAuthenticationApi
    {
        [Post("/api/customer/authenticate")]
        Task<AuthenticationResult> LoginAsync(AuthenticationDto authenticationDto);

        [Post("/api/customer/signup")]
        Task<AuthenticationResult> SignUp(CustomerToAdd customerToAdd);

        [Get("/api/customer/checklogin/{login}")]
        Task<bool> CheckCustomerLogin(string login);
    }

}
