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
using GAMS.Interfaces;
using GAMS.Classes;
using GAMS.Models;

namespace GAMS.ViewModel
{
    class LogisticsViewModel : INotifyPropertyChanged
    {
        //GAMSEntities db = new GAMSEntities();
        //RPT_SYSEntities  Aims3Context;
        AIMS3Entities Aims3Context;

        
        public MainWindow MainWindow;
        public Logistics Logistics;
       

        public string SelectedFilterType{ get; set; }
       

        private C_DeliveryAdvice _selectedDeliveryAdvice;
        public C_DeliveryAdvice SelectedDeliveryAdvice 
        {   get { return _selectedDeliveryAdvice; }
            set
            {
                if (value != null)
                {
                    _selectedDeliveryAdvice = value;
                    NotifyPropertyChanged();
                }
            }
            
        }
        public C_DeliveryAdvice CurrentDeliveryAdvice { get; set; }
        public RelayCommand DeleteDACommand { get; set; }
        public RelayCommand CreateNewDACommand { get; set; }
        public RelayCommand EditDACommand { get; set; }
       

        private DateTime _dateFilterFrom = DateTime.Now.AddDays(-7);
        public DateTime DateFilterFrom
        {
            get { return _dateFilterFrom; }
            set
            {
                _dateFilterFrom = value;
                NotifyPropertyChanged();
            }
        }

