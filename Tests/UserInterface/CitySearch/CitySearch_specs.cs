using NUnit.Framework;

namespace UserInterface.CitySearch
{
    internal class when_user_search_city : CitySearchContext
    {
        protected override void EstablishContext()
        {
            base.EstablishContext();
            SailSearchModule.CitySearchTextBox.Text = "London";
        }

        protected override void When()
        {
            base.When();
            SailSearchModule.SearchButton.Click();
        }

        [Test]
        public void then_search_label_should_have_content_equal()
        {
            Assert.AreEqual("Your search city: London", SailSearchModule.CitySearchLabel.Text);
        }

        [Test]
        public void then_city_details_should_have_set_correct_values()
        {
            Assert.AreEqual("London", CityDetailsModule.CityNameLabel.Text);
            Assert.AreEqual("51,5073219", CityDetailsModule.CityNameLatLabel.Text);
            Assert.AreEqual("-0,1276474", CityDetailsModule.CityNameLongLabel.Text);

            var cityNameLabelCell = CityDetailsModule.CityPropertiesGrid.Rows[1].Cells[0].Text;
            Assert.AreEqual("Name", cityNameLabelCell);

            var cityNameValueCell = CityDetailsModule.CityPropertiesGrid.Rows[1].Cells[1].Text;
            Assert.AreEqual("London, Greater London, England, SW1A 2DU, UK", cityNameValueCell);
        }
    }
}