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
    public partial class Standards : Window
    {
        public ObservableCollection<BoolStringClass> TheList { get; set; }

        public Standards()
        {
            InitializeComponent();
            CreateCheckBoxList();
        }

        public void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            var List = GUI2DB.GUI2DB.ReceiveStandardList();
            foreach (var item in List)
            {
                TheList.Add(item);
            }

            this.DataContext = this;
        }

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            foreach (var item in TheList)
            {
                if (item.TheText == chkZone.Content.ToString())
                {
                    MessageBox.Show(item.TheText.ToString());
                }
            }
            ZoneText.Text = "Selected Zone Name= " + chkZone.Content.ToString();
            ZoneValue.Text = "Selected Zone Value= " + chkZone.Tag.ToString();
        }
    }

}
  
