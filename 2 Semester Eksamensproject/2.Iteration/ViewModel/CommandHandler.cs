﻿using System;
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
            
            MainViewModel.OrderCatalogSingleton.AddOrder(MainViewModel.CreationsDate, MainViewModel.Deadline, MainViewModel.Description, 2, MainViewModel.Price, MainViewModel.WorkerId, MainViewModel.CustomerId);
        }

        public void InvokeAddCustomerCommand()
        {
           MainViewModel.CustomerCatalogSingleton.AddCustomer(MainViewModel.Address, 1, MainViewModel.Name, MainViewModel.Tlf, MainViewModel.Email);
        }

        public void SetSelectedCustomer(Customer cus)
        {
            MainViewModel.SelectedCustomer = cus;
        }
    }
}
    