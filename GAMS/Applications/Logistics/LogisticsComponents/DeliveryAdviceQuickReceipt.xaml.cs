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
    /// Interaction logic for DeliveryAdviceQuickReceipt.xaml
    /// </summary>
    public partial class DeliveryAdviceQuickReceipt : Window
    {
        public DeliveryAdviceQuickReceipt()
        {
            InitializeComponent();

            this.Closing += DeliveryAdviceQuickReceipt_Closing;
        }

        private void DeliveryAdviceQuickReceipt_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
