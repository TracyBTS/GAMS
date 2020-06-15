using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using GAMS.Models;
using GAMS.ViewModel;
using Telerik.Windows.Controls;

namespace GAMS.Applications.Logistics
{
    /// <summary>
    /// Interaction logic for Logistics.xaml
    /// </summary>
    public partial class Logistics : UserControl
    {
        MainWindow MainWindow;

        GAMS.ShareControls.ReportWindow reportWindow;
        GAMS.Applications.Logistics.LogisticsComponents.DeliveryAdviceQuickReceipt receiptWindow;
        private LogisticsViewModel _context;
        private BNAEntities BNADB;

        public Logistics(MainWindow mainWindow)
        {  
           
            InitializeComponent();
            MainWindow = mainWindow;
          

            stb_SearchLogistics.SectionsList = new List<string>() { "Delivery Number", "Part Number", "Work Order Number", "Part Description", "Purchase Order" };
            stb_SearchLogistics.SectionsStyle = UIControls.SearchTextBox.SectionsStyles.CheckBoxStyle;
            stb_SearchLogistics.OnSearch += Stb_SearchLogistics_OnSearch;

            rdp_DateFrom.SelectedDate = DateTime.Today.AddDays(-3);
            rdp_DateTo.SelectedDate = DateTime.Now;

            rgv_MainItems.SelectionChanged += Rgv_MainItems_SelectionChanged;

            _context = this.DataContext as LogisticsViewModel;
            _context.MainWindow = MainWindow;
            _context.Logistics = this;
        }

        private void Rgv_MainItems_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            UpdateReportWindow();
        }

        private void Stb_SearchLogistics_OnSearch(object sender, RoutedEventArgs e)
        {
            MainWindow.LocalDatabase.setLocalDatabase_UserTrackedInterests("marshallhp", "LogisticsSearch", stb_SearchLogistics.Text, false);

            UIControls.SearchEventArgs SearchEventArgs = e as UIControls.SearchEventArgs;

            string sections = "\r\nSections(s): ";
            foreach (string section in SearchEventArgs.Sections)
                sections += (section + "; ");

            //send SearchEventArgs.Keyword (text) with the [sections] to build the search function
        }

        private void OpenDeliveryAdviceItem(int deliveryAdviceNumber)
        {
            MainWindow.RadTabbedWindow_CreateNewTab(new DeliveryAdviceSingleView(this, deliveryAdviceNumber), "DA: " + deliveryAdviceNumber.ToString());
        }

        private void btn_ShowReportWindow_Click(object sender, RoutedEventArgs e)
        {
            if (reportWindow == null)
            {
                reportWindow = new ShareControls.ReportWindow(this);
            }

            reportWindow.Show();
            UpdateReportWindow();
        }

        void UpdateReportWindow()
        {
            if (reportWindow != null && rgv_MainItems.SelectedItem != null)
            {
                var target_DeliveryAdvice = rgv_MainItems.SelectedItem as Item_DeliveryAdvice;
                reportWindow.LoadReport(target_DeliveryAdvice.DeliveryAdviceID.ToString(), "Delivery Advice: " + target_DeliveryAdvice.DeliveryAdviceID.ToString());
            }
        }

      

        private void DeliveryAdviceCreateCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeliveryAdviceCreateCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow.ModelViewTabComponents.Add(new ModelViewItem()
            {
                Content = new GAMS.Applications.Logistics.DeliveryAdviceSingleView(this, -1),
                HeaderIcon = "/SharedImages/LogisticsNew-40x40.png",
                Header = "New DA"
            });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            stb_SearchLogistics.Focus();
        }

        private void LogisticsReceiveCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void LogisticsReceiveCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (receiptWindow == null)
            {
                receiptWindow = new LogisticsComponents.DeliveryAdviceQuickReceipt();
            }

            receiptWindow.Show();
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            _context.LoadData((rcb_DAListType.SelectedItem as RadComboBoxItem).Content.ToString(), null);
          
        }

        private void rb_LoadDeliveryAdvice_Click(object sender, RoutedEventArgs e)
        {
           this.rgv_MainItems.SelectedItem  = (sender as RadButton).DataContext as GAMS.Models.DeliveryAdvice_Shipping ;

         
            Binding commandBinding = new Binding(); //create a command 
            commandBinding.Path = new PropertyPath("ViewDACommand");
            (sender as RadButton).SetBinding(RadButton.CommandProperty, commandBinding);

            //(this.DataContext as LogisticsViewModel).ViewDAWindow();
        }

        private void btn_CreateNewDA_Click(object sender, RoutedEventArgs e)
        {
            RadButton _btn = (sender as RadButton);
        }
    }
}
