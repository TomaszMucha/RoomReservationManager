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
using SRPH.Helper;
using GUI2DB;

namespace SRPH
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    /// 
    public struct DataRooms
    {
        public DataRooms(int intValue, string strValue)
        {
            RoomNumber = intValue;
            TypeOfBeds = strValue;
        }

        public int RoomNumber { get; private set; }
        public string TypeOfBeds { get; private set; }
    }

    public partial class ReservationWindow : Window
    {
        public bool compatibilityForm { get; set; }
        public ReservationWindow(int Number)
        {
            InitializeComponent();
            var Reservation = GUI2DB.GUI2DB.GetReservation(Number);
            FilWindow(Reservation);

            //wywowałąc metoda ładującą dane z bazy danych
        }

        public ReservationWindow()
        {
            InitializeComponent();

        }
        void FilWindow(SRPH_DataBase.Reservation Reservation)
        {
            TB_Name.Text = Reservation.Name;
            TB_SurName.Text = Reservation.Surename;
            TB_Pesel.Text = Reservation.PESEL;
            TB_PhoneNumber.Text = Reservation.PhoneNumber.ToString();
            DP_DateFrom.SelectedDate = Reservation.ReservationDataFrom;
            DP_DateTo.SelectedDate = Reservation.ReservationDataTo;

        }
        DateTime DatePickerFrom()
        {
            DateTime DateFrom = new DateTime();
            DateTime? Date = DP_DateFrom.SelectedDate;
            if (Date == null)
            {
                compatibilityForm = false;
                MessageBox.Show("Podaj datę od");
            }
            else
            {
                DateFrom = Date.Value.Date;
            }
            return DateFrom;
        }
        DateTime DatePickerTo()
        {
            DateTime DateTo = new DateTime();
            DateTime? Date = DP_DateTo.SelectedDate;
            if (Date == null)
            {
                compatibilityForm = false;
                MessageBox.Show("Podaj datę do");
            }
            else
            {
                DateTo = Date.Value.Date;
            }
            return DateTo;
        }
        string GetName()
        {
            string Name = TB_Name.Text;
            if (Name == string.Empty)
            {
                compatibilityForm = false;
                MessageBox.Show("Popraw Imię");

            }

            return Name;
        }
        string GetSurName()
        {
            string SurName = TB_SurName.Text;
            if (SurName == string.Empty)
            {
                compatibilityForm = false;
                MessageBox.Show("Popraw Nazwisko");

            }

            return SurName;
        }
        string GetPesel()
        {
            string Pesel = TB_Pesel.Text;
            bool ret = Validate.ValidatePesel(ref Pesel);
            if (Pesel == string.Empty || ret == false)
            {
                compatibilityForm = false;
                MessageBox.Show("Popraw numer PESEL");
            }

            return Pesel;
        }
        int GetPhoneNumber()
        {
            int PhoneNumber;
            bool result = Int32.TryParse(TB_PhoneNumber.Text, out PhoneNumber);
            if (PhoneNumber == 0 || result == false)
            {
                compatibilityForm = false;
                MessageBox.Show("Popraw numer telefonu");

            }

            return PhoneNumber;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            compatibilityForm = true;
            int IdRoom = 2;
            int IdClient = 2;
            List<string> RoomStandard = new List<string>();
            DateTime DataOd = DatePickerFrom();
            DateTime DataDo = DatePickerTo();
            if (DataOd > DataDo)
            {
                compatibilityForm = false;
                MessageBox.Show("Popraw zakres dat");

            }
            string Imie = GetName();
            string Nazwisko = GetSurName();
            string Pesel = GetPesel();
            int Telefon = GetPhoneNumber();
            if (compatibilityForm == true)
            {
                //TODO zapis do bazy
                GUI2DB.GUI2DB.CreateReservation(IdRoom, IdClient, DataOd, DataDo, RoomStandard, Imie, Nazwisko, Pesel, Telefon);
                MessageBox.Show("Zapisano!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Popraw bo z dupy masz te dane!");
            }
            //TODO sprawdzenie poprawnosci i zapis do bazy
        }
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            var test = GUI2DB.GUI2DB.GetFreeRooms();
            var listFreeRooms = new List<DataRooms>();

            foreach (var item in test)
            {
                listFreeRooms.Add(new DataRooms(item.RoomNumber.Value, item.TypeOfBeds));
            }
            foreach (var item in test)
            {
                CB_FreeRooms.Items.Add(item.RoomNumber);
            }
        }

        private void CB_FreeRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = CB_FreeRooms.SelectedIndex;
            int room = 0;
            var test = GUI2DB.GUI2DB.GetFreeRooms();
            for (int i = 0; i < index; i++)
            {
                room = test[i].RoomNumber.Value;
            }
            TB_RoomNumber.Text = room.ToString();
        }

    }
}
