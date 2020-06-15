using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GAMS.Models;
using GAMS.SharedClasses.SharedCommands;
using GAMS.Applications.Logistics;
using GAMS.ShareControls;
using System.Windows;
using System.Collections.ObjectModel;

namespace GAMS.ViewModel
{
    class LogisticsViewModel : INotifyPropertyChanged
    {
        //GAMSEntities db = new GAMSEntities();
        BNAEntities context;
        public string SelectedFilterType;
        public MainWindow MainWindow;
        public Logistics Logistics;
        private DAAddEditViewModels daAddEditVM;


        public LogisticsViewModel()
        {
            context = new BNAEntities();        
           
        }

        private DateTime _dateFilterFrom = DateTime.Now.AddMonths(-3);
        public DateTime DateFilterFrom
        {
            get
            {
                return _dateFilterFrom;
            }
            set
            {
                _dateFilterFrom = value;
                NotifyPropertyChanged();
               
            }
        }

        DateTime _dateFilterTo = DateTime.Now;
        public DateTime DateFilterTo
        {
            get
            {
                return _dateFilterTo;
            }
            set
            {
                if (_dateFilterTo.Date != value.Date)
                {
                    _dateFilterTo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DeliveryAdvice_Shipping _currentDA;
        public DeliveryAdvice_Shipping CurrentDA
        {
            get
            {
                return this._currentDA;
            }
            private set
            {
                this._currentDA = value;
            }
        }

        public async Task LoadData(string searchType, string searchKey)
        {
            if (IsLoading == true)
                return;

            IsLoading = true;
            try
            {
                this.DAListtoDisplay = await Task.Run(() => GetDeliveryAdvicesList(searchType, searchKey));
            }
            finally
            {
                IsLoading = false;
            }
        }

        async private Task<List<DeliveryAdvice_Shipping>> GetDeliveryAdvicesList(string searchType, string searchKey)
        {
            try
            {
                var test = (from a in context.DeliveryAdvice_Shipping
                            where a.DeliveryNo == 177830 || a.DeliveryNo == 177762
                            select a);
                return test.ToList();
            }
            catch (Exception ee)
            {
                int i;
            }
            return null;
           

            var found = (from a in context.DeliveryAdvice_Shipping
                     where a.date != null && (a.date.Contains("/201") == true || a.date.Contains("/202") == true)
                     select a);

            if (searchKey == null)
            {
                
                if (searchType == "Received")
                    return found.ToList().Where(x => Convert.ToDateTime(x.date) < _dateFilterTo
                    && Convert.ToDateTime(x.date) > _dateFilterFrom
                    && x.RECEIVED_BY != null
                    && x.RECEIVED_BY.Trim().Length > 0).ToList();
                else if (searchType == "UnReceived")
                    return found.ToList().Where(x => Convert.ToDateTime(x.date) < _dateFilterTo
                   && Convert.ToDateTime(x.date) > _dateFilterFrom
                   && (x.RECEIVED_BY == null || x.RECEIVED_BY.Trim().Length == 0)).ToList();
                else if (searchType == "Created")
                    return found.ToList().Where(x => Convert.ToDateTime(x.date) < _dateFilterTo
                   && Convert.ToDateTime(x.date) > _dateFilterFrom).ToList();
            }
            else
            {
                return found.ToList().Where(x => x.DeliveryNo.ToString () == searchKey ||
                                                 x.EMPCode == searchKey ||
                                                 x.EMPCode == searchKey ||
                                                 x.FromName.Contains(searchKey) == true ||
                                                 x.ToName.Contains(searchKey) == true).ToList();
            }
            return null;
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                this._isLoading = value;
                NotifyPropertyChanged();
            }
        }

   

        private List<DeliveryAdvice_Shipping> _daListtoDisplay;
        public List<DeliveryAdvice_Shipping> DAListtoDisplay
        {
            get
            {
                return _daListtoDisplay;
            }
            set
            {
                _daListtoDisplay = value;
                NotifyPropertyChanged();
            }
        }



        public DAAddEditViewModels DAddEditVM { get; set; }
        public DeliveryAdvice_Shipping SelectedDeliveryAdviceItem { get; set; }

        private DeliveryAdvice_Shipping _selectedDeliveryAdvice;      
        public DeliveryAdvice_Shipping SelectedDeliveryAdvice
        {
            get
            {               
                return _selectedDeliveryAdvice;
            }
            set
            {
                _selectedDeliveryAdvice = value;
                DAddEditVM = new DAAddEditViewModels(_selectedDeliveryAdvice== null ? -1: _selectedDeliveryAdvice.DeliveryNo, false);
                if (DADetailWindow != null)
                    DADetailWindow.DataContext = DAddEditVM;
                if (_selectedDeliveryAdvice != null)
                    GetDeliveryItems();
                NotifyPropertyChanged();
            }
        }

      
 
       

        private void GetDeliveryItems()
        {
            var deliveryItems = (from di in context.DeliveryAdvice_item1
                     orderby di.DATE
                     where di.DeliveryNum == _selectedDeliveryAdvice.DeliveryNo
                                 select di).ToList();

            this.DeliveryItems = deliveryItems;
            DeliveryItemCount = DeliveryItems.Count();
        }

        private List<DeliveryAdvice_item1> _deliveryItems;
        public List<DeliveryAdvice_item1> DeliveryItems
        {
            get
            {
                return _deliveryItems;
            }
            set
            {
                _deliveryItems = value;
                NotifyPropertyChanged();
            }
        }

        private int _deliveryItemCount;
        public int DeliveryItemCount
        {
            get
            {
                if (DeliveryItems == null)
                    return 0;
                else
                return _deliveryItemCount;
            }
            set
            {
                _deliveryItemCount = value;
                NotifyPropertyChanged();
            }
        }

        private Item_DeliveryAdviceItem _selectedDeliveryItem;
        private RelayCommand command;

        public Item_DeliveryAdviceItem SelectedDeliveryItem
        {
            get
            {
                return _selectedDeliveryItem;
            }
            set
            {
                _selectedDeliveryItem = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand CreateNewDACommand
        {
            get
            {
                this.command = new RelayCommand(CreateNewDAWindow);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }


        public RelayCommand ViewDACommand
        {
            get
            {
                this.command = new RelayCommand(ViewDAWindow);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }


        public RelayCommand RefreshDAListCommand
        {
            get
            {
                this.command = new RelayCommand(RefreshDAlist);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        private FloatingWindow _mywindow;
        private DeliveryAdviceSingleView DADetailWindow;
        private void CreateNewDAWindow()
        {
            //  MainWindow.RadTabbedWindow_CreateNewTab(new DeliveryAdviceSingleView(Logistics, null), "DA: " );
            if (_mywindow == null)
            {
                _mywindow = new FloatingWindow();
                _mywindow.IsClosed = true;
            }
            else
                _mywindow.grd_Layoutroot.Children.Clear();

            _mywindow.grd_Layoutroot.Children.Add(new DeliveryAdviceSingleView(Logistics, null));
           
            if (_mywindow.IsClosed == true)
            _mywindow.Show();
            
        }
        public void ViewDAWindow()
        {
            //  MainWindow.RadTabbedWindow_CreateNewTab(new DeliveryAdviceSingleView(Logistics, null), "DA: " );
            if (_mywindow == null)
            {
                _mywindow = new FloatingWindow();
                _mywindow.IsClosed = true;
            }
            else
                _mywindow.grd_Layoutroot.Children.Clear();
            if (DADetailWindow == null)
                DADetailWindow = new DeliveryAdviceSingleView(Logistics, null );
            _mywindow.grd_Layoutroot.Children.Add(DADetailWindow);

            if (_mywindow.IsClosed == true)
                _mywindow.Show();


        }

        private void RefreshDAlist()
        {
            LoadData(SelectedFilterType,null);
        }

        

        private void RetrieveDAsToDisplay()
        {
            this.ClearCache();
            int? selectedDAnum = null;
            //save the Id of the currently selected car
            if (this.SelectedDeliveryAdvice  != null)
            {
                selectedDAnum = this.SelectedDeliveryAdvice.DeliveryNo;
            }
        
   
        }

        private void ClearCache()
        {
            if (this.DAListtoDisplay != null)
            {
                //this.context.ClearChanges();
            }
        }

        //private void AddDA()
        //{
        //    bool? operationIsSuccessful;
        //    using (DAAddEditViewModels addModel = new DAAddEditViewModels(null))
        //    {
        //        operationIsSuccessful = addModel.ShowDialog();
        //    }
        //    if (operationIsSuccessful == true)
        //    {
        //        this.RetrieveCarsToDisplay();
        //    }
        //}

        //private void EditCar()
        //{
        //    Car carToEdit = this.SelectedCar;
        //    bool? operationIsSuccessful;
        //    using (AddEditViewModel editModel = new AddEditViewModel(carToEdit.CarID))
        //    {
        //        operationIsSuccessful = editModel.ShowDialog();
        //    }
        //    if (operationIsSuccessful == true)
        //    {
        //        this.RetrieveCarsToDisplay();
        //    }
        //}

        //public RelayCommand AddCarCommand
        //{
        //    get
        //    {
        //        this.command = new RelayCommand(this.AddCar);
        //        return this.command;
        //    }
        //    set
        //    {
        //        this.command = value;
        //    }
        //}

        //public RelayCommand EditCarCommand
        //{
        //    get
        //    {
        //        this.command = new RelayCommand(this.EditCar, this.IsCarSelected);
        //        return this.command;
        //    }
        //    set
        //    {
        //        this.command = value;
        //    }
        //}

                     
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class DAAddEditViewModels

    {
        BNAEntities context;

        private const string EDIT_MODE_TITLE = "Edit";
        private const string ADD_MODE_TITLE = "Add";
        private const string SAVE_ERROR_MESSAGE = "Saving operation failed! Internal error has occured. Exception message:\r\n";
        private const string SAVE_ERROR_TITLE = "Error";

        private int? currentDANum;      
        private RelayCommand command;
        public MainWindow MainWindow;
        public static System.Windows.Controls.UserControl Myowner;


        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                this.title = value.Trim();
            }
        }

        private DeliveryAdvice_Shipping _currentDA;
        public DeliveryAdvice_Shipping CurrentDA
        {
            get
            {
                return this._currentDA;
            }
            private set
            {
                this._currentDA = value;
            }
        }

       
        public bool ModeEdit { get; set; }
        //public ObservableCollection<DeliveryAdvice_item1> CurrentDAItems { get; set; }
        public ObservableCollection<DeliveryAdvice_item1> CurrentDAItems { get; set; }

        public DAAddEditViewModels(int? _currentDANum, bool isEdit) 
        {
            context = new BNAEntities();        
            this.currentDANum = _currentDANum;
            ModeEdit = isEdit;
            InitializeCurrentDAAndTitle();

        }
        public DAAddEditViewModels()
        {
            context = new BNAEntities();
        }


        private void InitializeCurrentDAAndTitle()
        {
            if (this.currentDANum.HasValue)
            {
                //The view model is in Edit mode
                this.CurrentDA = this.context.DeliveryAdvice_Shipping.FirstOrDefault(DA => DA.DeliveryNo == this.currentDANum.Value);
               var x=  this.context.DeliveryAdvice_item1.Where(f => f.DeliveryNum == this.currentDANum.Value);

                this.CurrentDAItems = new ObservableCollection<DeliveryAdvice_item1>(x.ToList());
                this.Title = EDIT_MODE_TITLE;

            }
            else
            {
                //The view model is in Add mode
                this.CurrentDA = new DeliveryAdvice_Shipping()
                {
                    date = DateTime.Today.ToShortDateString()

                };
                this.Title = ADD_MODE_TITLE; 
                this.CurrentDA.DeliveryNo = -1;

                //CurrentDA.DeliveryReasonNum
            }
        }

        private void Save()
        {
            if (this.CurrentDA.DeliveryNo == -1)
            {
                //Add the new car to the context
                this.CurrentDA.DeliveryNo = this.context.DeliveryAdvice_Shipping.Select(DA => DA.DeliveryNo).Max() + 1;
                this.context.DeliveryAdvice_Shipping.Add(this.CurrentDA);
            }
            try
            {
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.HandleException(ex.Message);
                return;
            }
           
        }
        private void HandleException(string exceptionMessage)
        {
            MessageBox.Show(SAVE_ERROR_MESSAGE + exceptionMessage, SAVE_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            //this.OperationIsSuccessful = null;
            //Cause binding refresh
            //this.RaisePropertyChanged("CurrentDA");
        }
        private void Cancel()
        {
            MessageBox.Show("close me");
        }
        public RelayCommand SaveCommand
        {
            get
            {
                this.command = new RelayCommand(this.Save);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                this.command = new RelayCommand(this.Cancel);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public RelayCommand AddNewItemCommand
        {
            get
            {
                this.command = new RelayCommand(this.AddNewItem);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }
        private void AddNewItem()
        {
            DeliveryAdvice_item1 _new = new DeliveryAdvice_item1();
            this.CurrentDAItems.Add(_new);
        }
        public void Dispose()
        {
            //The context is local to the ViewModel and must be disposed together with it
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

       


    }
}
