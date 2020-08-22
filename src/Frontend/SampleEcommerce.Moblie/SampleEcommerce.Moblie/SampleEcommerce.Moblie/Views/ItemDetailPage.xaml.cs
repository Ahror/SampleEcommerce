using System.ComponentModel;
using Xamarin.Forms;
using SampleEcommerce.Moblie.ViewModels;

namespace SampleEcommerce.Moblie.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}