        DateTime _dateFilterTo = DateTime.Now;
        public DateTime DateFilterTo
        {
            get { return _dateFilterTo; }
            set
            {
                if (_dateFilterTo.Date != value.Date)
                {
                    _dateFilterTo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }            
            set
            {
                this._isLoading = value;
                NotifyPropertyChanged();
            }
        }

        private Item_DeliveryAdviceItem _selectedDeliveryItem;

        public Item_DeliveryAdviceItem SelectedDeliveryItem
        {
            get { return _selectedDeliveryItem; }
            set
            {
                _selectedDeliveryItem = value;
                NotifyPropertyChanged();
            }
        }


        private ObservableCollection<C_DeliveryAdvice> _daListtoDisplay;
        public ObservableCollection<C_DeliveryAdvice> DAListtoDisplay
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
        public C_DeliveryAdvice SelectedDeliveryAdviceItem { get; set; }




        public LogisticsViewModel()
        {
           // Aims3Context = new RPT_SYSEntities();
             Aims3Context = new AIMS3Entities();
            DeleteDACommand = new RelayCommand(DeleteDA);
            CreateNewDACommand = new RelayCommand(CreateNewDAWindow);
            EditDACommand = new RelayCommand(EditDA);

          

        }       

        private void DeleteDA(object Para)
        {
            if (SelectedDeliveryAdvice == null)
                MessageBox.Show("Please select the Delivery Advice");
            else
            {
                MessageBoxResult _res = MessageBox.Show("Do you really want to delete DA:"+SelectedDeliveryAdvice.DeliveryAdviceNumber.ToString(), "Confirmation",
                                                         MessageBoxButton.YesNo);

         
                if (_res == MessageBoxResult.Yes)
                {
                    var found = from f in  Aims3Context.C_DeliveryAdvice
                                where f.DeliveryAdviceNumber == SelectedDeliveryAdvice.DeliveryAdviceNumber
                                select f;
                    if (found.Count() > 0)
                         Aims3Context.C_DeliveryAdvice.Remove(found.First());
                    try
                    {
                         Aims3Context.SaveChanges();

                    }
                    catch (Exception )
                    {
                        MessageBox.Show("System is failed to delete the delivery advice.Please try again");
                    }
                }
                
              
            }
        }

     

        private void EditDA(object Para)
        {
            if (this.SelectedDeliveryAdvice == null)
            {
                MessageBox.Show("Please select the Delivery Advice");
                return;
            }
            //C_DeliveryAdvice DAToEdit = this.SelectedDeliveryAdvice ;
            //bool? operationIsSuccessful;

            //DAAddEditViewModels editModel = new DAAddEditViewModels(DAToEdit.DeliveryAdviceNumber, true);


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

        public bool FindDA(string key)
        {
            var found = from f in  Aims3Context.C_DeliveryAdvice
                        where f.DeliveryAdviceNumber.ToString() == key
                        select f;
            if (found.Count() > 0)
            {
                SelectedDeliveryAdvice = found.First() ;
                return true;
            }
            else
                return false;
        }

        async private Task<ObservableCollection<C_DeliveryAdvice>> GetDeliveryAdvicesList(string searchType, string searchKey)
        {
            try
            {
                var x = this.DateFilterFrom;
                var y = this.DateFilterTo;

                if (searchType == "Created")
                { 
                //var test = (from a in  Aims3Context.C_DeliveryAdvice
                //            where a.DeliveryAdviceNumber == 177830 || a.DeliveryAdviceNumber == 177762
                //            select a);

                    var test = (from a in  Aims3Context.C_DeliveryAdvice
                                where a.DateCreated >DateFilterFrom && a.DateCreated <= DateFilterTo
                                select a);
                    if (test.Count ()>0)
                    return new ObservableCollection<C_DeliveryAdvice>(test.Take(10));
                    else
                        return new ObservableCollection<C_DeliveryAdvice>(test);

                }
            }
            catch (Exception )
            {
                int i = 0;
            }
            return null;
           

            //var found = (from a in  Aims3Context.C_DeliveryAdvice
            //         where a.date != null && (a.date.Contains("/201") == true || a.date.Contains("/202") == true)
            //         select a);

            //if (searchKey == null)
            //{
                
            //    if (searchType == "Received")
            //        return found.ToList().Where(x => Convert.ToDateTime(x.date) < _dateFilterTo
            //        && Convert.ToDateTime(x.date) > _dateFilterFrom
            //        && x.RECEIVED_BY != null
            //        && x.RECEIVED_BY.Trim().Length > 0).ToList();
            //    else if (searchType == "UnReceived")
            //        return found.ToList().Where(x => Convert.ToDateTime(x.date) < _dateFilterTo
            //       && Convert.ToDateTime(x.date) > _dateFilterFrom
            //       && (x.RECEIVED_BY == null || x.RECEIVED_BY.Trim().Length == 0)).ToList();
            //    else if (searchType == "Created")
            //        return found.ToList().Where(x => Convert.ToDateTime(x.date) < _dateFilterTo
            //       && Convert.ToDateTime(x.date) > _dateFilterFrom).ToList();
            //}
            //else
            //{
            //    return found.ToList().Where(x => x.DeliveryAdviceNumber.ToString () == searchKey ||
            //                                     x.EMPCode == searchKey ||
            //                                     x.EMPCode == searchKey ||
            //                                     x.FromName.Contains(searchKey) == true ||
            //                                     x.ToName.Contains(searchKey) == true).ToList();
            //}
            //return null;
        }

      

   

      
 
       


        private List<C_DeliveryAdviceItems> _deliveryItems;
        public List<C_DeliveryAdviceItems> DeliveryItems
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






        private RelayCommand command;
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

     
        private void CreateNewDAWindow(object _selected)
        {
            //  MainWindow.RadTabbedWindow_CreateNewTab(new DeliveryAdviceSingleView(Logistics, null), "DA: " );
            //if (_mywindow == null)
            //{
            //    _mywindow = new FloatingWindow();
            //    _mywindow.IsClosed = true;
            //}
            //else
            //    _mywindow.grd_Layoutroot.Children.Clear();

            //_mywindow.grd_Layoutroot.Children.Add(new DeliveryAdviceSingleView(Logistics, null));
           
            //if (_mywindow.IsClosed == true)
            //_mywindow.Show();

           


        }
        public void ViewDAWindow(object _selected)
        {
            ////  MainWindow.RadTabbedWindow_CreateNewTab(new DeliveryAdviceSingleView(Logistics, null), "DA: " );
            //if (_mywindow == null)
            //{
            //    _mywindow = new FloatingWindow();
            //    _mywindow.IsClosed = true;
            //}
            //else
            //    _mywindow.grd_Layoutroot.Children.Clear();
            //if (DADetailWindow == null)
            //    DADetailWindow = new DeliveryAdviceSingleView(Logistics, null );
            //_mywindow.grd_Layoutroot.Children.Add(DADetailWindow);

            //if (_mywindow.IsClosed == true)
            //    _mywindow.Show();


        }

        private void RefreshDAlist(object _selected)
        {
            LoadData(SelectedFilterType,null);
        }

      
     


        private void ClearCache()
        {
            if (this.DAListtoDisplay != null)
            {
                //this. Aims3Context.ClearChanges();
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

    class DAAddEditViewModels: INotifyPropertyChanged,ImessageInterface

    {
        readonly AIMS3Entities  Aims3Context;
       // readonly AIMSDatabaseEntities1  Aims3Context;
        
        
        private RelayCommand command;
        public MainWindow MainWindow;
        public COD SelectedEmp;
        string DaReason;
        public static System.Windows.Controls.UserControl Myowner;
        public ObservableCollection<COD> DAFromDatasource;
        public ObservableCollection<COD> DAToDataSource;      
        public List<C_DeliveryAdviceItems> _SearchNewItemResult = new List<C_DeliveryAdviceItems>();
        //WS_User.USER CurrentUser;
        Employee CurrentUser;

        public ObservableCollection<string> DeconList;
        public string ReceiveItemException { get; set; }
        public string Title { get; set; }
      
        public List<C_Dictionary_Couriers> CourierList { get; set; }

        private ObservableCollection<C_Audit> _appAuditItem;
        public ObservableCollection<C_Audit> AppAuditItem
        {
            get { return _appAuditItem; }
            set { _appAuditItem = value; 
                  OnPropertyChanged(); }
        }

        private C_DeliveryAdviceItems _selectedDAItem;
        public C_DeliveryAdviceItems SelectedDAItem
        { get { return _selectedDAItem; }
            set { _selectedDAItem = value;
                OnPropertyChanged();
            }
        }

        
        private C_DeliveryAdvice _currentDA;
        public C_DeliveryAdvice CurrentDA 
        { get { return _currentDA; }
          set { _currentDA = value;
                _currentDA.C_DeliveryAdviceItems  = new ObservableCollection<C_DeliveryAdviceItems>(_currentDA.C_DeliveryAdviceItems);
                foreach (C_DeliveryAdviceItems _item in _currentDA.C_DeliveryAdviceItems)
                {
                    _item.View_DeliveryAdviceLastReceive = new ObservableCollection<View_DeliveryAdviceLastReceive>();
                    View_DeliveryAdviceLastReceive _new = new View_DeliveryAdviceLastReceive();
                    _new.DeliveryAdviceItemID = _item.DeliveryAdviceItemID;
                    _item.View_DeliveryAdviceLastReceive.Add(_new);
                }

                    OnPropertyChanged(); }
        }
       
        private COD _selectedFrommCod;
        public COD SelectedFromCod
        {
            get { return _selectedFrommCod; }
            set { _selectedFrommCod = value;
                if (ModeEdit == true)
                    this.CurrentDA.FromAddress = GetAddressbySelectedCod(_selectedFrommCod);
                OnPropertyChanged(); }
        }

        private COD _selectedToCod;
        public COD SelectedToCod
        {
            get  { return this._selectedToCod;  }
            set
            {
                this._selectedToCod = value;
                if (ModeEdit == true)
                    this.CurrentDA.ToAddress= GetAddressbySelectedCod(_selectedToCod);
                OnPropertyChanged();
            }
        }
     

        private bool _modeEdit;
        public bool ModeEdit 
        {
            get { return _modeEdit; }
            set { _modeEdit = value; OnPropertyChanged(); }
        }

        private bool _modeReceive;
        public bool ModeReceive
        {
            get { return _modeReceive; }
            set { _modeReceive = value; OnPropertyChanged(); }
        }

        private int _deliveryItemCount;
        public int DeliveryItemCount
        {
            get { return _deliveryItemCount; }
            set { _deliveryItemCount = value; OnPropertyChanged(); }
        }

        private int _DeliveryAdviceNumber;
        public int DeliveryAdviceNumber
        {
            get { return _DeliveryAdviceNumber; }
            set { _DeliveryAdviceNumber = value; OnPropertyChanged(); }
        }

        #region Command Definition
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

        public RelayCommand DeleteItemCommand
        {
            get
            {
                this.command = new RelayCommand(this.DeleteItem);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public RelayCommand SaveDACommand
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

        public RelayCommand ReceiveItemCommand
        {
            get
            {
                this.command = new RelayCommand(this.ReceiveItemPartially);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public RelayCommand PrepareItemReceiveCommand
        {
            get
            {
                this.command = new RelayCommand(this.PrepareReceiveItems);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public RelayCommand ReceiveAllItemCommand
        {
            get
            {
                this.command = new RelayCommand(this.ReceiveItemAll);
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        public RelayCommand GetAuditItemCommand
        {
            get
            {
                this.command = new RelayCommand(this.GetAuditItem);
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

       

        //public RelayCommand CheckAllCommand
        //{
        //    get
        //    {
        //        this.command = new RelayCommand(this.CheckAll);
        //        return this.command;
        //    }
        //    set
        //    {
        //        this.command = value;
        //    }
        //}
        #endregion 

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public DAAddEditViewModels(C_DeliveryAdvice _da, string _daReason, Employee _user)
        {
            DeconList = new ObservableCollection<string>() { "Yes", "No", "N/A" };
            DAFromDatasource = new ObservableCollection<COD>();
            DAToDataSource = new ObservableCollection<COD>();
            Aims3Context = new AIMS3Entities();
            CurrentUser = _user;
            if (CurrentUser.EmployeeID == 385 && CurrentUser == null)
            {
                CurrentUser = new Employee();
                CurrentUser.Name = "Tracy Wei";
                CurrentUser.EmployeeID = 385;
            }

          

            if (_daReason != null)
                DaReason = _daReason;



            var found = from f in Aims3Context.ServiceDepartments
                         select new COD
                         {
                             Code = f.Code,
                             Name = f.Name,
                             Type = "v"
                         };
            DAFromDatasource = new ObservableCollection<COD>(found.ToList());           
            CourierList = Aims3Context.C_Dictionary_Couriers.Select(f => f).ToList();

            InitializeCurrentDAAndTitle(_da);
            SetMode(_da!= null? "View" : "New");

        }
        public void SetMode(string mode)
        {
            ModeEdit = mode == "Edit" ||mode =="New" ? true : false;
            ModeReceive = mode == "Receive" ? true : false;

           // CurrentDA.ISEDITABLE = ModeEdit;
        }
        private void SetupDaToAddressDataSource(string reason)
        {           

            if (reason.Equals("BTS2BTS") || reason.Equals("Internal Repair") || reason.Equals("PT"))
            {
                DAToDataSource = DAFromDatasource;              
            } 
            else if (reason.Equals("Other"))

            {
                DAToDataSource.Clear();
            }  
            else 
            {
                var Manufacture = from f in Aims3Context.Vendors
                                   where f.Manufacturer == true
                                   select new COD
                                   {
                                       Code = f.Code,
                                       Name = f.Name,
                                       Type = "d"
                                   };

                var Cctr = from f in Aims3Context.CostCenters
                           select new COD
                           {
                               Code = f.Code,
                               Name = f.Name,
                               Type = "a"
                           };

                DAToDataSource =   new ObservableCollection<COD>( Manufacture.ToList().Union(Cctr.ToList()).ToList());


            }
           
        }
        private void InitializeCurrentDAAndTitle(C_DeliveryAdvice _da)
        {
         
            List<C_DeliveryAdviceItems> _temp = new List<C_DeliveryAdviceItems>();
          
            if (_da != null)
            {
                CurrentDA = _da;
               
                this.CurrentDA.DateCreated = this.CurrentDA.DateCreated == null ?  DateTime.Today : this.CurrentDA.DateCreated;
                
                //foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
                //    _item.QuantityReceivedTotal = 0;
            }
            else
            {


                //The view model is in Add mode
                this.CurrentDA = new C_DeliveryAdvice()
                {
                    DateCreated = DateTime.Now,
                    DeliveryAdviceNumber = -1,
                    FromAddress = "",
                    FromName = "",
                    ToAddress = "",
                    ToName = "",
                    DeliveryAdviceReasonCode = DaReason,
                    Notes = "",
                    AccessoriesSent = "",
                    EmployeeID = Convert.ToInt32(CurrentUser.EmployeeID),
                    CourierID = 1,                    
                    C_DeliveryAdviceItems = new ObservableCollection<C_DeliveryAdviceItems>()
                    
                };
                //this.CurrentDA.Employee.Name = CurrentUser.Employee.Name;



            }
           // this._currentDAClone = Classes.General.Clone(CurrentDA);
           
            CurrentDA.IsEditable = true;
            DeliveryAdviceNumber = CurrentDA.DeliveryAdviceNumber;
            DeliveryItemCount = CurrentDA.C_DeliveryAdviceItems.Count();

            if (CurrentDA.Employee == null && CurrentDA.EmployeeID > 0)
            {
                var emp = from f in Aims3Context.Employees
                           where f.EmployeeID == CurrentUser.EmployeeID
                           select f;

                CurrentDA.Employee = new Employee();
                if (emp.Count() > 0)
                    CurrentDA.Employee = emp.First();
            }

            if (CurrentDA.C_Dictionary_Couriers == null && CurrentDA.CourierID > 0)
            {
                var courier = Aims3Context.C_Dictionary_Couriers.Where(f => f.CourierID == CurrentDA.CourierID);
                CurrentDA.C_Dictionary_Couriers = new C_Dictionary_Couriers();
                if (courier.Count() > 0)
                    CurrentDA.C_Dictionary_Couriers = courier.FirstOrDefault();
              
            }

         

            SetupDaToAddressDataSource(DaReason == null ? CurrentDA.DeliveryAdviceReasonCode : DaReason);

            // add 1000460 to FromDataSource
            if (CurrentDA.DeliveryAdviceTypeCode == "P")
            {
                var found = from f in Aims3Context.CostCenters
                            where f.Code == "1000460"
                            select f;
                if (found.Count ()>0)
                DAFromDatasource.Add(new COD {Code = found.First().Code, Name = found.First().Name , Type = "a" });
            }

            if (CurrentDA.FromName.Trim().Length > 0)
            {
                //Part transfer da using 1000460  BET-ADMIN-CENTRAL STR, can't find it from Aims. Better to use the same name as Aims.
                if (CurrentDA.FromName.Contains("1000460") == true)
                    CurrentDA.FromName = "1000460 CENTRAL STORE";

                SelectedFromCod = (from f in this.DAFromDatasource
                                   where f.Name.Contains(CurrentDA.FromName.Trim())
                                   select f).ToList().First();
            }


            if (CurrentDA.DeliveryAdviceReasonCode == "Other" || CurrentDA.DeliveryAdviceReasonCode == "Others" || CurrentDA.DeliveryAdviceReasonCode == "PT")
                SelectedToCod = new COD() { Name = CurrentDA.ToName  };
            else if (CurrentDA.ToName.Trim().Length > 0)
            {
                var found = (from f in this.DAToDataSource
                             where f.Name != null && f.Name.Contains(CurrentDA.ToName.Trim())
                             select f);
                if (found.Count() >0)
                SelectedToCod  = found.ToList().First();
            }
            if (CurrentDA.FromName.Trim().Length > 0 )
                SelectedFromCod = (from f in this.DAFromDatasource
                                   where f.Name.Contains(CurrentDA.FromName.Trim())
                                   select f).ToList().First();
            ReceiveItemException = "";
           
        }
        public string GetAddressbySelectedCod(object para)
        {
            if (para != null)
            {
                COD _obj = para as COD;
                if (_obj != null)
                {
                    if (_obj.Type == "a")
                    {
                        var adr1 = from f in Aims3Context.CostCenters
                                   where f.Code == _obj.Code
                                   select f;
                        if (adr1.Count() > 0)
                           return string.Format("{0}{1}{2}{3} {4} ",
                                                               (string.IsNullOrEmpty(adr1.First().Address1) == true) ? string.Empty : adr1.First().Address1,
                                                                (string.IsNullOrEmpty(adr1.First().Address2) == true) ? string.Empty : "\n" + adr1.First().Address2,
                                                                (string.IsNullOrEmpty(adr1.First().City) == true) ? string.Empty : "\n" + adr1.First().City,
                                                                (string.IsNullOrEmpty(adr1.First().State) == true) ? string.Empty : adr1.First().State == "QL" ? " QLD" : " " + adr1.First().State,
                                                                (string.IsNullOrEmpty(adr1.First().Zip) == true) ? string.Empty : adr1.First().Zip);
                        else
                           return  "";

                    }
                    else if (_obj.Type == "v")
                    {
                        var adr1 = from f in Aims3Context.ServiceDepartments
                                   join a in Aims3Context.C_Address on f.Code equals a.Code 
                                   where f.Code == _obj.Code && a.Type =="v"
                                   select a;
                        if (adr1.Count() > 0)
                            return string.Format("{0}\n{1}\n{2}\n{3} {4}",
                                adr1.First().ContactName,
                                adr1.First().AddressLine1,
                                adr1.First().AddressLine2,
                                adr1.First().City,
                                adr1.First().PostCode);

                        else
                            return "";

                    }
                    else
                    {
                        var adr1 = from p in  Aims3Context.Vendors                                    
                                   join a in  Aims3Context.VendorAddresses   on p.VendorID equals a.VendorID
                                   where p.Code == _obj.Code 
                                   select a;

                        if (adr1.Count() > 0)
                            return string.Format("{0}{1}{2}{3} {4} ",
                                                                 (string.IsNullOrEmpty(adr1.First().Address1) == true) ? string.Empty : adr1.First().Address1,
                                                                  (string.IsNullOrEmpty(adr1.First().Address2) == true) ? string.Empty : "\n" + adr1.First().Address2,
                                                                  (string.IsNullOrEmpty(adr1.First().City) == true) ? string.Empty : "\n" + adr1.First().City,
                                                                  (string.IsNullOrEmpty(adr1.First().State) == true) ? string.Empty : adr1.First().State == "QL" ? " QLD" : " " + adr1.First().State,
                                                                  (string.IsNullOrEmpty(adr1.First().Zip) == true) ? string.Empty : adr1.First().Zip);
                        else
                            return "";

                    }
                }
                else
                   return  "";
            }
            else
                return "";



        }
        private void Save(object para)
        {
            if (SelectedFromCod != null)
                this.CurrentDA.FromName = SelectedFromCod.Name;
            else
            {
                MessageBox.Show("Please select the sender");
                return;
            }
            if (SelectedToCod != null)
                this.CurrentDA.ToName = SelectedToCod.Name;
          
            else
            {
                MessageBox.Show("Please select the destination");
                return;
            }

            if (CurrentDA.C_DeliveryAdviceItems == null || CurrentDA.C_DeliveryAdviceItems.Count == 0)
            {
                MessageBox.Show("Please select the item");
                return;
            }
            else
            {
                foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
                {
                    if (_item.DecontaminationStatus == null)
                    {
                        MessageBox.Show("Please select decontamination for each item.");
                        return;
                    }

                    _item.DateModified = DateTime.Now;
                }
            }
            if (CurrentDA.DeliveryAdviceReasonCode.Contains("Part Utility"))
                CurrentDA.DeliveryAdviceTypeCode = "P";
            else if (CurrentDA.DeliveryAdviceReasonCode.Contains("Quote"))
                CurrentDA.DeliveryAdviceTypeCode = "Q";
            else if (CurrentDA.DeliveryAdviceReasonCode.Contains("Imprest"))
                CurrentDA.DeliveryAdviceTypeCode = "I";
            else
                CurrentDA.DeliveryAdviceTypeCode = "";


            CurrentDA.FacilityID = 1;
            //if (CurrentDA.TYPE == "I")
            //    CurrentDA.FACILITY = _ImprestStockSite;
            CurrentDA.Notes = (CurrentDA.Notes.Length == 0) ? "N/A" : CurrentDA.Notes;

            CurrentDA.CourierID = CurrentDA.C_Dictionary_Couriers != null ? CurrentDA.C_Dictionary_Couriers.CourierID : CurrentDA.CourierID;

            if (this.CurrentDA.DeliveryAdviceNumber == -1)
            {
                if (this.Aims3Context.C_DeliveryAdvice.Count() > 0)
                    this.CurrentDA.DeliveryAdviceNumber = this.Aims3Context.C_DeliveryAdvice.Select(DA => DA.DeliveryAdviceNumber).Max() + 1;
                else
                    this.CurrentDA.DeliveryAdviceNumber = 1;
                this.CurrentDA.DateCreated = DateTime.Now;
                this.CurrentDA.FromName = SelectedFromCod.Name;
                this.CurrentDA.ToName = SelectedToCod.Name;
                this.CurrentDA.DateModified = DateTime.Now.ToShortDateString();
                this.CurrentDA.LastPrintedDate = DateTime.Now;
                this.Aims3Context.C_DeliveryAdvice.Add(this.CurrentDA);
               
            }
            else  // update existing
            {
                // update DA
                var found = Aims3Context.C_DeliveryAdvice.Where(f => f.DeliveryAdviceNumber == CurrentDA.DeliveryAdviceNumber).Select(f => f);
                if (found.Count() > 0)
                {
                    found.First().AccessoriesSent = CurrentDA.AccessoriesSent;
                    found.First().ConNoteNumber = CurrentDA.ConNoteNumber;
                    found.First().CourierID = CurrentDA.CourierID;
                    found.First().DeliveryAdviceReasonCode = CurrentDA.DeliveryAdviceReasonCode;
                    found.First().EmployeeID = CurrentDA.EmployeeID;
                    found.First().FacilityID = CurrentDA.FacilityID;
                    found.First().FromAddress = CurrentDA.FromAddress;
                    found.First().FromName = CurrentDA.FromName;
                    found.First().ToAddress = CurrentDA.ToAddress;
                    found.First().ToName = CurrentDA.ToName;
                    found.First().DeliveryAdviceTypeCode = CurrentDA.DeliveryAdviceTypeCode;
                    found.First().DateModified = DateTime.Now.ToShortDateString();
                }


                int indx = 1;
                foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
                {
                   var fexist = Aims3Context.C_DeliveryAdviceItems.Where(f => f.DeliveryAdviceItemID == _item.DeliveryAdviceItemID && _item.DeliveryAdviceItemID > 0).Select(f => f);
                    if (fexist.Count() > 0)
                    {
                        fexist.First().DateCreated = _item.DateCreated;
                        fexist.First().DecontaminationStatus = _item.DecontaminationStatus;
                        fexist.First().ItemDescription = _item.ItemDescription;
                        fexist.First().Facility = _item.Facility;
                        fexist.First().ItemNumber = _item.ItemNumber;
                        fexist.First().WorkOrderNumber = _item.WorkOrderNumber;
                        fexist.First().QuantitySent = _item.QuantitySent;
                        fexist.First().ReturnAdviceNumber = _item.ReturnAdviceNumber;
                        fexist.First().UnitOfMeasure = _item.UnitOfMeasure;
                    }
                    else
                    {
                        if (Aims3Context.C_DeliveryAdviceItems.Count() > 0)
                            _item.DeliveryAdviceItemID = Aims3Context.C_DeliveryAdviceItems.Select(f => f.DeliveryAdviceItemID).Max() + indx;
                        else
                            _item.DeliveryAdviceItemID = indx;
                        indx++;
                        Aims3Context.C_DeliveryAdviceItems.Add(_item);                     

                    }
                }
            }

            DeliveryAdviceNumber = CurrentDA.DeliveryAdviceNumber;

            { // add wct A05 action
                string action = "";
                var fWorkOrderNumber = CurrentDA.C_DeliveryAdviceItems.Select(f => f.WorkOrderNumber).Distinct();
              
                foreach (string _wo in fWorkOrderNumber)
                {
                    action = "";
                    var fwo =  Aims3Context.WorkOrders.Where(f => f.WoNumber.ToString() == _wo);
                    var x = fwo.Count();
                    
                    var fdawct =  Aims3Context.EmployeeLabors.Where(f => f.WorkOrderID.ToString() == _wo && f.Response.Name == "A05" && f.Action.Contains(CurrentDA.DeliveryAdviceNumber.ToString()));                  
                    if (fwo.Count() > 0 && fdawct.Count () ==0)
                    {
                        var fitem = CurrentDA.C_DeliveryAdviceItems.Where(f => f.WorkOrderNumber == _wo);
                        if (fitem.Count() > 0)
                        {
                            foreach (C_DeliveryAdviceItems _item in fitem)
                            {
                                action += _item.ItemDescription + ";";
                            }
                        }
                        action = "DA:" + CurrentDA.DeliveryAdviceNumber.ToString() + ", Dispatch:" + action + Convert.ToDateTime(CurrentDA.DateCreated).ToShortDateString() + ", by " + CurrentDA.C_Dictionary_Couriers.CourierName + " with Con# " + CurrentDA.ConNoteNumber;
                        AddInhouseLabourAction(Convert.ToInt32(_wo), "A05", action, 0.1, true, CurrentUser.EmployeeID  , 126, DateTime.Now);
                    }
                }
            }

            try
            {
                this. Aims3Context.SaveChanges();                            
                CurrentDA.IsEditable = false;
                SetMode("View");

            }
            catch (Exception ex)
            {
                this.HandleException(ex.Message);               
                return;
            }
           
        }
        private void HandleException(string exceptionMessage)
        {
           // MessageBox.Show(SAVE_ERROR_MESSAGE + exceptionMessage, SAVE_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            //this.OperationIsSuccessful = null;
            //Cause binding refresh
            //this.RaisePropertyChanged("CurrentDA");
        }
        private void Cancel(object _selected)
        {
            MessageBox.Show("close me");
        }

        private void PrepareReceiveItems(object para)
        {
            foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
            {
                _item.C_DeliveryAdviceItemsReceipt.Clear();
                C_DeliveryAdviceItemsReceipt _new = new C_DeliveryAdviceItemsReceipt();
                _new.DeliveryAdviceItemID = _item.DeliveryAdviceItemID;
                _item.C_DeliveryAdviceItemsReceipt.Add(_new);
            }
        }
        private void ReceiveItemAll(object para)
        {
            foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
            {
                var found = _item.C_DeliveryAdviceItemsReceipt.Where(f => f.DeliveryAdviceItemReceiptID == null);
                if (found.Count() == 0 && _item.QuantitySent > _item.QuantityReceivedTotal)
                {
                    C_DeliveryAdviceItemsReceipt _new = new C_DeliveryAdviceItemsReceipt();
                    _new.QuantityReceivingNow = _item.QuantitySent - _item.QuantityReceivedTotal;
                    _item.C_DeliveryAdviceItemsReceipt.Add(_new);
                }
                else if (_item.QuantitySent > _item.QuantityReceivedTotal)
                {
                    found.First().QuantityReceivingNow = _item.QuantitySent - _item.QuantityReceivedTotal;
                }

            }
            ReceiveItemCommit(para);
          
        }


        private void ReceiveItemPartially(object para)
        {           
            ReceiveItemCommit(para);            
         
        }

        private void ReceiveItemCommit(object para)
        {
            //string auditNotes ="";
            //string actionNotes = "";
            //foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
            //{
            //    if (_item.C_DeliveryAdviceItemsReceipt.Count() > 0)
            //    {
            //        var found = from f in _item.C_DeliveryAdviceItemsReceipt
            //                    where f.QuantityReceivingNow > 0 && (f.DeliveryAdviceItemReceiptID == null ) && f.QuantityReceivingNow >0
            //                    select f;
            //        if (found.Count() > 0)
            //        {
            //            foreach (C_DeliveryAdviceItemsReceipt _rec in _item.C_DeliveryAdviceItemsReceipt)
            //            {
            //                _rec.DeliveryAdviceItemReceiptID = Guid.NewGuid();
            //                _rec.DeliveryAdviceItemID = _item.DeliveryAdviceItemID;
            //                _rec.DateCreated = DateTime.Now;
            //                _rec.DateModified = DateTime.Now;
            //                _rec.EmployeeID = CurrentUser.EmployeeID;
            //                _rec.ExceptionAddressedByEmployeeID = CurrentUser.EmployeeID;
            //                _rec.ExceptionCorrectionDeliveryAdviceNumber = CurrentDA.DeliveryAdviceNumber;
            //                Aims3Context.C_DeliveryAdviceItemsReceipt.Add(_rec);

            //                _item.QuantityReceivedTotal += Convert.ToInt32(_rec.QuantityReceivingNow);
            //                auditNotes += string.Format("Receive {0}  Qty {1}  by {2}\n",
            //                    _item.ItemNumber!=null && _item.ItemNumber.Trim().Length >0 ? _item.ItemNumber.Trim(): _item.ItemDescription.Trim(),
            //                    _rec.QuantityReceivingNow ,
            //                   CurrentUser.Employee.Name );

            //                var fwo = Aims3Context.WorkOrders.Where(f => f.WoNumber.ToString() == _item.WorkOrderNumber);
            //                if (fwo.Count()>0)
            //                { 
            //                    actionNotes = string.Format("Receive {0}  Qty {1}  by {2}\n",
            //                                _item.ItemNumber != null && _item.ItemNumber.Trim().Length > 0 ? _item.ItemNumber.Trim() : _item.ItemDescription.Trim(),
            //                                _rec.QuantityReceivingNow,
            //                                CurrentUser.Employee.Name);
            //                    AddInhouseLabourAction(fwo.First().WorkOrderID, "A06", actionNotes, 0, false, CurrentUser.EmployeeID, 126, DateTime.Now);
            //                }
            //            }
            //        }
            //    }

            //    if (auditNotes.Trim().Length > 0)
            //        AddDAAuidt(CurrentUser.EmployeeID, auditNotes.Trim());
            //}

            //try
            //{
            //    Aims3Context.SaveChanges();
            //    MessageBox.Show("Items are received successfully. ");
            //    (para as Window).Visibility = Visibility.Collapsed;
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("Failed to receive items, please try again\n" +ee.ToString ());
            //}

            string auditNotes = "";
            string actionNotes = "";
          
            foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
            {
                auditNotes = "";
                actionNotes = "";

                //association can't be updated. 
                //_item.QuantityReceivedTotal = _item.QuantityReceivedTotal + Convert.ToInt32(_new.QuantityReceivingNow);
                var fitem = Aims3Context.C_DeliveryAdviceItems.Where(f => f.DeliveryAdviceItemID == _item.DeliveryAdviceItemID);
                

                if (_item.View_DeliveryAdviceLastReceive.Count() > 0)
                {

                    foreach (View_DeliveryAdviceLastReceive _Lastrec in _item.View_DeliveryAdviceLastReceive)
                    {
                        if (_Lastrec.QuantityReceivingNow != null && _Lastrec.QuantityReceivingNow > 0)
                        {
                            if (_Lastrec.QuantityReceivingNow + _item.QuantityReceivedTotal > _item.QuantitySent)
                            {
                                MessageBox.Show("Item {0}: Total Received quantity is greater than total sent quantity.", _item.ItemNumber != null && _item.ItemNumber.Trim().Length > 0 ? _item.ItemNumber : _item.ItemDescription);
                                _Lastrec.QuantityReceivingNow = 0;
                                return;
                            }
                            else if (_Lastrec.QuantityReceivingNow + _item.QuantityReceivedTotal < _item.QuantitySent &&
                                  (_Lastrec.ExceptionAddressedNotes == null || _Lastrec.ExceptionAddressedNotes.Trim().Length == 0))
                            {
                                MessageBox.Show("Item {0}: Total Received quantity is less than total sent quantity.Please enter exception notes",
                                    _item.ItemNumber != null && _item.ItemNumber.Trim().Length > 0 ? _item.ItemNumber : _item.ItemDescription);

                                return;
                            }


                            C_DeliveryAdviceItemsReceipt _new = new C_DeliveryAdviceItemsReceipt();
                            _new.DeliveryAdviceItemReceiptID = Guid.NewGuid();
                            _new.DeliveryAdviceItemID = _item.DeliveryAdviceItemID;
                            _new.DateCreated = DateTime.Now;
                            _new.DateModified = DateTime.Now;
                            _new.EmployeeID = CurrentUser.EmployeeID;
                            _new.ExceptionAddressedByEmployeeID = CurrentUser.EmployeeID;
                            _new.ExceptionCorrectionDeliveryAdviceNumber = CurrentDA.DeliveryAdviceNumber;
                            _new.ExceptionAddressedNotes = _Lastrec.ExceptionAddressedNotes;
                            _new.QuantityReceivingNow = _Lastrec.QuantityReceivingNow;
                            _new.QuantityPreviouslyReceived = _item.QuantityReceivedTotal;
                            _new.IsExceptionRaised = _new.ExceptionAddressedNotes == null || _new.ExceptionAddressedNotes.Trim().Length == 0 ? false : true;
                            Aims3Context.C_DeliveryAdviceItemsReceipt.Add(_new);

                            if (fitem.Count() > 0)
                            {
                                fitem.First().QuantityReceivedTotal += Convert.ToInt32(_new.QuantityReceivingNow);
                            }
                            var x = fitem.First().QuantityReceivedTotal;

                            auditNotes += string.Format("Receive {0}  Qty {1}  by {2}\n",
                                _item.ItemNumber != null && _item.ItemNumber.Trim().Length > 0 ? _item.ItemNumber.Trim() : _item.ItemDescription.Trim(),
                                _new.QuantityReceivingNow,
                               CurrentUser.Name);

                            var fwo = Aims3Context.WorkOrders.Where(f => f.WoNumber.ToString() == _item.WorkOrderNumber);
                            if (fwo.Count() > 0)
                            {
                                actionNotes = string.Format("Receive {0}  Qty {1}  by {2}\n",
                                            _item.ItemNumber != null && _item.ItemNumber.Trim().Length > 0 ? _item.ItemNumber.Trim() : _item.ItemDescription.Trim(),
                                            _new.QuantityReceivingNow,
                                            CurrentUser.Name);
                                AddInhouseLabourAction(fwo.First().WorkOrderID, "A06", actionNotes, 0, false, CurrentUser.EmployeeID, 126, DateTime.Now);

                             }
                        }
                    }

                }

                if (auditNotes.Trim().Length > 0)
                    AddDAAuidt(CurrentUser.EmployeeID, auditNotes.Trim(),"REC");
            }

            try
            {
                Aims3Context.SaveChanges();
                MessageBox.Show("Items are received successfully. ");
                foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
                {
                    foreach (View_DeliveryAdviceLastReceive _lstRcv in _item.View_DeliveryAdviceLastReceive)
                    {
                        _lstRcv.QuantityReceivingNow = 0;
                        _lstRcv.ExceptionAddressedNotes = "";
                    }
                }
                    (para as Window).Visibility = Visibility.Collapsed;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Failed to receive items, please try again\n" + ee.ToString());
            }

        }

      
        public void GetAuditItem(object para)
        {
                var found = from f in Aims3Context.C_Application
                            where f.ApplicationName == "DA"
                            select f;
                if (found.Count() > 0)
                    this.AppAuditItem = new ObservableCollection<C_Audit>(Aims3Context.C_Audit.Where(f => f.ApplicationID == found.First().ApplicationID && f.Key1 == CurrentDA.DeliveryAdviceNumber.ToString()).ToList());
                else
                    this.AppAuditItem = null;

        }

       

        private void AddDAAuidt(int _empID , string _auditNotes, string key2)
        {
            var found = from f in Aims3Context.C_Application
                        where f.ApplicationName == "Delivery Advice"
                        select f;
          
            C_Audit _audit = new C_Audit();
            _audit.AuditID = Guid.NewGuid ();
            // if can'g find the application id, insert 0000 instead
            _audit.ApplicationID = found.Count() > 0 ? found.First().ApplicationID : new Guid () ;
            _audit.DateCreated = DateTime.Now;
            _audit.EmployeeID = _empID;
            _audit.Key1 = CurrentDA.DeliveryAdviceNumber.ToString();
            _audit.Key2 = key2;
            _audit.Key3 = "";
            _audit.Notes = _auditNotes;

             Aims3Context.C_Audit.Add(_audit);
        }
        private void AddNewItem(object _selected)
        {
            C_DeliveryAdviceItems _new = new C_DeliveryAdviceItems();
            _new.DateCreated = DateTime.Now;
            _new.DateModified = DateTime.Now;
            
     
            this.CurrentDA.C_DeliveryAdviceItems.Add(_new);
            DeliveryItemCount = CurrentDA.C_DeliveryAdviceItems.Count();
        }
        private void DeleteItem(object _selected)
        {

            if (SelectedDAItem == null)
                MessageBox.Show("Please select the item first");
            else
            {
                MessageBoxResult  Msgresult = MessageBox.Show(
                             "Do you really want to delete the item?",
                             "Confirmation", MessageBoxButton.YesNo);

                if (Msgresult == MessageBoxResult.Yes)
                {
                    CurrentDA.C_DeliveryAdviceItems.Remove(SelectedDAItem);
                }

                DeliveryItemCount = CurrentDA.C_DeliveryAdviceItems.Count();

            }


           
        }

        private void AddInhouseLabourAction(int _wo, string _responseCode, string _action, double _hrs,
            bool _billable, int _empID, double rate, DateTime _start)
        {
            EmployeeLabor _wct = new EmployeeLabor();
            _wct.EmployeeID = _empID;
            _wct.Action = _action;
            _wct.Billable = _billable;
            _wct.Charge = rate * _hrs;

            _wct.StartDateTime = DateTime.Now;
            _wct.Hours = _hrs;
            _wct.EndDateTime = _start.AddHours(_hrs);
            _wct.WorkOrderID = _wo;
           

            var fresID = from f in Aims3Context.Responses
                        where f.Code == _responseCode
                        select f;
            if (fresID.Count() > 0)
                _wct.ResponseID = fresID.First().ResponseID;

            if (Aims3Context.EmployeeRates.Count() == 0)
                _wct.EmployeeRate = AddEmployeeRate(rate, Convert.ToInt32(_empID), true);
            else
            {
                var found = Aims3Context.EmployeeRates.Where(f => f.EmployeeID == _empID && f.Charge == rate);
                var x = found.Count();
                if (found.Count() == 0)
                    _wct.EmployeeRate = AddEmployeeRate(rate, Convert.ToInt32(_empID), true);
                else
                    _wct.EmployeeRate = found.FirstOrDefault();
            }
            _wct.EmployeeRateID = _wct.EmployeeRate.EmployeeRateID;
            _wct.RateType = _wct.EmployeeRate.RateType;
            if (Aims3Context.EmployeeLabors.Count() == 0)
                _wct.EmployeeLaborID = 1;
            else
            _wct.EmployeeLaborID = Aims3Context.EmployeeLabors.Select(f => f.EmployeeLaborID).Max() + 1;

            Aims3Context.EmployeeLabors.Add(_wct);

        }
        private EmployeeRate  AddEmployeeRate(double rate, int employeeID, bool billable)
        {
            EmployeeRate _rate = new EmployeeRate();
            _rate.Billable = true;
            _rate.Charge = rate;
            _rate.EmployeeID = employeeID;
            _rate.Name = "";
            _rate.RateType = "";
            Aims3Context.EmployeeRates.Add(_rate);

            // employeeID is identity . not required to create when adding the new value.
            _rate.EmployeeRateID = Aims3Context.EmployeeRates.Count() > 0 ? Aims3Context.EmployeeRates.Select(f => f.EmployeeRateID).Max() + 1 : 1;
            return _rate;

        }

        public void getNewDeliveryItem(string key)
        {
            _SearchNewItemResult.Clear();
           
            if (key != "Other")
            {

                //var found = from p in  Aims3Context.POes
                //                join d in  Aims3Context.LINE_ITEM  on p.PO_ID equals d.PO_ID
                //                where p.PO_NUM.Equals(key)
                //                select new 
                //                {
                //                     key,
                //                    d.QTY_ORDERED,
                //                   d.BUYER_PART_DESC,
                //                    d.BUYER_PART_NUM,
                //                    p.FACILITY,
                //                    d.UOM
                //                };


              

                //if (found.Count() > 0)
                //{
                //    var mylist = found.ToList().Select(d=> new C_DeliveryAdviceItems()
                //        {
                //        WorkOrderNumber = key,
                //                        QuantitySent = Convert.ToInt32(d.QTY_ORDERED),
                //                        ItemDescription = d.BUYER_PART_DESC,
                //                        ItemNumber = d.BUYER_PART_NUM,
                //                        Facility = d.FACILITY,
                //                        UnitOfMeasure = d.UOM,                                      
                //                        DateCreated = DateTime.Now,
                //                        DecontaminationStatus="N/A",
                //                        ReturnAdviceNumber = ""
                //    });

                //    foreach (C_DeliveryAdviceItems _item in mylist)
                //        _SearchNewItemResult.Add(_item);

                //}
                //else  // search by work order
                {
                    //var equ = from p in  Aims3Context.WorkOrders
                    //          join a in  Aims3Context.Equipments on p.EquipmentID equals a.EquipmentID
                    //          where p.WorkOrderID.ToString().Equals(key)
                    //          select new C_DeliveryAdviceItems
                    //          {
                    //              WorkOrderNumber = key,
                    //              QuantitySent = 1,
                    //              ItemDescription = a.TagNumber + " SN:" + ((a.Serial != null && a.Serial.Length > 0) ? a.Serial : "Nil"),
                    //              ItemNumber = a.TagNumber,
                    //              Facility = 1,
                    //              UnitOfMeasure = "EA",                                
                    //              DateCreated = DateTime.Now,
                    //              DecontaminationStatus = "N/A",
                    //              ReturnAdviceNumber = ""
                    //          };

                    var equ = from p in Aims3Context.WorkOrders
                              join a in Aims3Context.Equipments on p.EquipmentID equals a.EquipmentID
                              where p.WoNumber.ToString().Equals(key)
                              select new
                              {
                                  key,                                  
                                  a.Serial,
                                   a.TagNumber,                                 
                                  DateTime.Now
                                  
                              };



                    var parts = from p in  Aims3Context.InHouseMaterials 
                                join w in Aims3Context.WorkOrders on p.WorkOrderID equals w.WorkOrderID
                                join prt in  Aims3Context.Parts on p.PartID equals prt.PartID into temp
                                where w.WoNumber.ToString().Equals(key)
                                from t in temp.DefaultIfEmpty()
                                select new 
                                {
                                     key,
                                   p.Quantity,
                                    p.Description,
                                    p.Part.PartNumber
                                };
                 
                 
                    if (equ.Count() > 0)
                    {
                        foreach (var _item in equ)
                        {
                            C_DeliveryAdviceItems _newItem = new C_DeliveryAdviceItems();
                            _newItem.WorkOrderNumber = _item.key;
                            _newItem.QuantitySent = 1;
                            _newItem.ItemDescription = _item.TagNumber + " SN:" + ((_item.Serial != null && _item.Serial.Length > 0) ? _item.Serial : "Nil");
                            _newItem.ItemNumber = _item.TagNumber;
                            _newItem.Facility = 1;
                            _newItem.UnitOfMeasure = "EA";
                            _newItem.DateCreated = DateTime.Now;
                            _newItem.DecontaminationStatus = "N/A";
                            _newItem.ReturnAdviceNumber = "";
                            _SearchNewItemResult.Add(_newItem);
                        }
                        
                    }

                    if (parts.Count() > 0)
                    {
                        var mylist = parts.ToList().Select(d => new C_DeliveryAdviceItems()
                        {
                            WorkOrderNumber = key,
                            QuantitySent = Convert.ToInt32(d.Quantity),
                            ItemDescription = d.Description,
                            ItemNumber = d.PartNumber,
                            Facility = 1,
                            UnitOfMeasure = "EA",                            
                            DateCreated = DateTime.Now,
                            DecontaminationStatus = "N/A",
                            ReturnAdviceNumber=""
                        });

                     
                        foreach (C_DeliveryAdviceItems _item in mylist)
                            _SearchNewItemResult.Add(_item);
                    }

                    foreach (C_DeliveryAdviceItems _item in CurrentDA.C_DeliveryAdviceItems)
                    {
                        // remove search item
                        if (_item.WorkOrderNumber != null
                            && _item.WorkOrderNumber.Trim().Length > 0
                            && (_item.ItemDescription == null || _item.ItemDescription.Trim().Length == 0))
                        {
                            CurrentDA.C_DeliveryAdviceItems.Remove(_item);
                            break;
                        }
                        else if (_item.WorkOrderNumber == null)
                        {
                            {
                                CurrentDA.C_DeliveryAdviceItems.Remove(_item);
                                break;
                            }
                        }
                    }

                    if (_SearchNewItemResult.Count() > 0)
                    {
                        foreach (C_DeliveryAdviceItems _item in _SearchNewItemResult)
                            CurrentDA.C_DeliveryAdviceItems.Add(_item);
                    }
                }
            }
        }
        public void Dispose()
        {
            //The context is local to the ViewModel and must be disposed together with it
            if (this. Aims3Context != null)
            {
                this. Aims3Context.Dispose();
            }
        }
        public MessageBoxResult ShowMessageBox(string text, string title, MessageBoxButton buttons)
        {
            return MessageBox.Show(text, title, buttons);
        }
    }
}
