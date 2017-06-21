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
        public ObservableCollection<BoolStringClass> TheList { get; set; }

        public Settings()
        {
            InitializeComponent();
            CreateCheckBoxList();
        }
        public class BoolStringClass
        {
            public string TheText { get; set; }
            public int TheValue { get; set; }
        }
        public void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            TheList.Add(new BoolStringClass { TheText = "EAST", TheValue = 1 });
            TheList.Add(new BoolStringClass { TheText = "WEST", TheValue = 2 });
            TheList.Add(new BoolStringClass { TheText = "NORTH", TheValue = 3 });
            TheList.Add(new BoolStringClass { TheText = "SOUTH", TheValue = 4 });
            this.DataContext = this;
        }

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            foreach (var item in TheList)
            {
                if (item.TheText == chkZone.Content.ToString())
                {
                    MessageBox.Show(item.TheValue.ToString());
                }
            }
            ZoneText.Text = "Selected Zone Name= " + chkZone.Content.ToString();
            ZoneValue.Text = "Selected Zone Value= " + chkZone.Tag.ToString();
        }
    }

}

