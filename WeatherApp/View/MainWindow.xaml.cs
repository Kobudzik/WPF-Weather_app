using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;
using WeatherApp.ViewModel;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml- VIEW
    /// </summary>
    public partial class MainWindow : Window
    {
        //creates new view model object(which creates new model)
        private readonly WeatherViewModel _viewModel = new WeatherViewModel();

        public MainWindow()
        {
            InitializeComponent();
            //sets data context for view to interact with viewModel
            DataContext = _viewModel;

        }
        



        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Reset();
            _viewModel.SetCity( CityTextBox.Text);
            _viewModel.SetDays(DaysTextBox.Text);

            _viewModel.CreateHTTPRequestURL();
            _viewModel.GetXMLData();
            _viewModel.PopulateDayWeatherList();
            _viewModel.GetReturnedLocation();
            lvDataBinding.ItemsSource = _viewModel.daysObservableCollection;






        }

        /// <summary>
        /// Only lets user enter numbers using Regex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }        
    }
}
