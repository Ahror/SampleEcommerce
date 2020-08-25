using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.Services.Dialog;
using SampleEcommerce.Mobile.Services.Navigation;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class CheckoutViewModel : BaseViewModel
    {
        public CheckoutViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
