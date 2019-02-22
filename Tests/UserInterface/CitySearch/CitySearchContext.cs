using System;
using System.IO;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using UserInterface.Modules;
using UserInterface.Modules.ObjectIds;

namespace UserInterface.CitySearch
{
    public class CitySearchContext : specification
    {
        protected Application Application;
        protected CityDetails CityDetailsModule;
        protected Map MapModule;

        protected SailSearch SailSearchModule;
        protected Window Window;


        protected override void EstablishContext()
        {
            base.EstablishContext();

            const string applicationDirectory = @"C:\dev\PrismSail\PrismSail\bin\Debug";
            var applicationPath = Path.Combine(applicationDirectory, "PrismSail.exe");
            Application = Application.Launch(applicationPath);

            if (Application == null)
                throw new ApplicationException("Application can't be null!");

            Window = Application.GetWindow("DEMO WPF + Prism", InitializeOption.NoCache);

            if (Window == null)
                throw new ApplicationException("Window can't be null!");

            InitializeComponents();
        }

        protected override void TearDown()
        {
            Application.Dispose();
        }

        private void InitializeComponents()
        {
            SailSearchModule = new SailSearch
            {
                SearchButton = Window.Get<Button>(SearchCriteria.ByAutomationId(SailSearchIds.SearchButtonId)),
                CitySearchLabel = Window.Get<Label>(SearchCriteria.ByAutomationId(SailSearchIds.CitySearchLabelId)),
                CitySearchTextBox = Window.Get<TextBox>(SearchCriteria.ByAutomationId(SailSearchIds.CitySearchTextBoxId))
            };

            CityDetailsModule = new CityDetails
            {
                CityNameLabel = Window.Get<Label>(SearchCriteria.ByAutomationId(CityDetailsIds.CityNameLabelId)),
                CityNameLatLabel = Window.Get<Label>(SearchCriteria.ByAutomationId(CityDetailsIds.CityNameLatLabelId)),
                CityNameLongLabel = Window.Get<Label>(SearchCriteria.ByAutomationId(CityDetailsIds.CityNameLongLabelId)),
                CityPropertiesGrid = Window.Get<ListView>(SearchCriteria.ByAutomationId(CityDetailsIds.CityPropertiesGridId))
            };
        }
    }
}