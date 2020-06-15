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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAMS.Applications.WorkOrder
{
    /// <summary>
    /// Interaction logic for WorkOrderListView.xaml
    /// </summary>
    public partial class WorkOrderListView : UserControl
    {
        MainWindow MainWindow;

        public WorkOrderListView(MainWindow mainWindow)
        {
            InitializeComponent();

            MainWindow = mainWindow;
        }

        private void WorkOrderCreateCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void WorkOrderCreateCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow.ModelViewTabComponents.Add(new ModelViewItem()
            {
                Content = new GAMS.Applications.WorkOrder.WorkOrderSingleView(MainWindow, -1),
                HeaderIcon = "/SharedImages/WorkOrderNew-40x40.png",
                Header = "New WO"
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            stb_SearchLogistics.Focus();
        }
    }
}
