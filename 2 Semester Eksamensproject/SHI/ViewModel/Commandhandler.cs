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
                MainViewModel.SavedOrderPrice, 2, MainViewModel.SelectedCustomer.Id);
            
        }

        public void InvokeAddCustomerCommand()
        {
            MainViewModel.CustomerCatalogSingleton.AddCustomer(MainViewModel.CustomerAddress, 1,
                MainViewModel.CustomerName, MainViewModel.CustomerTlf, MainViewModel.CustomerEmail);
        }

        public void InvokeAddProductCommand()
        {
            MainViewModel.ProductCatalogSingleton.AddProduct(Convert.ToInt32(MainViewModel.ProductAmount),
                MainViewModel.ProductDescription, 1, MainViewModel.ProductName, Convert.ToDouble(MainViewModel.ProductPrice));
        }

        public void InvokeAddRawMaterialCommand()
        {
            MainViewModel.RawMaterialCatalogSingleton.AddRawMaterial(Convert.ToInt32(MainViewModel.RawMaterialAmount),
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
            if (MainViewModel.CurrentWorker.Admin)
            {
                MainViewModel.WorkerCatalogSingleton.RemoveWorker(MainViewModel.SelectedWorker);
            }
            
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

        #region ChangeCommands


        public void InvokeChangeProductCommand()
        {
            MainViewModel.ProductCatalogSingleton.AddProduct(Convert.ToInt32(MainViewModel.ProductAmount),
                MainViewModel.SelectedProduct.Description, MainViewModel.SelectedProduct.Id,
                MainViewModel.SelectedProduct.Name, MainViewModel.SelectedProduct.Price);
            MainViewModel.ProductCatalogSingleton.RemoveProduct(MainViewModel.SelectedProduct);
        }

        public void InvokeChangeRawMaterialCommand()
        {
            MainViewModel.RawMaterialCatalogSingleton.AddRawMaterial(Convert.ToInt32(MainViewModel.ProductAmount),
                MainViewModel.SelectedRawMaterial.Description, MainViewModel.SelectedRawMaterial.Id,
                MainViewModel.SelectedRawMaterial.Name);
            MainViewModel.RawMaterialCatalogSingleton.RemoveRawMaterial(MainViewModel.SelectedRawMaterial);
        }

        

        #endregion

        public void InvokeAssignOrderCommand()
        {
            MainViewModel.SavedOrderCatalogSingleton.AddSavedOrder(MainViewModel.SelectedSavedOrder.CreationDate, MainViewModel.SelectedSavedOrder.Deadline, MainViewModel.SelectedSavedOrder.Description, MainViewModel.SelectedSavedOrder.Id, MainViewModel.SelectedSavedOrder.Price, MainViewModel.CurrentWorker.Id, MainViewModel.SelectedSavedOrder.CustomerId);
            MainViewModel.SavedOrderCatalogSingleton.RemoveSavedOrder(MainViewModel.SelectedSavedOrder);
            MainViewModel.TakenOrders.Add(MainViewModel.SelectedSavedOrder);
            MainViewModel.NewOrders.Remove(MainViewModel.SelectedSavedOrder);
            
        }

        public void InvokeFinishOrderCommand()
        {
            MainViewModel.SavedOrderCatalogSingleton.AddSavedOrder(MainViewModel.SelectedSavedOrder.CreationDate, MainViewModel.SelectedSavedOrder.Deadline, MainViewModel.SelectedSavedOrder.Description, MainViewModel.SelectedSavedOrder.Id, MainViewModel.SelectedSavedOrder.Price, 2003, MainViewModel.SelectedSavedOrder.CustomerId);
            MainViewModel.SavedOrderCatalogSingleton.RemoveSavedOrder(MainViewModel.SelectedSavedOrder);
            MainViewModel.CurrentWorkerOrders.Remove(MainViewModel.SelectedSavedOrder);
        }

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
                    MainViewModel.NavigateToAdminMainMenuCommand.Execute(true);
                }
                else
                {
                    MainViewModel.NavigateToWorkerMainMenuCommand.Execute(true);
                }
            }
        }
    }
}
