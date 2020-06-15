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
        UserControl MyOwner;
        bool ModeEdit = false;

        GAMS.ShareControls.AddressBookWindow AddressBookWindow;
        DeliveryAdviceAudit DeliveryAdviceAuditView;
    

        bool? IDialogView.DialogResult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        Window IDialogView.Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IView.DataContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DeliveryAdviceSingleView(UserControl myOwner, int? deliveryAdviceNumber)
        {
            InitializeComponent();
            MyOwner = myOwner;
            cmbbx_Courier.Items.Add("All Purpose");
            cmbbx_Courier.Items.Add("Australian Air Express");
            cmbbx_Courier.Items.Add("BTS Internal");
            cmbbx_Courier.Items.Add("Courier Please");
            cmbbx_Courier.Items.Add("FastWays");
            cmbbx_Courier.Items.Add("FedEx");
            cmbbx_Courier.Items.Add("First Express Couriers");
            cmbbx_Courier.Items.Add("Pack & Send");
            cmbbx_Courier.Items.Add("StarTracks");
            cmbbx_Courier.Items.Add("Toll IPEC");
            cmbbx_Courier.Items.Add("Toll Priority");
            cmbbx_Courier.Items.Add("TNT Express");
            cmbbx_Courier.Items.Add("ZIP");
            cmbbx_Courier.Items.Add("Others");
            cmbbx_Courier.Items.Add("TedEx");
            cmbbx_Courier.SelectedIndex = 0;
            //Load_DeliveryAdvice(deliveryAdviceNumber);
            if (deliveryAdviceNumber!=-1)
                this.DataContext = ((myOwner as Logistics).DataContext as LogisticsViewModel).DAddEditVM;
        }


        public void Load_DeliveryAdvice(int deliveryAdviceNumber)
        {
            //Disable Receipt button if already enabled
        }

        private void rtgsb_ShowLineItemDetails_Checked(object sender, RoutedEventArgs e)
        {

        }

 

        private void brdr_GoToSpace_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_AddressBook_Click(object sender, RoutedEventArgs e)
        {
            if (AddressBookWindow == null)
                AddressBookWindow = new ShareControls.AddressBookWindow(this);

            if ((sender as Telerik.Windows.Controls.RadButton) == btn_AddressBookFrom)
            {
                AddressBookWindow.Load(racb_FromAddress, "Address Book: DA from");
                AddressBookWindow.LoadAddressMode(GAMS.ShareControls.AddressTypeMode.Accounts_BTSOnly);
            }
            else
            {
                AddressBookWindow.Load(racb_FromAddress, "Address Book: DA to");

                //needs fixing against type of devliery advice type it is.
                AddressBookWindow.LoadAddressMode(GAMS.ShareControls.AddressTypeMode.Accounts_BTSOnly);
            }

            AddressBookWindow.Show();
        }

        private void autobox_FromAddress_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btn_GoTo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void autobox_ToAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_D_Add_Click(object sender, RoutedEventArgs e)
        {
            rtgsb_ShowLineItemDetails.IsChecked = true;
        }

        private void btn_D_Edit_Click(object sender, RoutedEventArgs e)
        {
            rtgsb_ShowLineItemDetails.IsChecked = true;
        }

        private void btn_D_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtpckr_DA_Date_Received_LostFocus(object sender, RoutedEventArgs e)
        {
            //validate date check
        }

        private void btn_ShowReportWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

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
            //if (DeliveryAdvice == null || DeliveryAdvice.DeliveryAdviceConstructedNumber == null)
            //{
            //    return;
            //}

            //if (DeliveryAdviceAuditView == null)
            //{
            //    DeliveryAdviceAuditView = new DeliveryAdviceAudit(this, DeliveryAdvice.DeliveryAdviceConstructedNumber);
            //}

            //DeliveryAdviceAuditView.Show();
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

      
    }
}
