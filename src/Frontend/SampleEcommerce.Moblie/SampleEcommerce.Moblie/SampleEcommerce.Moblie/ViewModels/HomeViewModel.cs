using SampleEcommerce.Mobile.Abstractions;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(
            INavigationService navigationService,
            IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

    }
}