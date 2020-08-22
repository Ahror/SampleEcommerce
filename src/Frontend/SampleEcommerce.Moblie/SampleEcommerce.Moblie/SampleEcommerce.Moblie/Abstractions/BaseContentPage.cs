using ReactiveUI;
using Xamarin.Forms;

namespace SampleEcommerce.Moblie.Abstractions
{
    public abstract class BaseContentPage<TViewModel> : ContentPage, IViewFor<TViewModel>
        where TViewModel : BaseViewModel
    {
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => BindingContext = ViewModel = value as TViewModel;
        }

        public TViewModel ViewModel { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ViewAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.ViewDisappearing();
        }
    }
}
