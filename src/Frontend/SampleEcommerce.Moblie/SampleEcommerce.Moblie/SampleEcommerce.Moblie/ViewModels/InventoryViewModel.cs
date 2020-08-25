using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.Services.Dialog;
using SampleEcommerce.Mobile.Services.Navigation;

namespace SampleEcommerce.Mobile.ViewModels
{
    class InventoryViewModel : BaseViewModel
    {
        public InventoryViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
