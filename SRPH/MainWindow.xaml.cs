using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;

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
        private void btn_ShowAllReservation_Click(object sender, RoutedEventArgs e)
        {
            var result = GUI2DB.GUI2DB.GetReservations();
            DG_ShowData.ItemsSource = result;
            DG_ShowData.Columns[0].Visibility = Visibility.Hidden;
            DG_ShowData.Columns[1].Visibility = Visibility.Hidden;
            DG_ShowData.Columns[4].Visibility = Visibility.Hidden;

        }

        private void btn_ShowAllRooms_Click(object sender, RoutedEventArgs e)
        {
            var result = GUI2DB.GUI2DB.GetRooms();
            DG_ShowData.ItemsSource = result;
            DG_ShowData.Columns[0].Visibility = Visibility.Hidden;
            DG_ShowData.Columns[4].Visibility = Visibility.Hidden;


        }

        private void DG_ShowData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string Ids = GetSelectedCellValue();
            if (Ids!=null)
            {
                int index = DG_ShowData.SelectedIndex;
                DG_ShowData.CurrentCell = new System.Windows.Controls.DataGridCellInfo(DG_ShowData.Items[index], DG_ShowData.Columns[0]);
                DG_ShowData.BeginEdit();
                var columnName = DG_ShowData.CurrentColumn.Header.ToString();

                int Id = int.Parse(Ids.ToString());
                if (columnName == "ReservationID")
                {
                    ReservationWindow AddReservation = new ReservationWindow(Id);
                    AddReservation.ShowDialog();
                }
                else if (columnName == "RoomId")
                {
                    RoomWindow AddRoom = new RoomWindow(Id);
                    AddRoom.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Nie klikaæ po pustym Grid");
            }
            
        }
        public string GetSelectedCellValue()
        {
            try
            {
                DataGridCellInfo cellInfo = DG_ShowData.SelectedCells[0];
                if (cellInfo == null) return null;

                DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
                if (column == null) return null;

                FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
                BindingOperations.SetBinding(element, TagProperty, column.Binding);

                return element.Tag.ToString();
            }
            catch (System.Exception)
            {
                return null;
            }

        }

        private void image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Klik³eœ");
        }
    }
}
