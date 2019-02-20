using System.Windows;
using Prism.Modularity;

namespace PrismSail.Views
{
    /// <summary>
    /// Interaction logic for AppShell.xaml
    /// </summary>
    public partial class AppShell : Window
    {
        IModuleManager _moduleManager;

        public AppShell(IModuleManager moduleManager)
        {
            InitializeComponent();
            _moduleManager = moduleManager;
        }

        private void MapButton_Click(object sender, RoutedEventArgs e)
        {
            _moduleManager.LoadModule("MapModule");
        }
    }
}
