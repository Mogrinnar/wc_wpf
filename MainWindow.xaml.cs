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

namespace WoundsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CollectionViewSource listingDataView;

        // main app reference
        App _app;

        public MainWindow(App app)
        {
            InitializeComponent();
            listingDataView = (CollectionViewSource)(this.Resources["listingDataView"]);
            _app = app;
        }

        private void NewCalculation_Click(object sender, RoutedEventArgs e)
        {
            _app.Calculations.Add(new Calculation());
        }
    }
}
