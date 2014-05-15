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
    /// Interaction logic for ReservationSummary.xaml
    /// </summary>
    public partial class ReservationSummary : Window
    {
        private List<Reservation> reservations;

        SamenSterker_ServiceClient myClient = new SamenSterker_ServiceClient();

        public ReservationSummary()
        {
            InitializeComponent();
        }
        
        private void lvReservations_Loaded(object sender, RoutedEventArgs e)
        {
            reservations = myClient.GetAllReservations();

            lvReservations.ItemsSource = reservations;
        }
    }
}
