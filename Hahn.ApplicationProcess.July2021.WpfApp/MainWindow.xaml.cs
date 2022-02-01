using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Application;

namespace Hahn.ApplicationProcess.July2021.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAssetService _assetService;
        public MainWindow(IAssetService assetService)
        {
            _assetService = assetService;
            InitializeComponent();
        }

        public async Task<List<AssetDto>> GetAll()
        {
            var assets = await _assetService.GetAll();
            return assets;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var assets = await _assetService.GetAll();
            EmployeeDG.ItemsSource = assets;
        }
    }
}
