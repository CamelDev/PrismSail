using Prism.Modularity;
using Prism.Regions;
using PrismSail.CityDetailsModule.Views;
using PrismSailCommon;

namespace PrismSail.CityDetailsModule
{
    public class CityDetailsModule:IModule
    {
        private readonly IRegionManager _regionManager;

        public CityDetailsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(Regions.CityDetailsRegion, typeof(CityDetailsView));
        }

    }
}
