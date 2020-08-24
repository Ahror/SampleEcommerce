using SampleEcommerce.Mobile.Abstractions;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
