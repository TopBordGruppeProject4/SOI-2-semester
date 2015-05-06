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

        public ICommand AddOrderCommand
        {
            get {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new RelayCommand(CommandHandler.InvokeAddOrderCommand);
                }
                return _addOrderCommand;
            }
            set { _addOrderCommand = value; }
        }

        public CommandHandler CommandHandler { get; set; }

        public OrderCatalogSingleton OrderCatalogSingleton { get; set; }

        public CustomerCatalogSingleton CustomerCatalogSingleton { get; set; }

        public MainViewModel()
        {
            CommandHandler = new CommandHandler(this);

            OrderCatalogSingleton = OrderCatalogSingleton.Instance;
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
