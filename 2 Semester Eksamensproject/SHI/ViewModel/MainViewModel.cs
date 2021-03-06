﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SHI.Annotations;
using SHI.Model;
using SHI.View;
using _2.Iteration.Common;
using _2.Iteration.ViewModel;

namespace SHI.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
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
        private string _loginWorkerUsername;
        private string _loginWorkerPassword;

        public string LoginWorkerUsername
        {
            get { return _loginWorkerUsername; }
            set { _loginWorkerUsername = value;OnPropertyChanged(); }
        }

        public string LoginWorkerPassword
        {
            get { return _loginWorkerPassword; }
            set { _loginWorkerPassword = value;OnPropertyChanged(); }
        }

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

        #region Navigation

        public ICommand NavigateToWorkerMainMenuCommand
        {
            get
            {
                return _navigateToWorkerMainMenuCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (WorkerMainMenu)));
            }

        }

        public ICommand NavigateBackCommand
        {
            get { return _navigateBackCommand ?? new RelayCommand(() => _navigationService.GoBack()); }

        }

        public ICommand NavigateToAdminMainMenuCommand
        {
            get
            {
                return _navigateToAdminMainMenuCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (AdminMainMenu)));
            }

        }

        public ICommand NavigateToAdminMenuCommand
        {
            get
            {
                return _navigateToAdminMenuCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (AdminMenu)));
            }

        }

        public ICommand NavigateToAdminStoragePageCommand
        {
            get
            {
                return _navigateToAdminStoragePageCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (AdminStoragePage)));
            }

        }

        public ICommand NavigateToCreateOrderPageCommand
        {
            get
            {
                return _navigateToCreateOrderPageCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (CreateOrderPage)));
            }

        }

        public ICommand NavigateToLoginCommand
        {
            get
            {
                return _navigateToLoginCommand ?? new RelayCommand(() => _navigationService.Navigate(typeof (Login)));
            }

        }

        public ICommand NavigateToOrderCatalogPageCommand
        {
            get
            {
                return _navigateToOrderCatalogPageCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (OrderCatalogPage)));
            }

        }

        public ICommand NavigateToStoragePageCommand
        {
            get
            {
                return _navigateToStoragePageCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (StoragePage)));
            }

        }

        public ICommand NavigateToUserCreatePageCommand
        {
            get
            {
                return _navigateToUserCreatePageCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (UserCreatePage)));
            }

        }

        public ICommand NavigateToOrderInformationPageCommand
        {
            get
            {
                return _navigateToOrderInformationPageCommand ??
                       new RelayCommand(() => _navigationService.Navigate(typeof (OrderInformationPage)));
            }
            set { _navigateToOrderInformationPageCommand = value; }
        }


        private NavigationService _navigationService;
        private ICommand _navigateBackCommand;
        private ICommand _navigateToAdminMainMenuCommand;
        private ICommand _navigateToAdminMenuCommand;
        private ICommand _navigateToAdminStoragePageCommand;
        private ICommand _navigateToCreateOrderPageCommand;
        private ICommand _navigateToLoginCommand;
        private ICommand _navigateToOrderCatalogPageCommand;
        private ICommand _navigateToWorkerMainMenuCommand;
        private ICommand _navigateToStoragePageCommand;
        private ICommand _navigateToUserCreatePageCommand;
        private ICommand _navigateToOrderInformationPageCommand;
        

        #endregion

        #region Selected Properties

        public static Customer SelectedCustomer { get; set; }

        public static Worker SelectedWorker { get; set; }

        public static Product SelectedProduct { get; set; }
        public static RawMaterial SelectedRawMaterial { get; set; }
        public static SavedOrder SelectedSavedOrder { get; set; }

        #endregion

        #region CatalogSingletons

        public CustomerCatalogSingleton CustomerCatalogSingleton { get; set; }
        public WorkerCatalogSingleton WorkerCatalogSingleton { get; set; }
        public SavedOrderCatalogSingleton SavedOrderCatalogSingleton { get; set; }
        public ProductCatalogSingleton ProductCatalogSingleton { get; set; }
        public RawMaterialCatalogSingleton RawMaterialCatalogSingleton { get; set; }
        

        #endregion

        #region Add Commands

        private ICommand _addCustomerCommand;
        private ICommand _addWorkerCommand;
        private ICommand _addProductCommand;
        private ICommand _addRawMaterialCommand;
        private ICommand _addSavedOrderCommand;
        

        public ICommand AddCustomerCommand
        {
            get
            {
                return _addCustomerCommand ??
                       (_addCustomerCommand = new RelayCommand(CommandHandler.InvokeAddCustomerCommand));
            }
            set { _addCustomerCommand = value; }
        }

        public ICommand AddWorkerCommand
        {
            get
            {
                return _addWorkerCommand ?? (_addWorkerCommand = new RelayCommand(CommandHandler.InvokeAddWorkerCommand));
            }
            set { _addWorkerCommand = value; }
        }

        public ICommand AddProductCommand
        {
            get
            {
                return _addProductCommand ??
                       (_addProductCommand = new RelayCommand(CommandHandler.InvokeAddProductCommand));
            }
            set { _addProductCommand = value; }
        }

        public ICommand AddRawMaterialCommand
        {
            get
            {
                return _addRawMaterialCommand ??
                       (_addRawMaterialCommand = new RelayCommand(CommandHandler.InvokeAddRawMaterialCommand));
            }
            set { _addRawMaterialCommand = value; }
        }

        public ICommand AddSavedOrderCommand
        {
            get
            {
                return _addSavedOrderCommand ??
                       (_addSavedOrderCommand = new RelayCommand(CommandHandler.InvokeAddSavedOrderCommand));
            }
            set { _addSavedOrderCommand = value; }
        }

        #endregion

        #region Select Commands

        private ICommand _selectCustomerCommand;
        private ICommand _selectWorkerCommand;
        private ICommand _selectProductCommand;
        private ICommand _selectRawMaterialCommand;
        private ICommand _selectSavedOrderCommand;
        

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

        public ICommand SelectWorkerCommand
        {
            get
            {
                return _selectWorkerCommand ??
                       (_selectWorkerCommand = new RelayArgCommand<Worker>(wr => CommandHandler.SetSelectedWorker(wr)));
            }
            set { _selectWorkerCommand = value; }
        }

        public ICommand SelectProductCommand
        {
            get
            {
                return _selectProductCommand ??
                       (_selectProductCommand =
                           new RelayArgCommand<Product>(pr => CommandHandler.SetSelectedProduct(pr)));
            }
            set { _selectProductCommand = value; }
        }

        public ICommand SelectRawMaterialCommand
        {
            get
            {
                return _selectRawMaterialCommand ??
                       (_selectRawMaterialCommand =
                           new RelayArgCommand<RawMaterial>(rm => CommandHandler.SetSelectedRawMaterial(rm)));
            }
            set { _selectRawMaterialCommand = value; }
        }

        public ICommand SelectSavedOrderCommand
        {
            get
            {
                return _selectSavedOrderCommand ??
                       (_selectSavedOrderCommand =
                           new RelayArgCommand<SavedOrder>(so => CommandHandler.SetSelectedSavedOrder(so)));
            }
            set { _selectSavedOrderCommand = value; }
        }

        #endregion

        #region Remove Commands

        private ICommand _removeCustomerCommand;
        private ICommand _removeWorkerCommand;
        private ICommand _removeProductCommand;
        private ICommand _removeRawMaterialCommand;
        private ICommand _removeSavedOrderCommand;
        private ICommand _finishOrderCommand;

        public ICommand RemoveCustomerCommand
        {
            get
            {
                return _removeCustomerCommand ??
                       (_removeCustomerCommand = new RelayCommand(CommandHandler.InvokeRemoveCustomerCommand));
            }
            set { _removeCustomerCommand = value; }
        }

        public ICommand RemoveWorkerCommand
        {
            get
            {
                return _removeWorkerCommand ??
                       (_removeWorkerCommand = new RelayCommand(CommandHandler.InvokeRemoveWorkerCommand));
            }
            set { _removeWorkerCommand = value; }
        }

        public ICommand RemoveProductCommand
        {
            get
            {
                return _removeProductCommand ??
                       (_removeProductCommand = new RelayCommand(CommandHandler.InvokeRemoveProductCommand));
            }
            set { _removeProductCommand = value; }
        }

        public ICommand RemoveRawMaterialCommand
        {
            get
            {
                return _removeRawMaterialCommand ??
                       (_removeRawMaterialCommand = new RelayCommand(CommandHandler.InvokeRemoveRawMaterialCommand));
            }
            set { _removeRawMaterialCommand = value; }
        }

        public ICommand RemoveSavedOrderCommand
        {
            get
            {
                return _removeSavedOrderCommand ??
                       (_removeSavedOrderCommand = new RelayCommand(CommandHandler.InvokeRemoveSavedOrderCommand));
            }
            set { _removeSavedOrderCommand = value; }
        }

        public ICommand FinishOrderCommand
        {
            get
            {
                return _finishOrderCommand ??
                       (_finishOrderCommand = new RelayCommand(CommandHandler.InvokeFinishOrderCommand));
            }
            set { _finishOrderCommand = value; }
        }

        #endregion

        #region Log Commands

        private ICommand _loginWorkerCommand;
        private ICommand _logOutCommand;
        


        public ICommand LoginWorkerCommand
        {
            get
            {
                return _loginWorkerCommand ?? (_loginWorkerCommand = new RelayCommand(CommandHandler.InvokeLoginWorkerCommand));
            }
            set { _loginWorkerCommand = value; }
        }

        public ICommand LogOutCommand
        {
            get { return _logOutCommand ?? (_logOutCommand = new RelayCommand(CommandHandler.InvokeLogOutCommand)); }
            set { _logOutCommand = value; }
        }

        #endregion

        #region ChangeCommands


        private ICommand _changeProductCommand;
        private ICommand _changeRawMaterialCommand;
        private ICommand _assignOrderCommand;
        

        public ICommand ChangeProductCommand
        {
            get
            {
                return _changeProductCommand ??
                       (_changeProductCommand = new RelayCommand(CommandHandler.InvokeChangeProductCommand));
            }
            set { _changeProductCommand = value; }
        }

        public ICommand ChangeRawMaterialCommand
        {
            get
            {
                return _changeRawMaterialCommand ??
                       (_changeRawMaterialCommand = new RelayCommand(CommandHandler.InvokeChangeRawMaterialCommand));
            }
            set { _changeRawMaterialCommand = value; }
        }

        public ICommand AssignOrderCommand
        {
            get
            {
                return _assignOrderCommand ??
                       (_assignOrderCommand = new RelayCommand(CommandHandler.InvokeAssignOrderCommand));
            }
            set { _assignOrderCommand = value; }
        }

        #endregion


        public CommandHandler CommandHandler { get; set; }

        public static Worker CurrentWorker { get; set; }
         
        public ObservableCollection<SavedOrder> CurrentWorkerOrders { get; set; }
        public ObservableCollection<SavedOrder> NewOrders { get; set; }
        public ObservableCollection<SavedOrder> OldOrders { get; set; }
        public ObservableCollection<SavedOrder> TakenOrders { get; set; }
        

        public MainViewModel()
        {
            CommandHandler = new CommandHandler(this);
            _navigationService = new NavigationService();

            SavedOrderCatalogSingleton = SavedOrderCatalogSingleton.Instance;
            SavedOrderCatalogSingleton.SavedOrders.Clear();
            SavedOrderCatalogSingleton.LoadSavedOrdersAsync();

            CustomerCatalogSingleton = CustomerCatalogSingleton.Instance;
            CustomerCatalogSingleton.Customers.Clear();
            CustomerCatalogSingleton.LoadCustomersAsync();

            WorkerCatalogSingleton = WorkerCatalogSingleton.Instance;
            WorkerCatalogSingleton.Workers.Clear();
            WorkerCatalogSingleton.LoadWorkersAsync();

            ProductCatalogSingleton = ProductCatalogSingleton.Instance;
            ProductCatalogSingleton.Products.Clear();
            ProductCatalogSingleton.LoadProductsAsync();

            RawMaterialCatalogSingleton = RawMaterialCatalogSingleton.Instance;
            RawMaterialCatalogSingleton.RawMaterials.Clear();
            RawMaterialCatalogSingleton.LoadRawMaterialsAsync();

            OldOrders = new ObservableCollection<SavedOrder>();
            NewOrders = new ObservableCollection<SavedOrder>();
            TakenOrders = new ObservableCollection<SavedOrder>();
            CurrentWorkerOrders = new ObservableCollection<SavedOrder>();

            if (OldOrders != null)
            {
                OldOrders.Clear();
                SavedOrderCatalogSingleton.AddOrdersToList(OldOrders, 2003);
                
            }

            if (NewOrders != null)
            {
                NewOrders.Clear();
                SavedOrderCatalogSingleton.AddOrdersToList(NewOrders, 2);
                
            }

            if (TakenOrders != null)
            {
                TakenOrders.Clear();
                SavedOrderCatalogSingleton.AddOrdersToList(TakenOrders, 2, 2003);
                
            }

            if (CurrentWorkerOrders != null)
            {
                CurrentWorkerOrders.Clear();
                
            }
            if (CurrentWorker != null)
            {
                SavedOrderCatalogSingleton.AddOrdersToList(CurrentWorkerOrders, CurrentWorker.Id);
            }
            
        }

        #region Property changed

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
