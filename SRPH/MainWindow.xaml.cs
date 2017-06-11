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
<<<<<<< HEAD
            var test =GUI2DB.BUI2DB.GetReservations();
            //var results = new List<MyCustomClass>();
            //results.Add(new MyCustomClass() { ObjectID = 1, Name = "Nazwa 1", Description = "Description 1" });
            //results.Add(new MyCustomClass() { ObjectID = 2, Name = "Nazwa 2", Description = "Description 2" });
            //results.Add(new MyCustomClass() { ObjectID = 3, Name = "Nazwa 3", Description = "Description 3" });
            DG_ShowData.ItemsSource = test;
=======
            var result = Class1.GetReservations();
            DG_ShowData.ItemsSource = result;
        }

        private void btn_ShowAllRooms_Click(object sender, RoutedEventArgs e)
        {
            var result = Class1.GetRooms();
            DG_ShowData.ItemsSource = result;
>>>>>>> dadc877d45b4b9a838c29722f8f5121ad22d810b
        }
    }
}
