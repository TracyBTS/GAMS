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
using GAMS.Applications.Logistics;

namespace GAMS.Applications.Logistics
{
    /// <summary>
    /// Interaction logic for Logistics.xaml
    /// </summary>
    public partial class Logistics : UserControl
    {
       readonly MainWindow   MainWindow;

      
        
        private readonly LogisticsViewModel _context;
        
        public List<string> SearchCbxOption;



        public Logistics(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;

            SearchCbxOption = new List<string>();
            SearchCbxOption.Add("Created");
            SearchCbxOption.Add("Received");
            rcb_DAListType.ItemsSource = SearchCbxOption;
            rcb_DAListType.SelectedIndex = 0;

         
           // stb_SearchLogistics.SectionsList = new List<string>() { "Delivery Number", "Part Number", "Work Order Number", "Part Description", "Purchase Order" };
            stb_SearchLogistics.SectionsStyle = UIControls.SearchTextBox.SectionsStyles.CheckBoxStyle;
            stb_SearchLogistics.OnSearch += Stb_SearchLogistics_OnSearch;


            rdp_DateFrom.SelectedDate = DateTime.Today.AddDays(-3);
            rdp_DateTo.SelectedDate = DateTime.Now;



            rgv_MainItems.SelectionChanged += Rgv_MainItems_SelectionChanged;

           
        }

        private void Rgv_MainItems_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
           // UpdateReportWindow();
        }

        private void Stb_SearchLogistics_OnSearch(object sender, RoutedEventArgs e)
        {
            //MainWindow.LocalDatabase.setLocalDatabase_UserTrackedInterests("marshallhp", "LogisticsSearch", stb_SearchLogistics.Text, false);

            //UIControls.SearchEventArgs SearchEventArgs = e as UIControls.SearchEventArgs;

            //string sections = "\r\nSections(s): ";
            //foreach (string section in SearchEventArgs.Sections)
            //    sections += (section + "; ");

            ////send SearchEventArgs.Keyword (text) with the [sections] to build the search function
            ///
            if (this.DataContext != null && (this.DataContext as LogisticsViewModel) != null)
            {
                if ((this.DataContext as LogisticsViewModel).FindDA(stb_SearchLogistics.Text) == false)
                    MessageBox.Show("it is not a existing DA Number");
                else
                    OpenNewWindow(stb_SearchLogistics.Text);
            }
        }

      
        private void btn_ShowReportWindow_Click(object sender, RoutedEventArgs e)
        {
            var target_DeliveryAdvice = rgv_MainItems.SelectedItem as C_DeliveryAdvice;

            if (target_DeliveryAdvice!= null)
                wb_ReportView.Source = new Uri("http://bna.health.qld.gov.au/WebForm/WebForm_DAforExternal.aspx?id=" + target_DeliveryAdvice.DeliveryAdviceNumber.ToString());

            return;

        }

       
      

        private void DeliveryAdviceCreateCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeliveryAdviceCreateCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //MainWindow.ModelViewTabComponents.Add(new ModelViewItem()
            //{
            //    Content = new GAMS.Applications.Logistics.DeliveryAdviceSingleView(null,),
            //    HeaderIcon = "/SharedImages/LogisticsNew-40x40.png",
            //    Header = "New DA"
            //});
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            stb_SearchLogistics.Focus();
        }

        private void LogisticsReceiveCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
            GAMS.Applications.Logistics.LogisticsComponents.Window_Courier _newWindow = new Applications.Logistics.LogisticsComponents.Window_Courier(this.MainWindow );
            _newWindow.Show();

          
        }

        private void btn_EditDA_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as LogisticsViewModel).SelectedDeliveryAdvice != null)
                OpenNewWindow((this.DataContext as LogisticsViewModel).SelectedDeliveryAdvice.DeliveryAdviceNumber.ToString ());
            else
                MessageBox.Show("Please select the Delivery Advice.");
        }

        private void OpenNewWindow(string key )
        {

                if (MainWindow.ModelViewTabComponents.IsExisting("DA:" + key) == false)
                {
                    MainWindow.ModelViewTabComponents.Add(new ModelViewItem()
                    {
                        Content = new GAMS.Applications.Logistics.DeliveryAdviceSingleView((this.DataContext as LogisticsViewModel).SelectedDeliveryAdvice, null, MainWindow),
                        HeaderIcon = "pack://application:,,,/GAMS;component/SharedImages/LogisticsNew-40x40.png",
                        Header = "DA:" + (this.DataContext as LogisticsViewModel).SelectedDeliveryAdvice.DeliveryAdviceNumber.ToString(),
                        UserControlCatagoryApplicationType = UserControlApplicationsCatagoryType.Logistic
                    });
                }

           
           
        }
    }
}
