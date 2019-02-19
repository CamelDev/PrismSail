using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using PrismSail.Views;

namespace PrismSail.Core
{
    class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<AppShell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window) this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog) this.ModuleCatalog;
            // moduleCatalog.AddModule(x);
            // moduleCatalog.AddModule(y);
            // moduleCatalog.AddModule(z);
        }

        protected override void ConfigureContainer()
        {
            // Container.RegisterInstance<>();
            base.ConfigureContainer();
        }
    }
}