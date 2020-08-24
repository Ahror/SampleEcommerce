using SampleEcommerce.Mobile.Abstractions;

namespace SampleEcommerce.Mobile.ViewModels
{
    class InventoryViewModel : BaseViewModel
    {
        public InventoryViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
