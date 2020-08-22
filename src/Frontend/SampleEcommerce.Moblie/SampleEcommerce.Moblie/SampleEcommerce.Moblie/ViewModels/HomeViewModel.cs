using SampleEcommerce.Moblie.Abstractions;

namespace SampleEcommerce.Moblie.ViewModels
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