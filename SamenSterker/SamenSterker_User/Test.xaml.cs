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
using System.Windows.Shapes;
using SamenSterker_User.SamenSterkerServiceReference;

namespace SamenSterker_User
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        private List<Reservation> reservationList;

        SamenSterker_ServiceClient myClient = new SamenSterker_ServiceClient();

        public Test()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource reservationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reservationViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // reservationViewSource.Source = [generic data source]
            reservationList  = myClient.GetAllReservations();
            reservationViewSource.Source = reservationList;
        }
    }
}
