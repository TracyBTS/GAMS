using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;


namespace GAMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Data.BNALocalDatabase LocalDatabase;

        public Applications.UserProfile.UserProfile Window_UserProfile;

        
       
        Guid SessionID;
        //public WS_User.USER _currentUser;
        public Models.Employee   _currentUser;

        public MainWindow(WS_User.USER myUser, Guid sessionID)
        {
            StyleManager.ApplicationTheme = new Office2013Theme();

            InitializeComponent();
            SessionID = sessionID;

            _currentUser = new Models.Employee();
            _currentUser.EmployeeID = 385;
            Window_UserProfile = new Applications.UserProfile.UserProfile(myUser.Name);

            //string PathFolder = string.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BNALocalDB.db");
            //LocalDatabase = new Data.BNALocalDatabase(PathFolder);

            rtw_MainContentView.HideMaximizeButton = true;
            rtw_MainContentView.HideMinimizeButton = true;

            radMenuItem_Session.Header = myUser.Name;
       



        }

        public void RadTabbedWindow_CreateNewTab(UserControl control, string title)
        {
            ModelViewTabComponents.Add(new ModelViewItem() { Content = control, Header = title });
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            var targetTab = (e.Source as Telerik.Windows.Controls.RadMenuItem).DataContext as Telerik.Windows.Controls.RadTabItem;
        }

        private void rtw_MainContentView_AddingNewTab(object sender, Telerik.Windows.Controls.TabbedWindow.AddingNewTabEventArgs e)
        {
            //clicking the add button means that it adds a default item to the main contol - eg; if logistics is open it will add a new delivery advice

            if ((rtw_MainContentView.SelectedItem as ModelViewItem).UserControlCatagoryApplicationType == UserControlApplicationsCatagoryType.Logistic)
            {
                //ModelViewTabComponents.Add(new ModelViewItem() 
                //{ 
                //    Content = new GAMS.Applications.Logistics.DeliveryAdviceSingleView(null), 
                //    HeaderIcon = "pack://application:,,,/GAMS;component/SharedImages/LogisticsNew-40x40.png",
                //    Header = "New DA",
                //    UserControlCatagoryApplicationType = UserControlApplicationsCatagoryType.Logistic
                //});

                GAMS.Applications.Logistics.LogisticsComponents.Window_Courier _newWindow = new Applications.Logistics.LogisticsComponents.Window_Courier(this);
                _newWindow.Show();
            }
            else if ((rtw_MainContentView.SelectedItem as ModelViewItem).UserControlCatagoryApplicationType == UserControlApplicationsCatagoryType.WorkOrder)
            {
                ModelViewTabComponents.Add(new ModelViewItem()
                {
                    Content = new GAMS.Applications.WorkOrder.WorkOrderSingleView(this, -1),
                    HeaderIcon = "pack://application:,,,/GAMS;component/SharedImages/WorkOrderNew-40x40.png",
                    Header = "New WO",
                    UserControlCatagoryApplicationType = UserControlApplicationsCatagoryType.WorkOrder
                });
            }
        }

        private void rmi_MainTabbedWindow_CloseThis(object sender, RoutedEventArgs e)
        {
            var targetModelViewItem = (e.Source as MenuItem);
            if (targetModelViewItem != null)
            {
                ModelViewTabComponents.Delete(targetModelViewItem.DataContext as ModelViewItem, false);
            }
        }

        private void rmi_MainTabbedWindow_CloseAllButThis(object sender, RoutedEventArgs e)
        {
            var targetModelViewItem = (e.Source as MenuItem);
            if (targetModelViewItem != null)
            {
                ModelViewTabComponents.Delete(targetModelViewItem.DataContext as ModelViewItem, true);
            }
        }

        private void rmi_MainTabbedWindow_CloseAll(object sender, RoutedEventArgs e)
        {
            ModelViewTabComponents.Clear();
            rm_MainMenuLeft.Focus();
        }

        private void WorkOrderViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        

        private void WorkOrderViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ModelViewTabComponents.Add(new ModelViewItem()
            {
                Content = new GAMS.Applications.WorkOrder.WorkOrderListView(this),
                Header = "Work Order List",
                HeaderIcon = "pack://application:,,,/GAMS;component/SharedImages/List-40x40.png",
                UserControlCatagoryApplicationType = UserControlApplicationsCatagoryType.WorkOrder
            });

            rtw_MainContentView.Focus();
        }

        private void AssetViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           
        }

        private void AssetViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void LogisticsViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void LogisticsViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var newControl = new ModelViewItem()
            {
                Content = new GAMS.Applications.Logistics.Logistics(this),
                Header = "Logistcs",
                HeaderIcon = "pack://application:,,,/GAMS;component/SharedImages/Logistics-40x40.png",
                UserControlCatagoryApplicationType = UserControlApplicationsCatagoryType.Logistic
            };

            ModelViewTabComponents.Add(newControl);

            //newControl.Content.Focus();
        }

        private void rtw_MainContentView_SelectionChanged(object sender, RadSelectionChangedEventArgs e)
        {
            if (rtw_MainContentView.SelectedItem != null)
                (rtw_MainContentView.SelectedItem as ModelViewItem).SetFocus();
        }

      
        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class ModelViewContentItems : INotifyPropertyChanged
    {
        public ModelViewContentItems()
        {
            ModelViewItems = new ObservableCollection<ModelViewItem>();
            ModelViewItems.CollectionChanged += ModelViewItems_CollectionChanged;
        }

        private void ModelViewItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged();
        }

        private ObservableCollection<ModelViewItem> _modelViewItems = new ObservableCollection<ModelViewItem>();
        public ObservableCollection<ModelViewItem> ModelViewItems
        {
            get
            {
                return _modelViewItems;
            }
            set
            {
                _modelViewItems = value;
            }
        }

        public void Add(ModelViewItem modelViewItem)
        {
           
            _modelViewItems.Add(modelViewItem);
            SelectedItem = modelViewItem;
            AddButtonVisibility = Visibility.Visible;
        }

        public bool IsExisting(string _header)
        {
            if (_modelViewItems.Count() > 0)
            {
                foreach (ModelViewItem _item in _modelViewItems)
                {
                    if (_item.Header == _header)
                    {
                        SelectedItem = _item;
                        return true;
                    }
                }
            }

            return false;
        }


        public void Delete(ModelViewItem modelViewItem, bool deleteAllOthers = false)
        {
            if (deleteAllOthers)
            {
                foreach (var a in _modelViewItems)
                    if (modelViewItem != a)
                        _modelViewItems.Remove(a);
            }
            else
            {
                _modelViewItems.Remove(modelViewItem);
            }

            AddButtonVisibility = _modelViewItems == null || _modelViewItems.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        public void Clear()
        {
            _modelViewItems.Clear();
            AddButtonVisibility = Visibility.Collapsed;
        }

        ModelViewItem _selectedItem;
        public ModelViewItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value; 
                    NotifyPropertyChanged();
                }
            }
        }

        private Visibility _addButtonVisibility = Visibility.Collapsed;
        public Visibility AddButtonVisibility
        {
            get 
            { 
                return _addButtonVisibility; 
            }
            set
            {
                _addButtonVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public enum UserControlApplicationsCatagoryType
    {
        None = -1,
        Logistic = 1,
        WorkOrder = 2
    };

    public class ModelViewItem : INotifyPropertyChanged
    {
        private String _header;
        public String Header
        {
            get
            {
                return this._header;
            }
            set
            {
                if (this._header != value)
                {
                    this._header = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _headerIcon;
        public String HeaderIcon
        {
            get
            {
                return this._headerIcon;
            }
            set
            {
                if (this._headerIcon != value)
                {
                    this._headerIcon = value;
                }
            }
        }

        private UserControl _content;
        public UserControl Content
        {
            get
            {
                return this._content;
            }
            set
            {
                if (this._content != value)
                {
                    this._content = value;
                }
            }
        }

        private UserControlApplicationsCatagoryType _userControlCatagoryApplicationType; 
        public UserControlApplicationsCatagoryType UserControlCatagoryApplicationType
        {
            get
            {
                return this._userControlCatagoryApplicationType;
            }
            set
            {
                this._userControlCatagoryApplicationType = value;
            }
        }

        public void SetFocus()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += (s, e) =>
            {
                dispatcherTimer.Stop();
                this.Content.Focus();
            };
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
