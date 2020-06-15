using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace GAMS.ViewModel
{
    class WorkOrderViewModel : INotifyPropertyChanged
    {
        
        public WorkOrderViewModel()
        {
            
        }

        List<WorkOrderViewFilterType> _workOrderMainFilterType = new List<WorkOrderViewFilterType>();
        List<WorkOrderViewFilterType> WorkOrderMainFilterType
        {
            get { return _workOrderMainFilterType; }
            set { _workOrderMainFilterType = value;  }
        }

        void AddWorkOrderMainFilterType(WorkOrderViewFilterType workOrderFilterType)
        {
            _workOrderMainFilterType.Add(workOrderFilterType);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class WorkOrderViewFilterType
    {
        private bool _typeSelected;
        public bool TypeSelected
        {
            get { return _typeSelected; }
            set { _typeSelected = value; }
        }

        private string _typeDescription;
        public string TypeDescription
        {
            get { return _typeDescription; }
            set { _typeDescription = value; }
        }
    }
}
