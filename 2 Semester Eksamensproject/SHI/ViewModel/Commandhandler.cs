using System;
using SHI.Model;

namespace SHI.ViewModel
{
    public class CommandHandler
    {
        public MainViewModel MainViewModel { get; set; }

        public CommandHandler(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        #region Add Commands

        public void InvokeAddSavedOrderCommand()
        {
            try
            {
                MainViewModel.SavedOrderCatalogSingleton.AddSavedOrder(DateTime.Now,
                DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(MainViewModel.SavedOrderDeadlineDate,
                    MainViewModel.SavedORderDeadlineTime), MainViewModel.SavedOrderDescription, 1,
                MainViewModel.SavedOrderPrice, 2, MainViewModel.SelectedCustomer.Id);
                MessageHandler.CreateMessage("Ordren er gemt", "Ordre gemt");
            }
            catch (Exception)
            {
                MessageHandler.CreateMessage("Du skal vælge kunde", "Fejl");
            }
        }

        public void InvokeAddCustomerCommand()
        {
            if (!MainViewModel.CustomerCatalogSingleton.CheckCustomer(MainViewModel.CustomerName))
            {
                MainViewModel.CustomerCatalogSingleton.AddCustomer(MainViewModel.CustomerAddress, 1,
                    MainViewModel.CustomerName, MainViewModel.CustomerTlf, MainViewModel.CustomerEmail);
                MessageHandler.CreateMessage(MainViewModel.CustomerName + " er blevet oprettet", "Kunde oprettet");
            }
            else
            {
                MessageHandler.CreateMessage("Kunde du forsøgte at oprette hedder det samme, som en eksisterende bruger", "Kunde findes i forvejen");
            }
        }

        public void InvokeAddProductCommand()
        {
            if (!MainViewModel.ProductCatalogSingleton.CheckProduct(MainViewModel.ProductName))
            {
                MainViewModel.ProductCatalogSingleton.AddProduct(Convert.ToInt32(MainViewModel.ProductAmount),
                    MainViewModel.ProductDescription, 1, MainViewModel.ProductName,
                    Convert.ToDouble(MainViewModel.ProductPrice));
                MessageHandler.CreateMessage(MainViewModel.ProductName + " er blevet oprettet", "Produkt oprettet");
            }
            else
            {
                MessageHandler.CreateMessage("Produktet du forsøgte at tilføje, har samme navn, som et eksisterende produkt", "Produkt findes i forvejen");
            }
        }

        public void InvokeAddRawMaterialCommand()
        {
            if (!MainViewModel.RawMaterialCatalogSingleton.CheckRawMaterial(MainViewModel.RawMaterialName))
            {
                MainViewModel.RawMaterialCatalogSingleton.AddRawMaterial(
                    Convert.ToInt32(MainViewModel.RawMaterialAmount),
                    MainViewModel.RawMaterialDescription, 1, MainViewModel.RawMaterialName);
                MessageHandler.CreateMessage(MainViewModel.RawMaterialName + " er blevet oprettet", "Materiale oprettet");
            }
            else
            {
                MessageHandler.CreateMessage("Det materiale, som du forsøgte at tilføje hedder det samme, som et materiale der findes i forvejen", "Materiale findes i forvejen");
            }
        }

        public void InvokeAddWorkerCommand()
        {
            if (!MainViewModel.WorkerCatalogSingleton.CheckWorker(MainViewModel.WorkerUsername))
            {
                MainViewModel.WorkerCatalogSingleton.AddWorker(MainViewModel.WorkerAdmin, MainViewModel.WorkerPassword,
                    MainViewModel.WorkerUsername, MainViewModel.WorkerAddress, 1, MainViewModel.WorkerName,
                    MainViewModel.WorkerTlf);
                MessageHandler.CreateMessage(MainViewModel.WorkerUsername + " er blevet oprettet", "Bruger oprettet");
            }
            else
            {
                MessageHandler.CreateMessage("Den bruger du forsøgte at tilføje, har samme brugernavn, som en eksisterende bruger", "Brugeren findes i forvejen");
            }
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
            try
            {
                if (MainViewModel.SelectedCustomer != null)
                {
                    var tempCustomer = MainViewModel.SelectedCustomer;
                    MainViewModel.CustomerCatalogSingleton.RemoveCustomer(MainViewModel.SelectedCustomer);
                    MessageHandler.CreateMessage(tempCustomer.Name + " er blevet slettet", "Kunde slettet");
                }
            }
            catch (Exception)
            {
                MessageHandler.CreateMessage("Der ingen kunde valgt", "Fejl");
            }
            
        }

        public void InvokeRemoveWorkerCommand()
        {
            try
            {
                if (MainViewModel.SelectedWorker != null)
                {
                    var tempWorker = MainViewModel.SelectedWorker;
                    MainViewModel.WorkerCatalogSingleton.RemoveWorker(MainViewModel.SelectedWorker);
                    MessageHandler.CreateMessage(tempWorker.Username + " er blevet slettet", "Bruger slettet");
                }
                else
                {
                    MessageHandler.CreateMessage("Du har ikke valgt en bruger", "Fejl");
                }
            }
            catch (Exception)
            {
                MessageHandler.CreateMessage("Du har ikke fået valgt en bruger", "Fejl");
            }
        }

        public void InvokeRemoveProductCommand()
        {
            try
            {
                if (MainViewModel.SelectedProduct != null)
                {
                    var tempProduct = MainViewModel.SelectedProduct;
                    MainViewModel.ProductCatalogSingleton.RemoveProduct(MainViewModel.SelectedProduct);
                    MessageHandler.CreateMessage(tempProduct.Name + " er blevet slettet", "Produkt slettet");
                }
                else
                {
                    MessageHandler.CreateMessage("Du skal vælge et produkt", "Fejl");
                }
            }
            catch (Exception)
            {
                MessageHandler.CreateMessage("Du skal vælge et produkt", "Fejl");
            }
        }

        public void InvokeRemoveRawMaterialCommand()
        {
            try
            {
                if (MainViewModel.SelectedRawMaterial != null)
                {
                    var tempRawMaterial = MainViewModel.SelectedRawMaterial;
                    MainViewModel.RawMaterialCatalogSingleton.RemoveRawMaterial(MainViewModel.SelectedRawMaterial);
                    MessageHandler.CreateMessage(tempRawMaterial.Name + " er blevet slettet", "Materiale slettet");
                }
                else
                {
                    MessageHandler.CreateMessage("Du skal vælge et materiale", "Fejl");
                }
            }
            catch (Exception)
            {
                MessageHandler.CreateMessage("Du skal vælge et materiale", "Fejl");
            }
        }

        public void InvokeRemoveSavedOrderCommand()
        {
            try
            {
                if (MainViewModel.SelectedSavedOrder != null)
                {
                    MainViewModel.SavedOrderCatalogSingleton.RemoveSavedOrder(MainViewModel.SelectedSavedOrder);
                    MessageHandler.CreateMessage("Den valgte ordre er slettet", "Ordre slettet");
                }
                else
                {
                    MessageHandler.CreateMessage("Du skal vælge en ordre", "Fejl");
                }
            }
            catch (Exception)
            {
                MessageHandler.CreateMessage("Du skal vælge en ordre", "Fejl");
            }
            
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
                MainViewModel.CurrentWorker = MainViewModel.WorkerCatalogSingleton.GetWorker(MainViewModel.LoginWorkerUsername);
                if (MainViewModel.CurrentWorker.Admin)
                {
                    MainViewModel.NavigateToAdminMainMenuCommand.Execute(true);
                }
                else
                {
                    MainViewModel.NavigateToWorkerMainMenuCommand.Execute(true);
                }
            }
            else
            {
                MessageHandler.CreateMessage("De indtastede oplysniger findes ikke i systemet, beklager...", "Bruger blev ikke fundet");
            }
        }
    }
}
