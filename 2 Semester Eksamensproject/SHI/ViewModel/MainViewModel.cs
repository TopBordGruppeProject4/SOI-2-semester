using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.FileProperties;
using SHI.Annotations;

namespace SHI.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        #region Placeholder Properties

        private string _customerAddress;
        private string _customerEmail;
        private string _customerName;
        private string _customerTlf;
        private int _productAmount;
        private string _productDescription;
        private string _productName;
        private double _productPrice;
        private int _rawMaterialAmount;
        private string _rawMaterialDescription;
        private string _rawMaterialName;
        private DateTimeOffset _savedOrderDeadlineDate;
        private TimeSpan _savedORderDeadlineTime;
        private string _savedOrderDescription;
        private int _savedOrderPrice;
        private string _workerAddress;
        private bool _workerAdmin;
        private string _workerName;
        private string _workerTlf;
        private string _workerPassword;
        private string _workerUsername;

        public string CustomerAddress
        {
            get { return _customerAddress; }
            set
            {
                _customerAddress = value;
                OnPropertyChanged();
            }
        }

        public string CustomerEmail
        {
            get { return _customerEmail; }
            set
            {
                _customerEmail = value;
                OnPropertyChanged();
            }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged();
            }
        }

        public string CustomerTlf
        {
            get { return _customerTlf; }
            set
            {
                _customerTlf = value;
                OnPropertyChanged();
            }
        }

        public int ProductAmount
        {
            get { return _productAmount; }
            set
            {
                _productAmount = value;
                OnPropertyChanged();
            }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set
            {
                _productDescription = value;
                OnPropertyChanged();
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        public double ProductPrice
        {
            get { return _productPrice; }
            set
            {
                _productPrice = value;
                OnPropertyChanged();
            }
        }

        public int RawMaterialAmount
        {
            get { return _rawMaterialAmount; }
            set
            {
                _rawMaterialAmount = value;
                OnPropertyChanged();
            }
        }

        public string RawMaterialDescription
        {
            get { return _rawMaterialDescription; }
            set
            {
                _rawMaterialDescription = value;
                OnPropertyChanged();
            }
        }

        public string RawMaterialName
        {
            get { return _rawMaterialName; }
            set
            {
                _rawMaterialName = value;
                OnPropertyChanged();
            }
        }

        public DateTimeOffset SavedOrderDeadlineDate
        {
            get { return _savedOrderDeadlineDate; }
            set
            {
                _savedOrderDeadlineDate = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan SavedORderDeadlineTime
        {
            get { return _savedORderDeadlineTime; }
            set
            {
                _savedORderDeadlineTime = value;
                OnPropertyChanged();
            }
        }

        public string SavedOrderDescription
        {
            get { return _savedOrderDescription; }
            set
            {
                _savedOrderDescription = value;
                OnPropertyChanged();
            }
        }

        public int SavedOrderPrice
        {
            get { return _savedOrderPrice; }
            set
            {
                _savedOrderPrice = value;
                OnPropertyChanged();
            }
        }

        public string WorkerAddress
        {
            get { return _workerAddress; }
            set
            {
                _workerAddress = value;
                OnPropertyChanged();
            }
        }

        public bool WorkerAdmin
        {
            get { return _workerAdmin; }
            set
            {
                _workerAdmin = value;
                OnPropertyChanged();
            }
        }

        public string WorkerName
        {
            get { return _workerName; }
            set
            {
                _workerName = value;
                OnPropertyChanged();
            }
        }

        public string WorkerTlf
        {
            get { return _workerTlf; }
            set
            {
                _workerTlf = value;
                OnPropertyChanged();
            }
        }

        public string WorkerPassword
        {
            get { return _workerPassword; }
            set
            {
                _workerPassword = value;
                OnPropertyChanged();
            }
        }

        public string WorkerUsername
        {
            get { return _workerUsername; }
            set
            {
                _workerUsername = value;
                OnPropertyChanged();
            }
        }

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
