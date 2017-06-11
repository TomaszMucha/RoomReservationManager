using GUI2DB;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SRPH
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_AddRoom_Click(object sender, RoutedEventArgs e)
        {

            RoomWindow AddRoom = new RoomWindow();
            AddRoom.ShowDialog();
        }

        private void btn_AddReservation_Click(object sender, RoutedEventArgs e)
        {
            ReservationWindow AddReservation = new ReservationWindow();
            AddReservation.ShowDialog();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Reservation_Click(object sender, RoutedEventArgs e)
        {
            ReservationWindow AddReservation = new ReservationWindow(0);
            AddReservation.ShowDialog();
        }

        private void btn_ShowAllReservation_Click(object sender, RoutedEventArgs e)
        {
           //Class1.ro
        }
    }
}
