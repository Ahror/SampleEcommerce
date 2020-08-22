using System.Threading.Tasks;
using Autofac;
using ReactiveUI;
using Xamarin.Forms;
using System.Linq;
using SampleEcommerce.Moblie.Abstractions;
using SampleEcommerce.Moblie.ViewModels;
using SampleEcommerce.Moblie.Views;

namespace SampleEcommerce.Moblie.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation Navigation => Shell.Current == null ? Application.Current.MainPage.Navigation : Shell.Current.Navigation;

        private Shell _currentShell => Shell.Current;
        public IAuthenticationService AuthenticationService;
        public NavigationService(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        public Task GoToAsync(string route)
        {
            return _currentShell.GoToAsync(route, true);
        }

        public Task NavigateAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            var view = GetView(viewModel);
            return Navigation.PushAsync(view);
        }

        public Task NavigateAsync<TViewModel>(params (string paramaterName, object value)[] parameters) where TViewModel : BaseViewModel
        {
            var view = GetView<TViewModel>(parameters);
            return Navigation.PushAsync(view);
        }

        public Task NavigateAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            var view = GetView<TViewModel>();
            return Navigation.PushAsync(view);
        }

        public Task NavigateModalAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            var view = GetView<TViewModel>();
            return Navigation.PushModalAsync(view);
        }

        public Task NavigateModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
        {
            var view = GetView(viewModel);
            return Navigation.PushModalAsync(view);
        }

        public void SetMainPage<TViewModel>() where TViewModel : BaseViewModel
        {
            var view = GetView<TViewModel>();
            if (view is LoginPage loginPage)
            {
                Application.Current.MainPage = new NavigationPage(loginPage);
            }
            else
            {
                Application.Current.MainPage = view;
            }
        }

        public Task GoToHomePage()
        {
            return _currentShell.Navigation.PopToRootAsync(true);
        }

        public Task GoBackAsync()
        {
            return Navigation.PopAsync();
        }

        #region ResolvinPage

        private Page GetView<TViewModel>(TViewModel viewMode) where TViewModel : BaseViewModel
        {
            var view = DependencyInitializerCore.Container.Resolve<IViewFor<TViewModel>>();
            ((IViewFor)view).ViewModel = viewMode;
            return (Page)view;
        }

        private Page GetView<TVieWModel>(params (string paramaterName, object value)[] parameters) where TVieWModel : BaseViewModel
        {
            var namedParameters = parameters.Select(param => new NamedParameter(param.paramaterName, param.value));
            var viewModel = DependencyInitializerCore.Container.Resolve<TVieWModel>(namedParameters);
            return GetView(viewModel);
        }

        private Page GetView<TVieWModel>() where TVieWModel : BaseViewModel
        {
            var viewModel = DependencyInitializerCore.Container.Resolve<TVieWModel>();
            return GetView(viewModel);
        }

        public void InitMainPage()
        {
            if (AuthenticationService.IsAuthenticated())
            {
                SetHomePage();
            }
            else
            {
                SetMainPage<LoginViewModel>();
            }
        }

        public void SetHomePage()
        {
            SetMainPage<LoginViewModel>();
        }
        #endregion
    }
}
