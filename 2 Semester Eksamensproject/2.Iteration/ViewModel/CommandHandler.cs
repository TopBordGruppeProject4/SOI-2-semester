using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.Iteration.Model;

namespace _2.Iteration.ViewModel
{
    class CommandHandler
    {
        public MainViewModel MainViewModel { get; set; }

        public CommandHandler(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }

        public void InvokeAddOrderCommand()
        {
            
            MainViewModel.OrderCatalogSingleton.AddSavedOrder(Convert.ToString(MainViewModel.CreateDate), Convert.ToString(MainViewModel.DeadDate), MainViewModel.Description, 4057, MainViewModel.Price, MainViewModel.WorkerId, MainViewModel.SelectedCustomer.Id);
        }

        public void InvokeAddCustomerCommand()
        {
           MainViewModel.CustomerCatalogSingleton.AddCustomer(MainViewModel.Address, 1, MainViewModel.Name, MainViewModel.Tlf, MainViewModel.Email);
        }

        public void SetSelectedCustomer(Customer cus)
        {
            MainViewModel.SelectedCustomer = cus;
        }

        public void InvokeRemoveCustomerCommand()
        {
            MainViewModel.CustomerCatalogSingleton.RemoveCustomer(MainViewModel.SelectedCustomer);
        }
    }
}
    