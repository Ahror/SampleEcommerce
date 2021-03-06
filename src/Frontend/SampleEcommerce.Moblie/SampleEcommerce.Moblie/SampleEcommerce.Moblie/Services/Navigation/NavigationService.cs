﻿using System.Threading.Tasks;
using Autofac;
using ReactiveUI;
using Xamarin.Forms;
using System.Linq;
using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.ViewModels;
using SampleEcommerce.Mobile.Views;
using SampleEcommerce.Mobile.Services.Authentication;

namespace SampleEcommerce.Mobile.Services.Navigation
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

        #region ResolvingPage

        private Page GetView<TViewModel>(TViewModel viewMode) where TViewModel : BaseViewModel
        {
            var view = DependencyInitializer.Container.Resolve<IViewFor<TViewModel>>();
            ((IViewFor)view).ViewModel = viewMode;
            return (Page)view;
        }

        private Page GetView<TVieWModel>(params (string paramaterName, object value)[] parameters) where TVieWModel : BaseViewModel
        {
            var namedParameters = parameters.Select(param => new NamedParameter(param.paramaterName, param.value));
            var viewModel = DependencyInitializer.Container.Resolve<TVieWModel>(namedParameters);
            return GetView(viewModel);
        }

        private Page GetView<TVieWModel>() where TVieWModel : BaseViewModel
        {
            var viewModel = DependencyInitializer.Container.Resolve<TVieWModel>();
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
            SetMainPage<HomeViewModel>();
        }
        #endregion
    }
}
