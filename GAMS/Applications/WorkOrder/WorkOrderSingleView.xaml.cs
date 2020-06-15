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
    /// Interaction logic for WorkOrderSingleView.xaml
    /// </summary>
    public partial class WorkOrderSingleView : UserControl
    {
        MainWindow MainWindow;
        WorkOrderComponents.WorkOrderAudit WorkOrderAuditWindow;

        public WorkOrderSingleView(MainWindow mainWindow, int WorkOrderNumber)
        {
            InitializeComponent();

            MainWindow = mainWindow;
        }

        private void cmbbx_WOPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Preference_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ShowReportWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmailUnitCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EmailUnitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void PrintUnitCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PrintUnitCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveAsCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveAsCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveCloseCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCloseCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SavePrintCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SavePrintCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void AdvancedViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AdvancedViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ShowAuditWindowCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ShowAuditWindowCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (WorkOrderAuditWindow == null)
            {
                WorkOrderAuditWindow = new WorkOrderComponents.WorkOrderAudit(-1);
            }

            WorkOrderAuditWindow.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
