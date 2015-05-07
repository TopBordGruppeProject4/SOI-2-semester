using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _2.Iteration.Annotations;
using _2.Iteration.Model;
using _2.Iteration.View;
using  _2.Iteration.Common;


namespace _2.Iteration.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        #region OrderProps

        private DateTime _creationsDate;
        private DateTime _deadline;
        private string _description;
        private int _id;
        private double _price;
        private int _workerId;
        private int _customerId;
        private ICommand _addOrderCommand;

        public DateTime CreationsDate
        {
            get { return _creationsDate; }
            set
            {
                _creationsDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                _deadline = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public int WorkerId
        {
            get { return _workerId; }
            set
            {
                _workerId = value;
                OnPropertyChanged();
            }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Tlf
        {
            get { return _tlf; }
            set { _tlf = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value;OnPropertyChanged(); }
        }

        public ICommand AddOrderCommand
        {
            get {
                return _addOrderCommand ?? (_addOrderCommand = new RelayCommand(CommandHandler.InvokeAddOrderCommand));
            }
            set { _addOrderCommand = value; }
        }

        public ICommand AddCustomerCommand
        {
            get
            {
                return _addCustomerCommand ??
                       (_addCustomerCommand = new RelayCommand(CommandHandler.InvokeAddCustomerCommand));
            }
            set { _addCustomerCommand = value; }
        }

        private NavigationService _navigationService;

        private ICommand _navigateToAddOrderPageCommand;
        private string _address;
        private string _name;
        private string _tlf;
        private string _email;
        private ICommand _addCustomerCommand;
        private ICommand _selectCustomerCommand;

        public ICommand NavigateToAddOrderPageCommand
        {
            get
            {
                return _navigateToAddOrderPageCommand ??
                       new Common.RelayCommand(() => _navigationService.Navigate(typeof (AddOrderPage)));
            }
        }

        public CommandHandler CommandHandler { get; set; }

        public SavedOrderCatalogSingleton OrderCatalogSingleton { get; set; }

        public CustomerCatalogSingleton CustomerCatalogSingleton { get; set; }

        public static Customer SelectedCustomer { get; set; }

        public ICommand SelectCustomerCommand
        {
            get
            {
                return _selectCustomerCommand ??
                       (_selectCustomerCommand =
                           new RelayArgCommand<Customer>(cs => CommandHandler.SetSelectedCustomer(cs)));
            }
            set { _selectCustomerCommand = value; }
        }

        public MainViewModel()
        {
            CommandHandler = new CommandHandler(this);
            _navigationService = new NavigationService();

            OrderCatalogSingleton = SavedOrderCatalogSingleton.Instance;
            OrderCatalogSingleton.Orders.Clear();
            OrderCatalogSingleton.LoadOrdersAsync();

            CustomerCatalogSingleton = CustomerCatalogSingleton.Instance;
            CustomerCatalogSingleton.Customers.Clear();
            CustomerCatalogSingleton.LoadCustomersAsync();
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
