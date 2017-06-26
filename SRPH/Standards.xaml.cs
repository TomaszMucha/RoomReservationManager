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
        public List<BoolStringClass> ReturnList = new List<BoolStringClass>();

        public Standards(bool IsPernamentType)
        {
            InitializeComponent();
            CreateCheckBoxList(IsPernamentType);

        }

        public void CreateCheckBoxList(bool Pernament)
        {
            TheList = new ObservableCollection<BoolStringClass>();
            var List = new List<BoolStringClass>();

            if (Pernament == true)
            {
                List = GUI2DB.GUI2DB.GetPermanentStandard();
            }
            else
            {
                List = GUI2DB.GUI2DB.GetNotPermanentStandard();
            }
            foreach (var item in List)
            {
                TheList.Add(item);
            }

            this.DataContext = this;
        }

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            //var item = new BoolStringClass(chkZone.Content.ToString(), int.Parse(chkZone.Tag.ToString()), false);
            //ReturnList.Add(item);
            ZoneText.Text = "Selected Zone Name= " + chkZone.Content.ToString();
            ZoneValue.Text = "Selected Zone Value= " + chkZone.Tag.ToString();
        }


        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //GUI2DB.GUI2DB.SaveStandards(ReturnList);
        }
    }

}

