using Db4objects.Db4o;
using GUI2DB;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using SRPH_DataBase;
using System.Drawing;
using System.Collections.Generic;

namespace SRPH
{
    /// <summary>
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        public int RoomId { get; set; }
        public bool compatibilityForm { get; set; }
        public RoomWindow()
        {
            InitializeComponent();
        }
        public RoomWindow(int roomId)
        {
            RoomId = roomId;
            InitializeComponent();
            var Room = GUI2DB.GUI2DB.GetRoom(RoomId);
            FilWindow(Room);
            //wywowałac metoda ładującą dane z bazy danych

        }

        void FilWindow(SRPH_DataBase.Rooms Room)
        {
            TB_Number.Text = Room.RoomNumber.ToString(); ;
            TB_NumberOfPerson.Text = Room.NumberOfPersons.ToString();
            TB_TypesOfBeds.Text = Room.TypeOfBeds;
        }


        int GetRoomNumber()
        {
            int RoomNumber ;
            bool result = Int32.TryParse(TB_Number.Text, out RoomNumber);

            if (RoomNumber == 0 || result == false)
            {
                compatibilityForm = false;
                TB_Number.Foreground = System.Windows.Media.Brushes.Red;
                MessageBox.Show("Popraw numej pokoju");
            }

            return RoomNumber;
        }
        int GetPersonNumber()
        {
            int PersonNumber;
            bool result = Int32.TryParse(TB_NumberOfPerson.Text, out PersonNumber);

            if (PersonNumber == 0 || result == false)
            {
                compatibilityForm = false;
                TB_NumberOfPerson.Foreground = System.Windows.Media.Brushes.Red;
                MessageBox.Show("Popraw ilość osób");
            }

            return PersonNumber;
        }
        string GetTypeBeds()
        {
            string TypeBeds = TB_TypesOfBeds.Text;
            if (TypeBeds == string.Empty)
            {
                compatibilityForm = false;
                TB_TypesOfBeds.Foreground = System.Windows.Media.Brushes.Red;
                MessageBox.Show("Popraw typ łóżek");
            }

            return TypeBeds;
        }


        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //TODO sprawdzenie poprawnosci i zapis do bazy
            compatibilityForm = true;
            int NumerPokoju = GetRoomNumber();
            int IlośćOsób = GetPersonNumber();
            string TypŁóżek = GetTypeBeds();
            if (compatibilityForm == true)
            {
                //TODO zapis do bazy

                GUI2DB.GUI2DB.AddRooms(GUI2DB.GUI2DB.GetRoomId(), NumerPokoju, IlośćOsób, TypŁóżek);
                MessageBox.Show("Zapisano!");
                this.Close();

            }
            else
            {
                //ten kod wywoła się jeśli jedna z danych nie jest zgodna
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Usunąć pokój?","Question",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.No)
            {

            }
            else
            {
                GUI2DB.GUI2DB.DeleteReservation(RoomId);
                this.Close();
            }

        }
    }
}
