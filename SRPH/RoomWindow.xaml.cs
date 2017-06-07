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
        public RoomWindow(int RoomNumber)
        {
            InitializeComponent();
            //wywowałac metoda ładującą dane z bazy danych

        }
        string GetRoomNumber()
        {
            string RoomNumber = TB_Number.Text;
            if (RoomNumber == string.Empty)
            {
                compatibilityForm = false;
            }

            return RoomNumber;
        }
        string GetPersonNumber()
        {
            string PersonNumber = TB_NumberOfPerson.Text;
            if (PersonNumber == string.Empty)
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
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //TODO sprawdzenie poprawnosci i zapis do bazy
            if (compatibilityForm == true)
            {
                //TODO zapis do bazy
                MessageBox.Show("Zapisano!");
            }
            else
            {
                MessageBox.Show("Popraw bo z dupy masz te dane!");
            }
        }
    }
}
