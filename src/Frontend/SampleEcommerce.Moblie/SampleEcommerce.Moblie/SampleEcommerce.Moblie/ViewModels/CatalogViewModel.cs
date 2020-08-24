using SampleEcommerce.Mobile.Abstractions;

namespace SampleEcommerce.Mobile.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        public CatalogViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
