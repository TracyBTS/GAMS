using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GAMS.SharedClasses.SharedCommands
{
    class Commands
    {
        public static RoutedUICommand WorkOrderViewCmd
                            = new RoutedUICommand("Work Order List Command",
                                                  "WorkOrderViewCmd",
                                                  typeof(Commands));

        public static RoutedUICommand AssetViewCmd
                           = new RoutedUICommand("Asset View Command",
                                                 "AssetViewCmd",
                                                 typeof(Commands));

        public static RoutedUICommand EmailUnitCmd
                           = new RoutedUICommand("Email Command",
                                                 "EmailUnitCmd",
                                                 typeof(Commands));

        public static RoutedUICommand PrintUnitCmd
                        = new RoutedUICommand("Print Command",
                                              "PrintUnitCmd",
                                              typeof(Commands));

        public static RoutedUICommand SaveAsCmd
                        = new RoutedUICommand("Save As Command",
                                              "SaveAsCmd",
                                              typeof(Commands));

        public static RoutedUICommand SaveCloseCmd
                        = new RoutedUICommand("Save & Close Command",
                                              "SaveCloseCmd",
                                              typeof(Commands));

        public static RoutedUICommand SavePrintCmd
                        = new RoutedUICommand("Save & Print Command",
                                              "SavePrintCmd",
                                              typeof(Commands));

        public static RoutedUICommand AdvancedViewCmd
                        = new RoutedUICommand("Advanced View Command",
                                              "AdvancedViewCmd",
                                              typeof(Commands));

        public static RoutedUICommand WorkOrderCreateCmd
                        = new RoutedUICommand("Create New Work Order Command",
                                              "WorkOrderCreateCmd",
                                              typeof(Commands));

        public static RoutedUICommand LogisticsViewCmd
                        = new RoutedUICommand("Logistics Command",
                                              "LogisticsViewCmd",
                                              typeof(Commands));

        public static RoutedUICommand DeliveryAdviceCreateCmd
                        = new RoutedUICommand("Create New Delivery Advice Command",
                                              "DeliveryAdviceCreateCmd",
                                              typeof(Commands));

        public static RoutedUICommand ShowAuditWindowCmd
                = new RoutedUICommand("Show AuditWindow Command",
                                      "ShowAuditWindowCmd",
                                      typeof(Commands));

        public static RoutedUICommand LogisticsReceiveCmd
                = new RoutedUICommand("Receive DA Command",
                                      "LogisticsReceiveCmd",
                                      typeof(Commands));
        public static RoutedUICommand DeliveryAdviceListRefreshCmd
              = new RoutedUICommand("Refresh DA List Command",
                                    "DeliveryAdviceListRefreshCmd",
                                    typeof(Commands));
    }

    public class RelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }

    //public class RelayCommand : ICommand
    //{
    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }
    //    private Action methodToExecute;
    //    private Task taskToEexecute;
    //    private Func<bool> canExecuteEvaluator;
    //    readonly Action<object> _execute;
    //    readonly Predicate<object> _canExecute;

    //    public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
    //    {
    //        this.methodToExecute = methodToExecute;
    //        this.canExecuteEvaluator = canExecuteEvaluator;
    //    }
    //    public RelayCommand(Action methodToExecute)
    //        : this(methodToExecute, null)
    //    {

    //    }

    //    public RelayCommand(Action<object> execute)
    //        : this(execute, null)
    //    {
    //    }

    //    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    //    {
    //        if (execute == null)
    //            throw new ArgumentNullException("execute");

    //        _execute = execute;
    //        _canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        if (this.canExecuteEvaluator == null)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            bool result = this.canExecuteEvaluator.Invoke();
    //            return result;
    //        }
    //    }
    //    public void Execute(object parameter)
    //    {
    //        //this.methodToExecute.Invoke();

    //        _execute(parameter);
    //    }
    //}

}
