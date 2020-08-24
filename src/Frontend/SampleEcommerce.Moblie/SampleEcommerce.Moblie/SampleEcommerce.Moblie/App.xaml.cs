using Xamarin.Forms;
using Autofac;
using SampleEcommerce.Mobile.Abstractions;

namespace SampleEcommerce.Mobile
{
    public partial class App : Application
    {
        private static IContainer _container;
        public App()
        {
            InitializeComponent();
            InitializeDependencies();
            InitializePage();
        }

        private void InitializePage()
        {
            _container.Resolve<INavigationService>().InitMainPage();
        }

        private void InitializeDependencies()
        {
            var dependencyInitializer = new DependencyInitializer();
            _container = dependencyInitializer.Build();
        }
    }
}
