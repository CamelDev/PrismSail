using Prism.Modularity;
using Prism.Regions;
using PrismSail.MapModule.Views;
using PrismSailCommon;

namespace PrismSail.MapModule
{
    public class MapModule:IModule
    {
        private readonly IRegionManager _regionManager;

        public MapModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(Regions.MapRegion, typeof(MapView));
        }


        // another change
    }
}
