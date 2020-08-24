﻿using Autofac;
using ReactiveUI;
using SampleEcommerce.Mobile.Abstractions;
using SampleEcommerce.Mobile.Helper;
using SampleEcommerce.Mobile.Services;
using SampleEcommerce.Mobile.ViewModels;
using SampleEcommerce.Mobile.Views;

namespace SampleEcommerce.Mobile
{
    public abstract class DependencyInitializerCore
    {
        public static IContainer Container { get; private set; }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<LoginPage>().As<IViewFor<LoginViewModel>>();
            builder.RegisterType<HomeViewModel>().AsSelf();
            builder.RegisterType<HomePage>().As<IViewFor<HomeViewModel>>();

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
