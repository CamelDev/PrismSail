using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using PrismSail.MapModule.Views;
using PrismSail.SearchModule;
using PrismSail.Views;
using PrismSailCommon;

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
            
            moduleCatalog.AddModule(typeof(SailSearchModule));
            moduleCatalog.AddModule(typeof(CityDetailsModule.CityDetailsModule));

            var mapModuleType = typeof(MapModule.MapModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = mapModuleType.Name,
                ModuleType = mapModuleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterInstance<ITimeService>(new TimeService());
            Container.RegisterInstance<ICitySearchService>(new CitySearchService());
        }
    }
}