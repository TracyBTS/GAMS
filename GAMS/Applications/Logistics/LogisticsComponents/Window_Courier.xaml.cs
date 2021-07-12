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

namespace GAMS.Applications.Logistics.LogisticsComponents
{
    /// <summary>
    /// Interaction logic for Window_Courier.xaml
    /// </summary>
    public partial class Window_Courier : Window
    {
        MainWindow Main;
        public Window_Courier(MainWindow _main)
        {
            InitializeComponent();
            Main = _main;
            lsbx_Reason.SelectedItem = null;


        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (lsbx_Reason.SelectedItem == null)
            {
                MessageBox.Show ("Select the delivery reason first.");
                return;
            }
            Main.ModelViewTabComponents.Add(new ModelViewItem()
            {
                Content = new GAMS.Applications.Logistics.DeliveryAdviceSingleView( null, (lsbx_Reason.SelectedItem as ListBoxItem).Content.ToString (), Main),
                HeaderIcon = "pack://application:,,,/GAMS;component/SharedImages/LogisticsNew-40x40.png",
                Header = "New DA",
                UserControlCatagoryApplicationType = UserControlApplicationsCatagoryType.Logistic
            });

            this.Close();

            
        }
    }
}
