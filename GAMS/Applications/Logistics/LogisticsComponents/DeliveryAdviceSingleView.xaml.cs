using GAMS.Applications.Logistics.LogisticsComponents;
using GAMS.ViewModel;
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

namespace GAMS.Applications.Logistics
{
    /// <summary>
    /// Interaction logic for DeliveryAdvice.xaml
    /// </summary>
    public partial class DeliveryAdviceSingleView : UserControl, IDialogView

    {
        bool ModeEdit = false;

       
        DeliveryAdviceAudit DeliveryAdviceAuditView;
        DeliveryAdviceQuickReceipt _Receivewindow;
        MainWindow MainWindow;
        

        bool? IDialogView.DialogResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Window IDialogView.Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IView.DataContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DeliveryAdviceSingleView(GAMS.Models.C_DeliveryAdvice _da, string _deliveryReason , MainWindow _mainWindow)
        {
            InitializeComponent();
           
           

            cmbbx_DAReason.Items.Add("Credit Return");
            cmbbx_DAReason.Items.Add("Return Faulty/Damaged Goods");
            cmbbx_DAReason.Items.Add("Return Oversupply");
            cmbbx_DAReason.Items.Add("Warranty Repair");
            cmbbx_DAReason.Items.Add("Internal Repair");
            cmbbx_DAReason.Items.Add("BTS2Client");
            cmbbx_DAReason.Items.Add("BTS2BTS");
            cmbbx_DAReason.Items.Add("Quote on Repair/Replacement");          
            cmbbx_DAReason.Items.Add("Imprest Stock Rtn");
            cmbbx_DAReason.Items.Add("External Repair");
            cmbbx_DAReason.Items.Add("Quote Req|Ex Rep");
            cmbbx_DAReason.Items.Add("Retrun Loan Equipment");
            cmbbx_DAReason.Items.Add("PT");
            cmbbx_DAReason.Items.Add("Other");



            this.DataContext = new DAAddEditViewModels(_da, _deliveryReason, _mainWindow._currentUser);
            this.racb_FromAddress.ItemsSource = (this.DataContext as DAAddEditViewModels).DAFromDatasource;
            this.racb_ToAddress.ItemsSource = (this.DataContext as DAAddEditViewModels).DAToDataSource;
            this.racb_FromAddress.DisplayMemberPath = "NAME";
            this.racb_ToAddress.DisplayMemberPath = "NAME";

            MainWindow = _mainWindow;


      




        }


        private void brdr_GoToSpace_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        //private void btn_AddressBook_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AddressBookWindow == null)
        //        AddressBookWindow = new ShareControls.AddressBookWindow(this);

        //    if ((sender as Telerik.Windows.Controls.RadButton) == btn_AddressBookFrom)
        //    {
        //        AddressBookWindow.Load(racb_FromAddress, "Address Book: DA from");
        //        AddressBookWindow.LoadAddressMode(GAMS.ShareControls.AddressTypeMode.Accounts_BTSOnly);
        //    }
        //    else
        //    {
        //        AddressBookWindow.Load(racb_FromAddress, "Address Book: DA to");

        //        //needs fixing against type of devliery advice type it is.
        //        AddressBookWindow.LoadAddressMode(GAMS.ShareControls.AddressTypeMode.Accounts_BTSOnly);
        //    }

        //    AddressBookWindow.Show();
        //}

     

      

        private void btn_D_Add_Click(object sender, RoutedEventArgs e)
        {
            rtgsb_ShowLineItemDetails.IsChecked = true;
        }

        private void btn_D_Edit_Click(object sender, RoutedEventArgs e)
        {
            rtgsb_ShowLineItemDetails.IsChecked = true;
        }

       
        
