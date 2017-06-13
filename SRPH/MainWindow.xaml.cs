using System.Windows;
using System.Drawing;

namespace SRPH
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    /// 
   

    public partial class MainWindow : Window
    {
        public object BackgroundImage { get; private set; }

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
        private void btn_Rooms_Click(object sender, RoutedEventArgs e)
        {
            RoomWindow AddRoom = new RoomWindow(2);
            AddRoom.ShowDialog();
        }
        private void btn_ShowAllReservation_Click(object sender, RoutedEventArgs e)
        {
            var result = GUI2DB.GUI2DB.GetReservations();
            DG_ShowData.ItemsSource = result;
            DG_ShowData.Columns[0].Visibility = Visibility.Hidden;
            DG_ShowData.Columns[4].Visibility = Visibility.Hidden;

        }

        private void btn_ShowAllRooms_Click(object sender, RoutedEventArgs e)
        {
            var result = GUI2DB.GUI2DB.GetRooms();
            DG_ShowData.ItemsSource = result;
            DG_ShowData.Columns[4].Visibility = Visibility.Hidden;


        }
    }
}
