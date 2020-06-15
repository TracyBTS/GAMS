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

namespace GAMS.ShareControls
{
    /// <summary>
    /// Interaction logic for AddressBookWindow.xaml
    /// </summary>
    public partial class AddressBookWindow : Window
    {
        UserControl MyOwner;
        UIElement ElementTarget;
        AddressTypeMode AddressMode;

        public AddressBookWindow(UserControl myOwner)
        {
            InitializeComponent();

            MyOwner = myOwner;
        }

        public void Load(UIElement elementTarget, string title)
        {
            this.Title = title;
            ElementTarget = elementTarget;
        }

        public void LoadAddressMode(AddressTypeMode addressMode)
        {
            //AddressMode = (AddressTypeMode)Enum.Parse(typeof(AddressTypeMode), addressMode);
            //AddressMode = addressMode;
            //AddressMode = (AddressTypeMode)Convert.ChangeType(addressMode, typeof(AddressTypeMode));
            //AddressMode = (AddressTypeMode)(object)addressMode;

            if (AddressMode == AddressTypeMode.Accounts_BTSOnly)
            {
            }
            else if (AddressMode == AddressTypeMode.Accounts_All)
            {
            }
            else if (AddressMode == AddressTypeMode.Vendor)
            {
            }
            else if (AddressMode == AddressTypeMode.Client)
            {
            }
            else if (AddressMode == AddressTypeMode.QuoteCustomers)
            {
            }

            //run the call to populate the data... Will need  new MVVM for this.
        }
    }

    public enum AddressTypeMode
    {
        Accounts_All = 11,
        Accounts_BTSOnly = 12,
        Vendor = 13,
        Client = 14,
        QuoteCustomers = 15,
        ServiceDepartment = 16,
    }
}
