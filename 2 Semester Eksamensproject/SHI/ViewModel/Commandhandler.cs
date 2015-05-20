using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHI.Model;

namespace SHI.ViewModel
{
    internal class CommandHandler
    {
        public MainViewModel MainViewModel { get; set; }

        public CommandHandler(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        #region Add Commands

        public void InvokeAddSavedOrderCommand()
        {
            MainViewModel.SavedOrderCatalogSingleton.AddSavedOrder(DateTime.Now,
                DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(MainViewModel.SavedOrderDeadlineDate,
                    MainViewModel.SavedORderDeadlineTime), MainViewModel.SavedOrderDescription, 1,
                MainViewModel.SavedOrderPrice, 0, MainViewModel.SelectedCustomer.Id);
        }

        public void InvokeAddCustomerCommand()
        {
            MainViewModel.CustomerCatalogSingleton.AddCustomer(MainViewModel.CustomerAddress, 1,
                MainViewModel.CustomerName, MainViewModel.CustomerTlf, MainViewModel.CustomerEmail);
        }

        public void InvokeAddProductCommand()
        {
            MainViewModel.ProductCatalogSingleton.AddProduct(MainViewModel.ProductAmount,
                MainViewModel.ProductDescription, 1, MainViewModel.ProductName, MainViewModel.ProductPrice);
        }

        public void InvokeAddRawMaterialCommand()
        {
            MainViewModel.RawMaterialCatalogSingleton.AddRawMaterial(MainViewModel.RawMaterialAmount,
                MainViewModel.RawMaterialDescription, 1, MainViewModel.RawMaterialName);
        }

        public void InvokeAddWorkerCommand()
        {
            MainViewModel.WorkerCatalogSingleton.AddWorker(MainViewModel.WorkerAdmin, MainViewModel.WorkerPassword,
                MainViewModel.WorkerUsername, MainViewModel.WorkerAddress, 1, MainViewModel.WorkerName,
                MainViewModel.WorkerTlf);
        }

        #endregion

        #region SetSelected Commands

        public void SetSelectedCustomer(Customer customer)
        {
            MainViewModel.SelectedCustomer = customer;
        }

        public void SetSelectedWorker(Worker worker)
        {
            MainViewModel.SelectedWorker = worker;
        }

        public void SetSelectedProduct(Product product)
        {
            MainViewModel.SelectedProduct = product;
        }

        public void SetSelectedRawMaterial(RawMaterial rawMaterial)
        {
            MainViewModel.SelectedRawMaterial = rawMaterial;
        }

        public void SetSelectedSavedOrder(SavedOrder savedOrder)
        {
            MainViewModel.SelectedSavedOrder = savedOrder;
        }

        public void SetCurrentWorker(Worker worker)
        {
            MainViewModel.CurrentWorker = worker;
        }

        #endregion

        #region Remove Commands

        public void InvokeRemoveCustomerCommand()
        {
            MainViewModel.CustomerCatalogSingleton.RemoveCustomer(MainViewModel.SelectedCustomer);
        }

        public void InvokeRemoveWorkerCommand()
        {
            MainViewModel.WorkerCatalogSingleton.RemoveWorker(MainViewModel.SelectedWorker);
        }

        public void InvokeRemoveProductCommand()
        {
            MainViewModel.ProductCatalogSingleton.RemoveProduct(MainViewModel.SelectedProduct);
        }

        public void InvokeRemoveRawMaterialCommand()
        {
            MainViewModel.RawMaterialCatalogSingleton.RemoveRawMaterial(MainViewModel.SelectedRawMaterial);
        }

        public void InvokeRemoveSavedOrderCommand()
        {
            MainViewModel.SavedOrderCatalogSingleton.RemoveSavedOrder(MainViewModel.SelectedSavedOrder);
        }

        #endregion

        public void InvokeLogOutCommand()
        {
            MainViewModel.CurrentWorker = null;
            MainViewModel.NavigateToLoginCommand.Execute(true);
        }

        public void InvokeLoginWorkerCommand()
        {
            if (MainViewModel.WorkerCatalogSingleton.CheckWorker(MainViewModel.LoginWorkerUsername, MainViewModel.LoginWorkerPassword))
            {
                MainViewModel.CurrentWorker =
                    MainViewModel.WorkerCatalogSingleton.GetWorker(MainViewModel.LoginWorkerUsername);
                if (MainViewModel.CurrentWorker.Admin)
                {
                    MainViewModel.NavigateToAdminMenuCommand.Execute(true);
                }
                else
                {
                    MainViewModel.NavigateToWorkerMainMenuCommand.Execute(true);
                }
            }
        }
    }
}
