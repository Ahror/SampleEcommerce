using SampleEcommerce.Mobile.Abstractions;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public CartViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
