using Db4objects.Db4o;
using GUI2DB;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using SRPH_DataBase;

namespace SRPH
{
    /// <summary>
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        public bool compatibilityForm { get; set; }
        public RoomWindow()
        {
            InitializeComponent();
        }
        public RoomWindow(int Roomid)
        {
            InitializeComponent();
            GUI2DB.BUI2DB.GetRoom(Roomid);
            //wywowałac metoda ładującą dane z bazy danych

        }
        int GetRoomNumber()
        {
            int RoomNumber ;
            bool result = Int32.TryParse(TB_Number.Text, out RoomNumber);

            if (RoomNumber == 0 || result == false)
            {
                compatibilityForm = false;
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
            }

            return PersonNumber;
        }
        string GetTypeBeds()
        {
            string TypeBeds = TB_TypesOfBeds.Text;
            if (TypeBeds == string.Empty)
            {
                compatibilityForm = false;
            }

            return TypeBeds;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //TODO sprawdzenie poprawnosci i zapis do bazy
            compatibilityForm = true;
            int RoomID = 1;
            int NumerPokoju = GetRoomNumber();
            int IlośćOsób = GetPersonNumber();
            string TypŁóżek = GetTypeBeds();
            if (compatibilityForm == true)
            {
                //TODO zapis do bazy
                MessageBox.Show("Zapisano!");
                GUI2DB.BUI2DB.AddRooms(GUI2DB.BUI2DB.GetRoomId(), NumerPokoju, IlośćOsób, TypŁóżek);
            }
            else
            {
                MessageBox.Show("Popraw bo z dupy masz te dane!");
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
