using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GAMS.ViewModel
{
    class DictionaryViewModels_DataType : INotifyPropertyChanged
    {
        GAMSEntities db = new GAMSEntities();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async Task LoadData(DateTime dateFrom, DateTime dateTo)
        {
            IsLoading = true;
            try
            {
                this._dataTypes = await Task.Run(() => getDictionary_DataTypes());
            }
            finally
            {
                IsLoading = false;
            }
        }

        async private Task<List<Dictioanry_DataType>> getDictionary_DataTypes()
        {
            var b = (from a in db.Dictioanry_DataType
                     select a);

            return b.ToList();
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

        private List<Dictioanry_DataType> _dataTypes;
        public List<Dictioanry_DataType> DataTypes
        {
            get
            {
                return _dataTypes;
            }
            set
            {
                _dataTypes = value;
                NotifyPropertyChanged();
            }
        }

        private Dictioanry_DataType _selectedDictionary_DataTypee;
        public Dictioanry_DataType SelectedDictionary_DataTypee
        {
            get
            {
                return _selectedDictionary_DataTypee;
            }
            set
            {
                _selectedDictionary_DataTypee = value;
                NotifyPropertyChanged();
            }
        }
    }
}
