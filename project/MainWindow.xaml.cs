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

namespace project
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EarthquakeViewModel();
        }

        private void ChronologyClick(object sender, RoutedEventArgs e)
        {
            //List<EarthquakeInfo> info = new List<EarthquakeInfo>
            //{

            //    new EarthquakeInfo
            //    {
            //        Id=1,Country="Казахстан",Scale=3,/*EarthquakeDate*/
            //    }
            //};




            //http://brianlagunas.com/build-an-earthquake-application-with-bing-maps-wpf-control-beta/
        }
    }
}
