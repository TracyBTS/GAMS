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

namespace GAMS.Applications.WorkOrder.WorkOrderComponents
{
    /// <summary>
    /// Interaction logic for WorkOrderAudit.xaml
    /// </summary>
    public partial class WorkOrderAudit : Window
    {
        public WorkOrderAudit(int WorkOrderNumber)
        {
            InitializeComponent();

            Closing += WorkOrderAudit_Closing;
        }

        private void WorkOrderAudit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
