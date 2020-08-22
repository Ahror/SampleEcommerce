using Autofac;
using SampleEcommerce.Moblie.Abstractions;
using SampleEcommerce.Moblie.Helper;
using SampleEcommerce.Moblie.Services;

namespace SampleEcommerce.Moblie
{
    public abstract class DependencyInitializerCore
    {
        public static IContainer Container { get; private set; }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AppSettings>().As<IAppSettings>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

            RegisterTypes(builder);
            return Container = builder.Build();
        }

        protected abstract void RegisterTypes(ContainerBuilder builder);
    }

}