        private void btn_ShowReportWindow_Click(object sender, RoutedEventArgs e)
        {
            if (txtblk_DispatchNumber.Text == "" ||
                txtblk_DispatchNumber.Text == "-1")
                MessageBox.Show("Delievery Advice number is not a proper number");
            else                           
                wb_ReportView.Source = new Uri("http://bna.health.qld.gov.au/WebForm/WebForm_DAforExternal.aspx?id=" + txtblk_DispatchNumber.Text.Trim ());

            return;
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DAAddEditViewModels).SetMode("Edit");
        }

     

        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Warning_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            (sender as Telerik.Windows.Controls.RadButton).ContextMenu.IsOpen = !(sender as Telerik.Windows.Controls.RadButton).ContextMenu.IsOpen;
        }

        private void btn_Audit_Click(object sender, RoutedEventArgs e)
        {
            if (txtblk_DispatchNumber.Text.Trim().Length == 0 || txtblk_DispatchNumber.Text=="-1")
            {
                MessageBox.Show("Delivery Advice number is not correct.");
                return;
            }

            if (DeliveryAdviceAuditView == null)
            {
                DeliveryAdviceAuditView = new DeliveryAdviceAudit(this);
            }

            DeliveryAdviceAuditView.Show();
        }

        private void rmi_Export_Email(object sender, RoutedEventArgs e)
        {

        }

        private void rmi_Export_PDF(object sender, RoutedEventArgs e)
        {

        }

        private void rmi_Save_Print(object sender, RoutedEventArgs e)
        {

        }

        private void rmi_Save(object sender, RoutedEventArgs e)
        {

        }

        private void rmi_Edit_Receive(object sender, RoutedEventArgs e)
        {

        }

        private void rmi_Edit_Edit(object sender, RoutedEventArgs e)
        {
            ModeEdit = !ModeEdit;

            ((btn_Edit as Telerik.Windows.Controls.RadButton).Content as Image).Source = new BitmapImage(new Uri(ModeEdit ? "/SharedImages/Cancel-40x40.png" : "/SharedImages/Receive-40x40.png", UriKind.Relative));
        }

        bool? IDialogView.ShowDialog()
        {
            throw new NotImplementedException();
        }

        void IView.Close()
        {
            throw new NotImplementedException();
        }

        private void racb_FromAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtblk_FromAddressLine.Text = (this.DataContext as DAAddEditViewModels).CurrentDA.FromAddress ;
            
        }
        private void autobox_ToAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtbx_ToAddressLine.Text = (this.DataContext as DAAddEditViewModels).CurrentDA.ToAddress;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if ((sender as TextBox).Text.Trim().Length > 0)
                {
                    (this.DataContext as DAAddEditViewModels).getNewDeliveryItem((sender as TextBox).Text.Trim());

                    if ((this.DataContext as DAAddEditViewModels)._SearchNewItemResult.Count == 0)
                        MessageBox.Show("It is not an existing number.");
                }
            }
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).ItemsSource = (this.DataContext as DAAddEditViewModels).DeconList;
        }

        private void btn_Receive_Click(object sender, RoutedEventArgs e)
        {
            ////(this.DataContext as DAAddEditViewModels).SetMode("Receive");
            //(sender as Telerik.Windows.Controls.RadButton).ContextMenu.IsOpen = !(sender as Telerik.Windows.Controls.RadButton).ContextMenu.IsOpen;
            if( _Receivewindow == null)
                _Receivewindow = new DeliveryAdviceQuickReceipt(this);
            _Receivewindow.rgv_DeliveryItems.SelectedItem = null;
            _Receivewindow.Show();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // close Tab item if it is new DA
            if (txtblk_DispatchNumber.Text == "-1")
            {
                foreach (ModelViewItem _item in MainWindow.rtw_MainContentView.Items)
                {
                    
                    if (_item.Header == "New DA")
                    {
                        MainWindow.ModelViewTabComponents.Delete(_item, false);
                        break;
                    }                    
                }
            }
            else
            (this.DataContext as DAAddEditViewModels).SetMode("View");
        }

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {   
            if ((sender as MenuItem).DataContext == null)
                (sender as MenuItem).DataContext = this.DataContext;
        }


        private void racb_FromAddress_Loaded(object sender, RoutedEventArgs e)
        {
            var x = (sender as Telerik.Windows.Controls.RadAutoCompleteBox).ItemsSource;
            if (x == null)
                (sender as Telerik.Windows.Controls.RadAutoCompleteBox).ItemsSource = (this.DataContext as DAAddEditViewModels).DAFromDatasource;
            else
                (sender as Telerik.Windows.Controls.RadAutoCompleteBox).DisplayMemberPath = "Name";
        }

        private void racb_ToAddress_Loaded(object sender, RoutedEventArgs e)
        {
            var x = (sender as Telerik.Windows.Controls.RadAutoCompleteBox).ItemsSource;
            if (x == null)
                (sender as Telerik.Windows.Controls.RadAutoCompleteBox).ItemsSource = (this.DataContext as DAAddEditViewModels).DAToDataSource;
            else
                (sender as Telerik.Windows.Controls.RadAutoCompleteBox).DisplayMemberPath = "Name";
        }

        private void cmbbx_Courier_Loaded(object sender, RoutedEventArgs e)
        {
            var x = cmbbx_Courier.ItemsSource;
            if (cmbbx_Courier.SelectedItem == null)
            {
                if ((this.DataContext as DAAddEditViewModels).CurrentDA != null && (this.DataContext as DAAddEditViewModels).CurrentDA.C_Dictionary_Couriers != null)
                {
                    GAMS.Models.C_Dictionary_Couriers _item =   (this.DataContext as DAAddEditViewModels).CurrentDA.C_Dictionary_Couriers;
                    cmbbx_Courier.SelectedItem = (cmbbx_Courier.ItemsSource as List<GAMS.Models.C_Dictionary_Couriers>).Where(f => f.CourierID == _item.CourierID).FirstOrDefault();
                }
            }
        }

        private void cmbbx_Courier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
