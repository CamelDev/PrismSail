﻿using Prism.Modularity;
using Prism.Regions;
using PrismSail.SearchModule.Views;
using PrismSailCommon;

namespace PrismSail.SearchModule
{
    public class SailSearchModule:IModule
    {
        private readonly IRegionManager _regionManager;

        public SailSearchModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(Regions.CitySearchRegion, typeof(CitySearchView));
        }
    }
}
