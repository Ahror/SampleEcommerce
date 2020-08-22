using System;
using System.Collections.Generic;
using SampleEcommerce.Moblie.ViewModels;
using SampleEcommerce.Moblie.Views;
using Xamarin.Forms;

namespace SampleEcommerce.Moblie
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
