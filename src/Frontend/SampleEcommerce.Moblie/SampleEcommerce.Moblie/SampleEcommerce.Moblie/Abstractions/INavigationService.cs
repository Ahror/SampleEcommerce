using System.Threading.Tasks;

namespace SampleEcommerce.Moblie.Abstractions
{
    public interface INavigationService
    {
        void InitMainPage();
        void SetHomePage();
        Task GoToAsync(string route);
        Task NavigateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;
        Task NavigateAsync<TViewModel>(params (string paramaterName, object value)[] parameters) where TViewModel : BaseViewModel;
        Task NavigateAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateModalAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;
        void SetMainPage<TViewModel>() where TViewModel : BaseViewModel;
        Task GoToHomePage();
        Task GoBackAsync();
    }
}
