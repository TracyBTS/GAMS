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
using GAMS.Models;
using Telerik.Windows.Controls;

namespace GAMS.Applications.Logistics.LogisticsComponents
{
    /// <summary>
    /// Interaction logic for DeliveryAdviceQuickReceipt.xaml
    /// </summary>
    public partial class DeliveryAdviceQuickReceipt : Window
    {
        List<TextBox> _RecvTxtBoxList;
        public DeliveryAdviceQuickReceipt(DeliveryAdviceSingleView _parent)
        {
         
            this.DataContext = _parent.DataContext;

            InitializeComponent();

            this.Closing += DeliveryAdviceQuickReceipt_Closing;
            _RecvTxtBoxList = new List<TextBox>();
        }

        private void DeliveryAdviceQuickReceipt_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Collapsed;
        }

        private void btn_Receive_Click(object sender, RoutedEventArgs e)
        {
           
        }

       

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
          
        }


        private void txtbx_recvnow_LostFocus(object sender, RoutedEventArgs e)
        {
            int _recv = -1;
            if ((sender as TextBox).Text.Trim().Length > 0)
            {
                try
                {
                    _recv = Convert.ToInt32((sender as TextBox).Text.Trim());
                }
                catch (Exception )
                {
                    MessageBox.Show("Please enter the proper number in RECV NOW field");
                    return;
                }


                var source = ((sender as TextBox).DataContext) as C_DeliveryAdviceItems;

                if (source != null)
                {
                    if (source.QuantityReceivedTotal + _recv > source.QuantitySent)
                    {
                        MessageBox.Show("Total received quantity is greater than total sent quantity.");
                        return;
                    }
                }

                bool _createNew = false;
                if (source != null)
                {
                    if (source.C_DeliveryAdviceItemsReceipt.Count() > 0)
                    {
                        var find = from f in source.C_DeliveryAdviceItemsReceipt
                                   where f.DeliveryAdviceItemReceiptID == null
                                   select f;
                        if (find.Count() == 0)
                            _createNew = true;
                        else
                            find.First().QuantityReceivingNow = Convert.ToInt32((sender as TextBox).Text.Trim());
                    }
                    else
                        _createNew = true;
                }

                if (_createNew == true)
                {
                    C_DeliveryAdviceItemsReceipt _new = new C_DeliveryAdviceItemsReceipt();
                    _new.DeliveryAdviceItemID = source.DeliveryAdviceItemID;
                    _new.DateCreated = DateTime.Now;
                    _new.DateModified = DateTime.Now;
                    source.C_DeliveryAdviceItemsReceipt.Add(_new);
                  
                }
            }
        }

        private void txtbx_recvnow_Loaded(object sender, RoutedEventArgs e)
        {
            _RecvTxtBoxList.Add(sender as TextBox);
        }

        private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            var recSource = (sender as TextBox).DataContext as GAMS.Models.View_DeliveryAdviceLastReceive;
            if (recSource != null)
            {
                var DASource = (this.DataContext as ViewModel.DAAddEditViewModels).CurrentDA;
                var DAItemSurce = DASource.C_DeliveryAdviceItems.Where(f => f.DeliveryAdviceItemID == recSource.DeliveryAdviceItemID);
                if (DAItemSurce.Count() > 0)
                {
                    if ((sender as TextBox).Text.Trim().Length > 0)
                    {
                        int _recQty = Convert.ToInt32((sender as TextBox).Text.Trim());

                        if (_recQty > 0 && _recQty + DAItemSurce.First().QuantityReceivedTotal > DAItemSurce.First().QuantitySent)
                        {
                            MessageBox.Show("Total received quantity is greater than total sent quantity.");
                            (sender as TextBox).Text = "";
                            recSource.QuantityReceivingNow = null;
                        }
                        else if (_recQty > 0 
                                  && _recQty + DAItemSurce.First().QuantityReceivedTotal < DAItemSurce.First().QuantitySent 
                                  &&( recSource.ExceptionAddressedNotes==null || recSource.ExceptionAddressedNotes.Trim().Length==0)
                                  )
                        {
                            MessageBox.Show("Total received quantity is less than total sent quantity. This item requires exception notes.");
                            if (recSource != null)
                            {
                                var source = ((ObservableCollection<GAMS.Models.C_DeliveryAdviceItems>)this.rgv_DeliveryItems.ItemsSource);
                                foreach (GAMS.Models.C_DeliveryAdviceItems _item in source)
                                {
                                    if (_item.DeliveryAdviceItemID == recSource.DeliveryAdviceItemID)
                                    {
                                        this.rgv_DeliveryItems.SelectedItem = _item;
                                        break;

                                    }
                                }

                            }



                        }
                    }
                }
            }

            
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            var recSource = (sender as TextBox).DataContext as GAMS.Models.View_DeliveryAdviceLastReceive;
           
        }

        private void btn_ClearException_Click(object sender, RoutedEventArgs e)
        {
            var x = ((sender as Button).Parent as StackPanel).FindName("txtbx_exceptionNotes");
            if ((x as Telerik.Windows.Controls.RadWatermarkTextBox) != null)
                (x as Telerik.Windows.Controls.RadWatermarkTextBox).Text = "";
        }
    }
}
