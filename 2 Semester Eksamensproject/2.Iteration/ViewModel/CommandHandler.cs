using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            MainViewModel.OrderCatalogSingleton.AddOrder(MainViewModel.CreationsDate, MainViewModel.Deadline, MainViewModel.Description, 1, MainViewModel.Price, MainViewModel.WorkerId, MainViewModel.CustomerId);
        }


    }
}
