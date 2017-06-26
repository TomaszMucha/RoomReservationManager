using SRPH_DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public ObservableCollection<BoolStringClass> Rows { get; set; }

        List<BoolStringClass> TheList = new List<BoolStringClass>();

        public Settings()
        {
            InitializeComponent();
            Rows = new ObservableCollection<BoolStringClass>();

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            int price;
            if (int.TryParse(txt_Price.Text, out price) == true && string.IsNullOrEmpty(txt_Name.Text) != true)
            {
                TheList.Add(new BoolStringClass { StandardName = txt_Name.Text, StandardPrice = price, IsPermamentOrIsNotPermament = true });
            }
            else
            {
                MessageBox.Show("Podane wartości sa błędne");
            }
            if (LV_Standards.Items.Count != 0)
            {
                LV_Standards.Items.Clear();
            }
            foreach (var item in TheList)
            {
                this.LV_Standards.Items.Add(item);

            }

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            GUI2DB.GUI2DB.StoreStandardList(TheList);
            TheList.Clear();
            MessageBox.Show("Zapisano");
        }

        private void btn_Add2_Click(object sender, RoutedEventArgs e)
        {
            int price;
            if (int.TryParse(txt_Price2.Text, out price) == true && string.IsNullOrEmpty(txt_Name2.Text) != true)
            {
                TheList.Add(new BoolStringClass { StandardName = txt_Name2.Text, StandardPrice = price, IsPermamentOrIsNotPermament = false });
            }
            else
            {
                MessageBox.Show("Podane wartości sa błędne");
            }
            if (LV_Standards2.Items.Count!=0)
            {
                LV_Standards2.Items.Clear();
            }
            foreach (var item in TheList)
            {
                this.LV_Standards2.Items.Add(item);

            }

        }
    }
}
